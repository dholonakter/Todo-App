using System.ComponentModel.DataAnnotations;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Enums;

namespace TodoApp.Api.DTO.TodoListDto;

public class CreateTodoInputDto
{
    [StringLength(50, ErrorMessage = "Lenght can not me more than 50")]
    [Required(ErrorMessage = "Title can not be null")]
    public required string Title { get; set; }
    [StringLength(50)]
    public string? UserName { get; set; }
    public string? IconPath { get; set; }
    public ThemeColor? Theme { get; set; }
}
