using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Enums;

namespace ToDoApp.Domain.Entities;

public class TodoList
{
	public Guid ID { get; set; }
	[StringLength(50, ErrorMessage ="Lenght can not me more than 50")]
	[Required(ErrorMessage ="Title can not be null")]
	public required string Title { get; set; }
	[StringLength(50)]
	public string? UserName { get; set; }
	public DateTime CreatedDate { get; set; } = DateTime.Now;
	public DateTime ModifiedAt { get; set; } = DateTime.Now;
	public string? IconPath { get; set; }
	public ThemeColor? Theme { get; set; }
	public List<TodoItem> Items { get; set; } = new();


}
