using DbUp;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace LuminiTeste.Api.Migrations
{
    public class DatabaseMigration
    {
        private readonly IConfiguration _config;
        private readonly ILogger<DatabaseMigration> _logger;

        public DatabaseMigration(IConfiguration config, ILogger<DatabaseMigration> logger)
        {
            _config = config;
            _logger = logger;
        }

        public bool ExecuteMigration()
        {
            try
            {
                var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? _config.GetConnectionString("DefaultConnection");
                //throw new Exception(connectionString);
                var scriptPath = Path.Combine(AppContext.BaseDirectory, "Migrations", "Scripts");
                var upgrader = DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsFromFileSystem(scriptPath)
                    .LogToConsole()
                    .Build();

                var result = upgrader.PerformUpgrade();

                if (!result.Successful)
                {
                    _logger.LogError($"Erro durante a migração: {result.Error}");
                    return false;
                }

                _logger.LogInformation("Migração concluída com sucesso!");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao executar migração: {ex.Message}");
                throw;
            }
        }
    }
}
