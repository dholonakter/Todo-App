using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using ToDoApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ToDoApp.Domain.Entities;

public class TodoItem
{
	public Guid ID { get; set; }
	[StringLength(50)]
	[Required(ErrorMessage ="Name can not be null")]
	public required string Name { get; set; }
	public DateTime DateCreated { get; set; } = DateTime.Now;
	public List<string>? Steps { get; set; }
	public PriorityType? Priority { get; set; }
	[DefaultValue(false)]
	public bool IsCompleted { get; set; }
	[DefaultValue(false)]
	public bool IsImportant { get; set; }
	public Guid TodoListId { get; set; }
}
