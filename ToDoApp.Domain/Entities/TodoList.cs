using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Enums;

namespace ToDoApp.Domain.Entities;

public class TodoList
{
	public int ID { get; set; }
	public required string Title { get; set; }
	public string? UserName { get; set; }
	public DateTime CreatedDate { get; set; } = DateTime.Now;
	public string? IconPath { get; set; }
	public ThemeColor? Theme { get; set; }
	public List<TodoItem> Items { get; set; } = new();


}
