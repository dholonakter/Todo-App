using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Enums;

namespace Todo.Application.Contracts;

public interface ITodoService
{
	public void CreateANewList(string Name);
	public void CreateANewGroup(string Name);
	public List<TodoList> GetAllList();
	public List<Group> GetAllGroups();
	public void AddTodoItemTotheList(Guid list_id,TodoItem todoItem);
	public void UpdateTodoListName(Guid id, string name);
	public void UpdateItemtoList(Guid listID, Guid itemId, string itemName);
	public void DeleteTodoList(Guid id);
	public void DeleteTodoItem(Guid list_id, Guid item_id);

}
