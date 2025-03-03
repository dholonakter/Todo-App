using System.ComponentModel.DataAnnotations;
using TodoApp.Api.DTO.TodoItemDto;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Enums;

namespace TodoApp.Api.DTO.TodoListDto;

public class GetTodolistDto
{
	public Guid ID { get; set; }
	[StringLength(50, ErrorMessage = "Lenght can not me more than 50")]
	[Required(ErrorMessage = "Title can not be null")]
	public required string Title { get; set; }
	[StringLength(50)]
	public string? UserName { get; set; }
	public string? IconPath { get; set; }
	public ThemeColor? Theme { get; set; }
	public List<GetTodoItemDto> Items { get; set; } = new();
}
