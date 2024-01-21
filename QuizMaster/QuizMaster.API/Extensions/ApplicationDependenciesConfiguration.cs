using Microsoft.EntityFrameworkCore;
using QuizMaster.BusinessLogic.Profiles.MappingConfigurations;
using QuizMaster.BusinessLogic.Services.Implementations;
using QuizMaster.BusinessLogic.Services.Interfaces;
using QuizMaster.DataAccess;
using QuizMaster.DataAccess.Repositories.Implementations;
using QuizMaster.DataAccess.Repositories.Interfaces;

namespace QuizMaster.API.Extensions;

/// <summary>
/// Configuration of all the services of the API
/// </summary>
public static partial class ApplicationDependenciesConfiguration
{
    public static IServiceCollection ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.AddJwtToken();

        builder.AddLogger();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("QuizMasterConnection"));
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        })
    
            .AddSwaggerGen()
            .AddJwtAuthenticationAndAuthorization()
            .AddFluentValidationServices()
            .AddAutoMapper(typeof(ApplicationProfile));

        return builder.Services;
    }

    /// <summary>
    /// Adding all the middleware of the API
    /// </summary>
    /// <param name="app"></param>
    /// <returns>A <see cref="Task"/></returns>
    public async static Task Configure(this WebApplication app)
    {
        await app.UseMigration();

        app.UseAuthentication();
    }
 
    public static IServiceCollection AddServiceCollectionExtensions(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IAnswerOptionRepository, AnswerOptionRepository>();
        services.AddScoped<IAnswerOptionService, AnswerOptionService>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IQuizRepository, QuizRepository>();
        services.AddScoped<IQuizService, QuizService>();
        services.AddScoped<IUserQuizRepository, UserQuizRepository>();
        services.AddScoped<IUserQuizService, UserQuizService>();

        return services;
    }
}
