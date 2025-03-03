using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Entities;

public class Group
{
	public Guid ID { get; set; }
	[StringLength(50)]
	[Required(ErrorMessage = "Name can not be null")]
	public required string Name { get; set; }
	public DateTime CreatedDate { get; set; } = DateTime.Now;
	public DateTime ModifiedAt { get; set; } = DateTime.Now;
	public List<TodoList> TodoLists { get; set; } = new();

}
