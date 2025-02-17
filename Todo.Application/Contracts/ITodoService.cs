using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Enums;

namespace Todo.Application.Contracts;

public interface ITodoService
{
	public void CreateANewList(string name);
	public void CreateANewGroup(string name);
	public List<TodoList> GetAllList();
	public List<Group> GetAllGroups();
	public void AddTodoItemTotheList(Guid list_id, TodoItem todoItem);
	public void UpdateTodoList(Guid id, string name);
	public void UpdateItemtoList(Guid listID, TodoItem todoItem);
	public void DeleteTodoList(Guid id);
	public void DeleteTodoItem(Guid list_id, TodoItem todoItem);

}
