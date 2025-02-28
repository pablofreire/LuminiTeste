using LuminiTeste.Api.Migrations;
using LuminiTeste.Application.Service;
using LuminiTeste.Domain.Interface.Repository;
using LuminiTeste.Domain.Interface.Service;
using LuminiTeste.Infra.Data;
using LuminiTeste.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DatabaseConfig>();
builder.Services.AddScoped<IRouteRepository, RouteRepository>();
builder.Services.AddScoped<IRouteService, RouteService>();

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbMigration = ActivatorUtilities.CreateInstance<DatabaseMigration>(
        scope.ServiceProvider,
        scope.ServiceProvider.GetRequiredService<IConfiguration>(),
        scope.ServiceProvider.GetRequiredService<ILogger<DatabaseMigration>>()
    );

    if (!dbMigration.ExecuteMigration())
    {
        throw new Exception("Falha ao executar migrações do banco de dados");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("../swagger/v1/swagger.json", "Lumini Teste - API");
    c.RoutePrefix = "docs";
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();