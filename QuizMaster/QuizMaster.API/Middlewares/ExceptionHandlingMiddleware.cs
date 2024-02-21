using QuizMaster.API.Models;
using QuizMaster.BusinessLogic.Exceptions;

namespace QuizMaster.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private async Task HandleException(HttpContext context, Exception ex, int statusCode)
        {
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(new Error()
            {
                Message = ex.Message,
                Status = statusCode
            });
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(NotFoundException ex)
            {
                await HandleException(context, ex, StatusCodes.Status404NotFound);
            }
            catch (AlreadyExistsException ex)
            {
                await HandleException(context, ex, StatusCodes.Status409Conflict);
            }
            catch(Exception ex)
            {
                await HandleException(context, ex, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
