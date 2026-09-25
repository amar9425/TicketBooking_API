using Microsoft.EntityFrameworkCore;
//using Scalar.AspNetCore;
using TicketBookingAPI.Data;
using TicketBookingAPI.Endpoints;
using TicketBookingAPI.Services;



using TicketBookingAPI.Services.Auth;
using TicketBookingAPI.Services.Movies;
using TicketBookingAPI.Services.Shows;
using TicketBookingAPI.Services.Bookings;

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


<<<<<<< HEAD
builder.Services.AddScoped<IAuthService, AuthService>(); 
=======
builder.Services.AddScoped<IAuthService, AuthService>();
>>>>>>> d17e09942ae38a48299c28b5d999ae14707f4770
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IShowService, ShowService>();
builder.Services.AddScoped<IBookingService, BookingService>();

var app = builder.Build();

// CORS Middleware
app.UseCors("ReactPolicy");

// OpenAPI + Scalar
app.MapOpenApi();
//app.MapScalarApiReference();

// Endpoints
app.MapAuthEndpoints();
app.MapMovieEndpoints();
app.MapShowEndpoints();
app.MapBookingEndpoints();

app.Run();