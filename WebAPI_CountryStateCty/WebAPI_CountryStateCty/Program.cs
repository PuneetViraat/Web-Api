using Microsoft.EntityFrameworkCore;
using WebAPI_CountryStateCty.Data;
using WebAPI_CountryStateCty.DTOMapping;
using WebAPI_CountryStateCty.Repository;
using WebAPI_CountryStateCty.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var cs = builder.Configuration.GetConnectionString("conStr");
builder.Services.AddDbContext<ApplicationDbContext>
  (options => options.UseSqlServer(cs));

builder.Services.AddScoped<ICountryRepository,CountryRepository>();
builder.Services.AddScoped<IStateRepository,StateRepository>();
builder.Services.AddScoped<ICityRepository,CityRepository>();
builder.Services.AddScoped<IRegisterRepository,RegisterRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
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
