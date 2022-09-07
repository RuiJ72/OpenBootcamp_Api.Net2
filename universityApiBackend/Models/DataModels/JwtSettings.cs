﻿namespace universityApiBackend.Models.DataModels
{
    public class JwtSettings
    {
        public bool ValidateIssuserSigningKey { get; set; }
        public string IssuerSigningKey { get; set; } = string.Empty;
        public bool ValidateIssuer { get; set; } = true;
        public string? ValidIssuer { get; set; }
        public bool ValidateAudiance { get; set; } = true;
        public string? ValidAudiance { get; set; }

        public bool RequireExpirationTime { get; set; } 
        public bool ValidateLifetime { get; set; } = true;

    }
}
