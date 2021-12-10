using CarProject.Core.Model;

namespace CarProject.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context, IHostEnvironment environment)
        {
            string errorMessage = string.Empty;

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (ex is ApiException || environment.IsDevelopment())
                {
                    errorMessage = ex.Message;
                }
                else
                {
                    errorMessage = "Error";
                }

                context.Items.Add("exception", ex);
                context.Items.Add("exceptionMessage", $"{errorMessage} \n {ex.StackTrace}");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }

        }
    }
}
