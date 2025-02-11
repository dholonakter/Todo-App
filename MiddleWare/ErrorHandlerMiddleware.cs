using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace MiddleWare
{
	public class ErrorHandlerMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ErrorHandlerMiddleware> _logger;

		public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
		{
			_next = next;
			_logger = logger;

		}
		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}
		private async Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			_logger.LogError(ex, "An uxpected error occured");
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			context.Response.ContentType = "application/json";
			await context.Response.WriteAsync("{\"message\": \"An internal server error occurred.\"}");
		}

	}
}
