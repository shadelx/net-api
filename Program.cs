using Microsoft.EntityFrameworkCore;
using student_api;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Load the .env file
Env.Load();
// Add environment variables to configuration
builder.Configuration.AddEnvironmentVariables();

//Add application db context
builder.Services.AddDbContext<StudentContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

//register custom services
builder.Services.AddScoped<IStudentService, StudentService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
