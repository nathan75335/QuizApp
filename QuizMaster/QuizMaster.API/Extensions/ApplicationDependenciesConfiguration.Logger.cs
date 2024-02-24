using FluentValidation;
using FluentValidation.AspNetCore;
using QuizMaster.API.Validators;
using Serilog;

namespace QuizMaster.API.Extensions;

/// <summary>
/// Configurations for the logging
/// </summary>
public static partial class ApplicationDependenciesConfiguration
{
    /// <summary>
    /// Configuring the logger
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IServiceCollection AddLogger(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .Enrich.WithEnvironmentName()
            .Enrich.WithMachineName();
        });

        return builder.Services;
    }

    /// <summary>
    /// Configurations for fluent validation
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddFluentValidationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<UserRegistrationRequestValidator>()
            .AddFluentValidationAutoValidation();
            //.AddFluentValidationServices();

        return services;
    }
}
