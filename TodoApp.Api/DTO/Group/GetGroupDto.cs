using System.ComponentModel.DataAnnotations;
using TodoApp.Api.DTO.TodoListDto;
using ToDoApp.Domain.Entities;

namespace TodoApp.Api.DTO.Group;

public class GetGroupDto
{
	public Guid ID { get; set; }
	[StringLength(50)]
	[Required(ErrorMessage = "Name can not be null")]
	public required string Name { get; set; }
	public DateTime DateCreated { get; set; } = DateTime.Now;
	public DateTime ModifiedAt { get; set; } = DateTime.Now;
	public List<GetTodolistDto> TodoLists { get; set; } = new();
}
