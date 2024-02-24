#region
using QuizMaster.API.Extensions;
using QuizMaster.API.Middlewares;
using QuizMaster.BusinessLogic.Services.Implementations;
using QuizMaster.BusinessLogic.Services.Interfaces;
using QuizMaster.DataAccess.Repositories.Implementations;
using QuizMaster.DataAccess.Repositories.Interfaces;
#endregion
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.ConfigureServices()
    .AddServiceCollectionExtensions();

var app = builder.Build();



    app.UseSwagger();
    app.UseSwaggerUI();


// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseCors("any");

await app.Configure();

app.UseAuthorization();

app.MapControllers();

app.Run();
