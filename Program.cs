
using PHI.Models;
using PHI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<PHIConfig>(builder.Configuration.GetSection("PHIConfig"));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPhiRedactionService, PhiRedactionService>();

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

// Configure CORS
app.UseCors(policy =>
    policy.WithOrigins("http://localhost:4200")
          .AllowAnyMethod()
          .AllowAnyHeader());

app.Run();