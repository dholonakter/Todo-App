using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Contracts;
using Todo.Application.Services;
using ToDoApp.Domain.Entities;

namespace TodoApp.Api.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]

	[ApiController]
	public class TodoController : ControllerBase
	{
		private readonly ITodoService _todoService;
		public TodoController(ITodoService todoService)
		{
			_todoService = todoService;
		}
		/// <summary>
		/// Creates a TodoList
		/// </summary>
		/// <param name="todoList"></param>
		/// <returns></returns>
		/// <response code="201">Returns the newly created list</response>
		/// <response code="400">If the list is null</response>

		[HttpPost]
		[ProducesResponseType(statusCode: StatusCodes.Status201Created)]
		[ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
		public IActionResult PostTodoList(TodoList todoList)
		{
			_todoService.CreateANewList(todoList);
			return CreatedAtAction(nameof(GetList), new { id = todoList.ID }, todoList);
		}

		/// <summary>
		/// Update a TodoList
		/// </summary>
		/// <param name="todoList"></param>
		/// <returns></returns>

		[HttpPut]
		[ProducesResponseType(statusCode: StatusCodes.Status200OK)]
		public IActionResult UpdateList(TodoList todoList)
		{
			_todoService.UpdateTodoList(todoList);
			return Ok();
		}
		/// <summary>
		/// Read Todolist
		/// </summary>
		/// <returns></returns>

		[HttpGet]
		[ProducesResponseType(statusCode: StatusCodes.Status200OK)]
		[ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]

		public ActionResult<List<TodoList>> GetList()
		{
			var lists = _todoService.GetAllList();
			if (lists == null || !lists.Any())
			{
				return NoContent();
			}
			return Ok(lists);
		}
		/// <summary>
		///Deletes a specific TodoItem.
		/// </summary>
		/// <param name="list_id"></param>
		/// <param name="todoItem"></param>
		/// <returns></returns>
		[HttpDelete("{list_id}")]
		[ProducesResponseType(statusCode: StatusCodes.Status200OK)]
		[ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
		public IActionResult DeletedItem([FromRoute] Guid list_id, TodoItem todoItem)
		{
			_todoService.DeleteTodoItem(list_id, todoItem);
			return Ok();
		}

		/// <summary>
		/// Add an item to the TodoList
		/// </summary>
		/// <param name="listId"></param>
		/// <param name="item"></param>
		/// <returns></returns>
		/// <response code="201">Returns the newly created item</response>
		/// <response code="400">If the item is null</response>
		/// <response code="404">If the item is not found</response>
		[HttpPatch("item/{listId}")]
		[ProducesResponseType(statusCode: StatusCodes.Status200OK)]
		[ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
		[ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
		public IActionResult PostItem(Guid listId, [FromBody] TodoItem item)
		{
			item.TodoListId = listId;
			_todoService.AddTodoItemTotheList(listId, item);
			return Ok("A item has been added to the list");
		}

		[HttpPut("Item")]
		[ProducesResponseType(statusCode: StatusCodes.Status200OK)]
		[ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]

		public IActionResult UpdateItem(Guid list_id, TodoItem item)
		{
			_todoService.UpdateItemtoList(list_id, item);
			return Ok();
		}


		///Remarks
		/// <summary>
		///Deletes a specific Todolist.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		///<response code="200">Returns the requested item</response>
		///<response code="404">If the item is not found</response>

		[HttpDelete("{id}")]
		[ProducesResponseType(statusCode: StatusCodes.Status200OK)]
		[ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
		public IActionResult DeletedList([FromRoute] Guid id)
		{
			_todoService.DeleteTodoList(id);
			return Ok("deleted list successfully.");

		}


	}
}
