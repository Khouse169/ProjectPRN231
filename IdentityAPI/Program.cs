using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(options => 
    { 
        options.TokenValidationParameters = new TokenValidationParameters 
        { 
            ValidateIssuer = true, 
            ValidIssuer = "IdentityServerIssuer", 
            ValidateAudience = true, 
            ValidAudience = "IdentityServerClient", 
            ValidateLifetime = true, 
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VerySecretAndLongKey-NeedMoreSymbolsHere-123")), ValidateIssuerSigningKey = true, 
        }; 
    }); 
builder.Services.AddAuthorization();
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

app.Run();
