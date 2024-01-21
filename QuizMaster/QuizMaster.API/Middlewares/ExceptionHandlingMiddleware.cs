using QuizMaster.BusinessLogic.Exceptions;

namespace QuizMaster.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                }
                else if (ex is AlreadyExistsException)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                }
                else if (ex is Exception)
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                }
            }

        }
    }
}
