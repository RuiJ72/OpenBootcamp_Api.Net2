// 1- usings to work with Entity framework
using Microsoft.EntityFrameworkCore;
using universityApiBackend;
using universityApiBackend.DataAccess;
using universityApiBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// 2 - Connections with SQL server Express
const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);


// 3 - Add context to server
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));

//7 - Add service of JWT Authentication
builder.Services.AddJwtTokenServices(builder.Configuration);


// Add services to the container.

builder.Services.AddControllers();

// 4 - Adding Custom Services
builder.Services.AddScoped<IStudentsService, StudentService>();
// TODO: add the other services


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// 8 - TODO: Config Swagger to take in acount the athozisation
builder.Services.AddSwaggerGen();

// 5 - CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// 6 - Tell aplication to use CORS
app.UseCors("CorsPolicy");

app.Run();
