using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Entities
{
	public class GroupList
	{
		public int ID { get; set; }
		public required string GroupName { get; set; }
		public List<TodoList> Lists { get; set; } = new();
	}
}
