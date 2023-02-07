using Microsoft.EntityFrameworkCore;
using RailwayReservationSystem.Data;
using RailwayReservationSystem.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//injected dbcontext class in the servcies collection
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(

    builder.Configuration.GetConnectionString("DatabaseConnection")
    ));

//dependency injection 
builder.Services.AddScoped<ITrainDetailsRepository, TrainDetailsRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();



//profile mapping 
builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
