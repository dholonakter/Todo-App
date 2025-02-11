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
				return BadRequest();
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
			if (!string.IsNullOrEmpty(name))
			{
				_todoService.CreateANewGroup(name);
				return Ok("Group created successfully.");
			}
			else
			{
				return BadRequest();
			}

		}

		[HttpGet("api/todo")]
		public List<TodoList> GetList()
		{
			var lists = _todoService.GetAllList();
			return lists;
		}


		[HttpDelete("api/todo/{id}")]
		public void deletelist([FromRoute] int id)
		{
			if (id > 0)
			{
				_todoService.DeleteTodoList(id);
				Ok("deleted list successfully.");
			}
			{
				NoContent();
			}
		}
	}
}
