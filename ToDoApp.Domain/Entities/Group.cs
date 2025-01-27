using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Entities;

public class Group
{
	public int ID { get; set; }
	public required string Name { get; set; }
	private static int _id;
	public List<TodoList> TodoLists { get; set; } = new();
    public Group()
    {
		_id++;
		ID = _id;
    }
}
