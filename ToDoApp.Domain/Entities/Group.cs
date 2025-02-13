using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Entities;

public class Group
{
	public Guid ID { get; set; }
	public required string Name { get; set; }
	public List<TodoList> TodoLists { get; set; } = new();

}
