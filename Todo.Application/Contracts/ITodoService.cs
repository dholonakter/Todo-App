using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Enums;

namespace Todo.Application.Contracts;

public interface ITodoService
{
	public void CreateANewList(int list_id, string Name);
	public void CreateANewGroup(int group_id, string Name);
	public void AddTodoItemTotheList(int list_id,TodoItem todoItem);
	public void UpdateTodoListName(int id, string name);
	public void UpdateItemtoList(int listID, int itemId, string itemName);
	public void DeleteTodoList(int id);
	public void DeleteTodoItem(int list_id, int item_id);

}
