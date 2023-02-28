using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using RailwayReservationSystem.Data;
using RailwayReservationSystem.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter a valid Jwt bearer token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme,new string[] { } }
    });

});



//injected dbcontext class in the servcies collection
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(

    builder.Configuration.GetConnectionString("DatabaseConnection")
    ));

//enable cors policy 
var Allowspecificorigins = "_allowspecificorigin";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Allowspecificorigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });

});
//dependency injection 
builder.Services.AddScoped<ITrainDetailsRepository, TrainDetailsRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IQuotaRepository, QuotaRepository>();
builder.Services.AddScoped<ITokenHandler,RailwayReservationSystem.Repositories.TokenHandler>();



//profile mapping 
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//injectiong jwt 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>

options.TokenValidationParameters=new TokenValidationParameters
{
    ValidateIssuer=true,
    ValidateAudience=true,
    ValidateLifetime=true,
    ValidateIssuerSigningKey=true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//cors policy
app.UseCors(Allowspecificorigins);

app.Run();
