using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Entities
{
    public class TodoList
    {
		public int ID { get; set; }
		public required string Title { get; set; }
		public string? UserName { get; set; }
		public int UserID { get; set; }
		public DateTime Created_Date { get; set; }
		public List<TodoItem> Items { get; set; } = new();
	}
}
