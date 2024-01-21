using Microsoft.EntityFrameworkCore;
using QuizMaster.DataAccess;

namespace QuizMaster.API.Extensions;

/// <summary>
///  Configurations of the migration of the user
/// </summary>
public static partial class ApplicationDependenciesConfiguration
{
    /// <summary>
    /// Extension method for configuring database migrations
    /// this method is designed to be used with the WebApplication 
    /// class and applies pending migrations to ensure the database schema 
    /// is synchronized with the latest version of the application's data model.
    /// </summary>
    /// <param name="app">The WebApplication instance to which this method is applied.</param>
    /// <returns>A Task representing the asynchronous execution of the migration process.</returns>
    public async static Task UseMigration(this WebApplication app)
    {
        var serviceScopeFactory = app.Services.GetService<IServiceScopeFactory>();
        using var scope = serviceScopeFactory.CreateScope();

        var handler = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await handler.Database.MigrateAsync();
    }
}
