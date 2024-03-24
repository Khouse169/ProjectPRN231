using BusinessObject.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<StoryDAO>();
builder.Services.AddScoped<GenreDAO>();
builder.Services.AddScoped<ProjectPRN231Context>();
builder.Services.AddCors(opts =>
{
    opts.AddPolicy("CORSPolicy", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed((host) => true));
});

// Add IHttpContextAccessor and IUrlHelper services
builder.Services.AddHttpContextAccessor();
builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("CORSPolicy");

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
