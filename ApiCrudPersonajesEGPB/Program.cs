using ApiCrudPersonajesEGPB.Data;
using ApiCrudPersonajesEGPB.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("AzureServer");
builder.Services.AddDbContext<PersonajesContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<RepositoryPersonajes>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Crud Personajes",
        Description = "Examen Api Crud Personajes",
        Version = "v1"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api crud Personajes Examen");
    options.RoutePrefix = "";
});
if (app.Environment.IsDevelopment())
{
   
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
