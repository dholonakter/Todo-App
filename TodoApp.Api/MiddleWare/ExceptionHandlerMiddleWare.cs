using Microsoft.AspNetCore.Http;
using System.Net;

public class ExceptionHandlerMiddleWare
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionHandlerMiddleWare> _logger;

	public ExceptionHandlerMiddleWare(RequestDelegate next, ILogger<ExceptionHandlerMiddleWare> logger)
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
		_logger.LogWarning(ex, "Handled exception, continuing...");

		switch (ex)
		{
			case KeyNotFoundException:
				context.Response.StatusCode = StatusCodes.Status404NotFound;
				await context.Response.WriteAsync(ex.Message);
				break;
			case ArgumentNullException:
				context.Response.StatusCode = StatusCodes.Status400BadRequest;
				await context.Response.WriteAsync($"{ex.Message}");
				break;
			default:
				_logger.LogError(ex, "An unexpected error occured");
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync("{\"message\": \"An internal server error occurred.\"}");
				break;
		}
	}
}
