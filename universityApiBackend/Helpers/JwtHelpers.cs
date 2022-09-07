using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using universityApiBackend.Models.DataModels;

namespace universityApiBackend.Helpers
{
    public static class JwtHelpers
    {
        private static object expireTime;

        public static IEnumerable<Claim> GetClaims(this UserTokens UserAccounts, Guid Id)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", UserAccounts.Id.ToString()),
                new Claim(ClaimTypes.Name, UserAccounts.UserName),
                new Claim(ClaimTypes.Email, UserAccounts.EmailId),
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("mm/dd/yyyy hh:mm:ss tt")),
            };

            if (UserAccounts.UserName == "Admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));

            }
            else if (UserAccounts.UserName == "User 1")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("UserOnly", "User 1"));
            }

            return claims;
        }


        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaims(userAccounts, Id);
        }

        public static UserTokens GenTokenKey(UserTokens model, JwtSettings jwtSettings)
        {
            try
            {
                var userToken = new UserTokens();

                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }
                // Obtainig Secret Key
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);

                Guid Id;

                //Expiration time in 1 day
                DateTime dateTime = DateTime.UtcNow.AddDays(1);

                // Validity
                userToken.Validity = (TimeSpan)expireTime;

                // Generate JWT
                var jwToken = new JwtSecurityToken(

                    issuer: jwtSettings.ValidIssuer,
                    audience: jwtSettings.ValidAudiance,
                    claims: GetClaims(model, out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset((DateTime)expireTime).DateTime,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256));

                userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwToken);
                userToken.UserName = model.UserName;
                userToken.Id = model.Id;
                userToken.GuidId = Id;
                
                return userToken;

            }
            catch (Exception exception)
            {
                throw new Exception("Error generating JWT", exception);
            }
        }
    }
}
