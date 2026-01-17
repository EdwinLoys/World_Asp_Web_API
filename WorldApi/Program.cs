using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorldApi.Common;
using WorldApi.Repository;
using WorldApi.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CustomPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
#endregion Configure Database

#region Configure AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
#endregion 

#region
builder.Services.AddTransient<ICountryRepository, CountryRepository>();
builder.Services.AddTransient<IStatesRepository, StatesRepository>();


#endregion


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WorldApi.Data.ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseCors("CustomPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
