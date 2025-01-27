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
		[HttpPost("PostTodoList")]
		public void PostTodoList(string name)
		{
			try
			{
				_todoService.CreateANewList(name);
				Ok("TodoList created successfully.");
			}
			catch (Exception ex)
			{
				BadRequest(ex.Message);
			}
		}
		[HttpPost("PostNewGroup")]
		public void PostNewGroup(string name)
		{
			try
			{
				_todoService.CreateANewGroup(name);
				Ok("Group created successfully.");
			}
			catch (Exception ex)
			{
				BadRequest(ex.Message);
			}
		}

		[HttpGet]
		public List<TodoList> GetList()
		{
			try
			{
				var lists = _todoService.GetAllList();
				return lists;
			}

			catch (Exception ex)
			{
				return new List<TodoList>();
			}
		}


		[HttpDelete]
		public void deletelist(int id)
		{
			try
			{
				_todoService.DeleteTodoList(id);
				Ok("deleted list successfully.");
			}
			catch (Exception ex)
			{
				BadRequest(ex.Message);
			}
		}
	}
}
