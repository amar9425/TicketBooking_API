using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TicketBookingAPI.Data;
using TicketBookingAPI.Endpoints;
using TicketBookingAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// OpenAPI
builder.Services.AddOpenApi();

// Database
builder.Services.AddDbContext<TicketBookingDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy",
        policy =>
        {
            policy
                .WithOrigins(
                    "http://localhost:5173",
                    "https://localhost:5173"
                )
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Services
builder.Services.AddScoped<TicketBookingService>();

var app = builder.Build();

// CORS Middleware
app.UseCors("ReactPolicy");

// OpenAPI + Scalar
app.MapOpenApi();
app.MapScalarApiReference();

// Endpoints
app.MapAuthEndpoints();
app.MapMovieEndpoints();
app.MapShowEndpoints();
app.MapBookingEndpoints();

app.Run();