using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Todo.Application.Contracts;
using TodoApp.Api.DTO.TodoItemDto;
using TodoApp.Application.DTO.TodoItemDto;
using ToDoApp.Domain.Entities;

namespace TodoApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoItemController : ControllerBase
{
	private readonly ITodoService _todoService;
	public TodoItemController(ITodoService todoService)
	{
		_todoService = todoService;
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
	[HttpPatch("{listId}")]
	[ProducesResponseType(statusCode: StatusCodes.Status201Created)]
	[ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
	public IActionResult PostItem(Guid listId, [FromBody] CreateTodoItemInputDto createItem)
	{

		var item = new TodoItem
		{
			ID = Guid.NewGuid(),
			Name = createItem.Name,
			IsCompleted = createItem.IsCompleted,
			IsImportant = createItem.IsImportant,
			Priority = createItem.Priority,
			DueDate = createItem.DueDate,
			Steps = createItem.Steps,
		};

		_todoService.AddTodoItemTotheList(listId, item);
		return Ok("A item has been added to the list");
	}




	/// <summary>
	/// 
	/// </summary>
	/// <param name="list_id"></param>
	/// <returns></returns>
	[HttpGet]
	[ProducesResponseType(statusCode: StatusCodes.Status200OK)]
	[ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
	[ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]

	public IActionResult GetItems(Guid list_id)
	{
		var items = _todoService.GetAllItems(list_id);
		if (items == null || !items.Any())
		{
			return NoContent();
		}
		var result = items.Select(item => new GetTodoItemDto
		{
			ID = item.ID,
			Name = item.Name,
			IsCompleted = item.IsCompleted,
			IsImportant = item.IsImportant,
			Priority = item.Priority,
			DueDate = item.DueDate,
			Steps = item.Steps,

		});
		if (result == null || !result.Any())
		{
			return NoContent();
		}

		return Ok(result);
	}


	[HttpPut]
	[ProducesResponseType(statusCode: StatusCodes.Status200OK)]
	[ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]

	public IActionResult UpdateItem(Guid list_id, UpdateTodoItemDto updateitem)
	{
		var item = new TodoItem
		{
			Name = updateitem.Name,
			IsCompleted = updateitem.IsCompleted,
			IsImportant = updateitem.IsImportant,
			Priority = updateitem.Priority,
			DueDate = updateitem.DueDate,
			Steps = updateitem.Steps,
		};
		_todoService.UpdateItemtoList(list_id, item);
		return Ok();
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
	public IActionResult DeletedItem([FromRoute] Guid list_id, Guid item_id)
	{
		_todoService.DeleteTodoItem(list_id, item_id);
		return Ok();
	}


}
