global using todo__server.Models;
global using Microsoft.EntityFrameworkCore;
global using AutoMapper;
global using todo__server.Services;
global using todo__server.Data;
using Microsoft.Extensions.FileProviders;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<TaskServiceInterface,TaskService> ();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:4200") // Allow requests from this origin
           .AllowAnyMethod() // Allow any HTTP method
           .AllowAnyHeader() // Allow any header
           .AllowCredentials(); // If your Angular app sends credentials (e.g., cookies)
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "profileimages")),
    RequestPath = "/profileimages"
});
app.MapControllers();

app.Run();
