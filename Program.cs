using Microsoft.OpenApi.Models;
using MNSBI2.Data.Contexts;
using MNSBI2.Data.Repositories;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Voeg services toe aan de DI-container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Voeg DbContext toe.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString), ServiceLifetime.Scoped); // Geef ServiceLifetime aan

// Repositories.
builder.Services.AddScoped<IBIViewRepository, BIViewRepository>();
builder.Services.AddLogging();

// Configureer CORS.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Of andere domeinen waar uw frontend draait.
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Swagger.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MNSBI API", Version = "v1" });
});

var app = builder.Build();

// Configureer de HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MNSBI API V1"));
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin"); // Zorg ervoor dat CORS voor de UseRouting en UseAuthorization komt.

app.UseAuthorization();

app.MapControllers();

app.Run();



//using Microsoft.EntityFrameworkCore;
//using MNSBI.Core.Interfaces;
//using MNSBI.Data.Repositories;
//using Microsoft.OpenApi.Models;
//using MNSBI.Data.Contexts;

//var builder = WebApplication.CreateBuilder(args);

//// Voeg services toe aan de DI-container.
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();

//// Voeg DbContext toe.
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//// Repositories.
////builder.Services.AddScoped<IBIViewRepository, BIViewRepository>();
//builder.Services.AddScoped<IBIViewRepository, BIViewRepository>();
//builder.Services.AddLogging();


//// Configureer CORS.
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigin",
//        builder =>
//        {
//            builder.WithOrigins("http://localhost:4200") // Of andere domeinen waar uw frontend draait.
//                   .AllowAnyHeader()
//                   .AllowAnyMethod();
//        });
//});

//// Swagger.
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MNSBI API", Version = "v1" });
//});

//var app = builder.Build();

//// Configureer de HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MNSBI API V1"));
//}

//app.UseHttpsRedirection();

//app.UseCors("AllowSpecificOrigin"); // Zorg ervoor dat CORS voor de UseRouting en UseAuthorization komt.

//app.UseAuthorization();

//app.MapControllers();

//app.Run();