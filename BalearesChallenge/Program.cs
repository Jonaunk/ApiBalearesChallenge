using Application;
using BalearesChallengeApi.Extensions;
using Domain.Entities.Users;
using Identity;
using Identity.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.Contexts;
using Persistence.Seeds;
using Shared;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

//Agrego identity layer

builder.Services.AddApplicationLayer(builder.Configuration);

//Agrego el service de JWT
builder.Services.AddIdentityInfrastructureLayer(builder.Configuration);

//Aca Agrego el servicio de la capa Shared
builder.Services.AddSharedLayer(builder.Configuration);

//Aca agrego capa de persistencia
builder.Services.AddPersistenceLayer(builder.Configuration);


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

//Agrego instancia para versionado
builder.Services.AddApiVersioningExtension();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BalearesChallengeAPI", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
       }
      },
      new string[] { }
    }
  });
});

var app = builder.Build();


app.UseDeveloperExceptionPage();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
}

//app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

//middleware de errorres y validacion de jwt

app.UseErrorHandlingMiddleware();
app.UseJwtValidationMiddleware();

app.UseAuthorization();



app.MapControllers();

await CargarSeeds();

app.Run();


async Task CargarSeeds()
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    var userManager = services.GetRequiredService<UserManager<Usuario>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var identityContext = services.GetRequiredService<IdentityContext>();
    identityContext.Database.EnsureCreated();


    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();

    await ProvinciasSeed.SeedProvinciaAsync(context);
    await CiudadesSeed.SeedCiudadAsync(context);
   
}