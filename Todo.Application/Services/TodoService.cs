using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Todo.Application.Contracts;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Enums;

namespace Todo.Application.Services;

public class TodoService : ITodoService
{

	private List<TodoList> _todolist = new List<TodoList>();
	private List<Group> _grouplist = new List<Group>();


	public void CreateANewList(TodoList todolist)
	{
		todolist = new TodoList() { ID = Guid.NewGuid(), Title = todolist.Title };
		_todolist.Add(todolist);
	}


	public void CreateANewGroup(Group group)
	{
		group = new Group() { ID = Guid.NewGuid(), Name = group.Name };
		_grouplist.Add(group);
	}

	public List<TodoList> GetAllList()
	{
		return _todolist;
	}
	public List<Group> GetAllGroups()
	{
		return _grouplist;
	}

	public void AddListToAGroup(Guid group_id, Guid list_id)
	{
		var found_group = _grouplist.FirstOrDefault(x => x.ID == group_id);

		if (found_group != null)
		{
			var list = _todolist.FirstOrDefault(x => x.ID == list_id);
			if (list != null)
			{
				found_group.TodoLists.Add(list);

			}
		}
		else
		{
			throw new KeyNotFoundException("Group with ID" + group_id + "not found");

		}

	}

	public void AddTodoItemTotheList(Guid list_id, TodoItem todoItem)
	{
		if (todoItem == null)
		{
			throw new ArgumentNullException(nameof(todoItem), "TodoItem can not be null");

		}
		var found_todolist = _todolist.FirstOrDefault(x => x.ID == list_id);

		if (found_todolist != null)
		{
			todoItem.ID = Guid.NewGuid();
			found_todolist.Items.Add(todoItem);
		}
		else
		{
			throw new KeyNotFoundException("TodoList with ID" + list_id + "not found");

		}

	}
	public void UpdateTodoList(TodoList todoList)
	{

		var found_todolist = _todolist.FirstOrDefault(x => x.ID == todoList.ID);

		if (found_todolist != null)
		{
			found_todolist = todoList;
		}
		else
		{
			throw new KeyNotFoundException("TodoList with ID" + todoList.ID + "not found");

		}
	}
	public void UpdateItemtoList(Guid list_id, TodoItem todoItem)
	{
		if (todoItem == null)
		{
			throw new ArgumentNullException(nameof(todoItem), "TodoItem can not be null");

		}
		var found_todolist = _todolist.FirstOrDefault(x => x.ID == list_id);

		if (found_todolist != null)
		{
			var getItem = found_todolist.Items.Find(x => x.ID == todoItem.ID);
			if (getItem != null)
			{
				getItem.Name = todoItem.Name;

			}
		}
		else
		{
			throw new KeyNotFoundException("TodoList with ID" + list_id + "not found");

		}
	}
	public void UpdateGroup(Guid group_id, Group group)
	{
		var found_group = _grouplist.Find(x => x.ID == group_id);
		if (found_group != null)
		{
			found_group.Name = group.Name;
		}
		else
		{
			throw new KeyNotFoundException("Group with ID" + group.ID + "not found");

		}
	}

	public void DeleteTodoList(Guid id)
	{
		var found_todolist = _todolist.FirstOrDefault(x => x.ID == id);
		if (found_todolist != null)
		{
			_todolist.Remove(found_todolist);
		}
		else
		{
			throw new KeyNotFoundException("TodoList with ID" + id + " not found");
		}
	}
	public void DeletedGroup(Guid group_id)
	{
		var check_group = _grouplist.Find(x => x.ID == group_id);
		if (check_group != null)
		{
			var check_todo = check_group.TodoLists.Count() > 0;
			if (!check_todo)
			{
				_grouplist.Remove(check_group);

			}
			else
			{
				throw new Exception("There is a list in the group");
			}

		}
		else
		{
			throw new KeyNotFoundException("Group with ID" + group_id + " not found");
		}


	}
	public void DeleteTodoItem(Guid list_id, TodoItem todoItem)
	{
		if (todoItem == null)
		{
			throw new ArgumentNullException(nameof(todoItem), "TodoItem can not be null");

		}
		var found_todolist = _todolist.FirstOrDefault(x => x.ID == list_id);
		if (found_todolist != null)
		{
			var getItem = found_todolist.Items.Find(x => x.ID == todoItem.ID);
			if (getItem != null)
			{
				found_todolist.Items.Remove(getItem);

			}

		}
		else
		{
			throw new KeyNotFoundException("TodoList with ID" + list_id + "not found");

		}

	}



}
