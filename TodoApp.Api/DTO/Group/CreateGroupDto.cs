using System.ComponentModel.DataAnnotations;
using ToDoApp.Domain.Entities;

namespace TodoApp.Api.DTO.Group;

public class CreateGroupDtocs
{
	[StringLength(50)]
	[Required(ErrorMessage = "Name can not be null")]
	public required string Name { get; set; }
}
