using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ToDoApp.Domain.Enums;

namespace TodoApp.Api.DTO.TodoItemDto;

public class UpdateTodoItemDto
{
	[StringLength(50)]
	[Required(ErrorMessage = "Name can not be null")]
	public required string Name { get; set; }
	[Required]
	public DateTime DueDate { get; set; }
	public List<string>? Steps { get; set; }
	public PriorityType? Priority { get; set; }
	[DefaultValue(false)]
	public bool IsCompleted { get; set; }
	[DefaultValue(false)]
	public bool IsImportant { get; set; }
}
