using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Contracts;
using Todo.Application.Services;
using ToDoApp.Domain.Entities;

namespace TodoApp.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoItemsController : ControllerBase
	{
		private readonly ITodoService _todoService;
		public TodoItemsController(ITodoService todoService)
		{
			_todoService = todoService;
		}

		[HttpPost("api/todo")]
		public IActionResult PostTodoList(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return BadRequest("Name can not be empty");
			}
			else
			{
				_todoService.CreateANewList(name);

				return Ok("TodoList created successfully.");
			}

		}


		[HttpPost("api/group")]
		public IActionResult PostNewGroup(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return BadRequest("Name can not be empty");

			}
			else
			{
				_todoService.CreateANewGroup(name);
				return Ok("Group created successfully.");
			}

		}

		[HttpGet("api/todo")]
		public ActionResult<List<TodoList>> GetList()
		{
			var lists = _todoService.GetAllList();
			if(lists==null || !lists.Any())
			{
				return NoContent();
			}
			return Ok(lists);
		}


		[HttpDelete("api/todo/{id}")]
		public IActionResult DeletedList([FromRoute] Guid id)
		{
			if (id==Guid.Empty)
			{
				return BadRequest("Invalid ID");
			}
			_todoService.DeleteTodoList(id);
			return Ok("deleted list successfully.");

		}
	}
}
