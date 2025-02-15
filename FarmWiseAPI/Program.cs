using DataAccess.Data;
using DTOS.Profiles;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer; // Add this using directive
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();

builder.Logging.AddConsole();

builder.Services.AddDbContext<FarmWiseDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddHealthChecks();

//Configure CORS
//builder.Services.AddAutoMapper(cfg =>
//{
//    cfg.AddProfile<SoilDataProfile>();
//cfg.AddProfile<UserProfile>();
//cfg.AddProfile<CropProfile>();
//});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();  


builder.Services.AddAutoMapper(typeof(SoilDataProfile), typeof(UserProfile), typeof(CropProfile));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    option.TokenValidationParameters=new TokenValidationParameters 
    { 
        ValidateIssuer=true,
        ValidateAudience=true,
        ValidateLifetime=true,
        ValidateIssuerSigningKey=true,
        ValidIssuer=builder.Configuration["Jwt:Issuer"],
        ValidAudience=builder.Configuration["Jwt:Audience"],
        IssuerSigningKey=new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        
    });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseExceptionHandler("/error");

app.MapHealthChecks("/health");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
