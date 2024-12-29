using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using ToDoApp.Domain.Enums;

namespace ToDoApp.Domain.Entities
{
	public class TodoItem
	{
		public int ID { get; set; }
		public required string Name { get; set; }
		public DateOnly DateCreated { get; set; }
		public List<string>? Steps { get; set; }
		public PriorityType? Priority { get; set; }
		public bool IsCompleted { get; set; }
        public bool IsImportant { get; set; }
        public int TodoListId { get; set; }
        public TodoList TodoList { get; set; }
    }
}
