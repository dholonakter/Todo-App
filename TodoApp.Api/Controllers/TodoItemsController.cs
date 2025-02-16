using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Contracts;
using Todo.Application.Services;
using ToDoApp.Domain.Entities;

namespace TodoApp.Api.Controllers
{
	[Route("api/")]
	[ApiController]
	public class TodoItemsController : ControllerBase
	{
		private readonly ITodoService _todoService;
		public TodoItemsController(ITodoService todoService)
		{
			_todoService = todoService;
		}

		[HttpPost("todo")]
		public IActionResult PostTodoList(string name)
		{
			if (name == null)
			{
				return BadRequest("Name can not be empty");
			}
			else
			{

				_todoService.CreateANewList(name);
				return Ok("Todo List created successfully");

			}

		}


		[HttpPatch("additem/{listId}")]
		public IActionResult PostItem(Guid listId, [FromBody] TodoItem item)
		{
			if (item.Name == String.Empty)
			{
				return BadRequest("Name is required");
			}
			item.TodoListId = listId;
			_todoService.AddTodoItemTotheList(listId, item);
			return Ok("A item has been added to the list");
		}


		[HttpPost("group")]
		public IActionResult PostNewGroup(string name)
		{
			if (name is null)
			{
				return BadRequest("Name can not be empty");

			}
			else
			{
				_todoService.CreateANewGroup(name);
				return Ok("Group created successfully.");
			}

		}

		[HttpGet("todo")]
		public ActionResult<List<TodoList>> GetList()
		{
			var lists = _todoService.GetAllList();
			if (lists == null || !lists.Any())
			{
				return NoContent();
			}
			return Ok(lists);
		}


		[HttpDelete("todo/{id}")]
		public IActionResult DeletedList([FromRoute] Guid id)
		{
			if (id == Guid.Empty)
			{
				return BadRequest("Invalid ID");
			}
			_todoService.DeleteTodoList(id);
			return Ok("deleted list successfully.");

		}
	}
}
