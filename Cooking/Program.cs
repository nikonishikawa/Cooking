using CookingClassLibrary.Entities;
using CookingClassLibrary.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CookingDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

builder.Services.AddScoped<IReviewsService, ReviewsService>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRatingAndReviewService, UserRatingAndReviewService>();
builder.Services.AddScoped<IUserRatingAndReviewTempService, UserRatingAndReviewTempService>();

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
