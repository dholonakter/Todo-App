using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Enums;

namespace Todo.Application.Contracts;

public interface ITodoService
{
	public void CreateANewList(TodoList todoList);
	public void CreateANewGroup(Group group);
	public List<TodoList> GetAllList();
	public List<Group> GetAllGroups();
	public List<TodoItem> GetAllItems(Guid list_id);
	public void AddTodoItemTotheList(Guid list_id, TodoItem todoItem);
	public void UpdateTodoList(Guid Id, TodoList todoList);
	public void UpdateItemtoList(Guid listID, TodoItem todoItem);
	public void UpdateGroup(Guid group_id, Group group);
	public void DeleteTodoList(Guid id);
	public void DeleteTodoItem(Guid list_id, Guid item_id);
	public void DeletedGroup(Guid group_id);

}
