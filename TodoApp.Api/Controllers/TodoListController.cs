using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Contracts;
using TodoApp.Api.DTO.TodoListDto;
using ToDoApp.Domain.Entities;

namespace TodoApp.Api.Controllers;

[Route("api/[controller]")]
[Produces("application/json")]

[ApiController]
public class TodoListController : ControllerBase
{
	private readonly ITodoService _todoService;
	public TodoListController(ITodoService todoService)
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
	public IActionResult PostTodoList(CreateTodoInputDto todoList)
	{
		var list = new TodoList
		{
			ID = Guid.NewGuid(),
			Title = todoList.Title,
			Theme = todoList.Theme,
			IconPath = todoList.IconPath,
			UserName = todoList.UserName
		};
		_todoService.CreateANewList(list);
		return CreatedAtAction(nameof(GetList), todoList);
	}

	/// <summary>
	/// Update a TodoList
	/// </summary>
	/// <param name="todoList"></param>
	/// <returns></returns>

	[HttpPut("id")]
	[ProducesResponseType(statusCode: StatusCodes.Status200OK)]
	public IActionResult UpdateList(Guid id, [FromBody] UpdateTodoListDto updatelist)
	{
		var list = new TodoList
		{
			ID = id,
			Title = updatelist.Title,
			Theme = updatelist.Theme,
			IconPath = updatelist.IconPath,
			UserName = updatelist.UserName
		};
		_todoService.UpdateTodoList(id, list);
		return Ok("List has been updated");
	}
	/// <summary>
	/// Read Todolist
	/// </summary>
	/// <returns></returns>

	[HttpGet]
	[ProducesResponseType(statusCode: StatusCodes.Status200OK)]
	[ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]

	public ActionResult<List<GetTodolistDto>> GetList()
	{
		var lists = _todoService.GetAllList();
		if (lists == null || !lists.Any())
		{
			return NoContent();
		}
		var result = lists.Select(l => new GetTodolistDto
		{
			ID = l.ID,
			Title = l.Title,
			Theme = l.Theme,
			IconPath = l.IconPath,
			UserName = l.UserName
		});

		return Ok(result);
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
