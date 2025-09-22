using Microsoft.EntityFrameworkCore;
using PetInstagramAPI.Data.Contexts;
using PetInstagramAPI.Services.Abstractions;
using PetInstagramAPI.Services.Implementions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PetsDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("PetsDbConnection")));


builder.Services.AddScoped<IAnimalTypeService,AnimalTypeService>();
builder.Services.AddScoped<IAnimalProfileService,AnimalProfileService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
