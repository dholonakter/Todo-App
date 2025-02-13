using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Contracts;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Enums;

namespace Todo.Application.Services;

public class TodoService : ITodoService
{

	private List<TodoList> _todolist = new List<TodoList>()
	{
		new TodoList{ID=Guid.NewGuid(),Title="p"},
		new TodoList {ID=Guid.NewGuid(),Title="px"}
	};
	private List<Group> _grouplist = new List<Group>();

	

	public void CreateANewList(string Name)
	{
		TodoList list = new TodoList { ID =Guid.NewGuid() , Title = Name };
		_todolist.Add(list);
	}


	public void CreateANewGroup(string Name)
	{
		Group group = new Group { ID=Guid.NewGuid(), Name = Name };
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
			throw new Exception("Group with ID" + group_id + "not found");

		}

	}

	public void AddTodoItemTotheList(Guid list_id, TodoItem todoItem)
	{
		var found_todolist = _todolist.FirstOrDefault(x => x.ID == list_id);

		if (found_todolist != null)
		{
			found_todolist.Items.Add(todoItem);
		}
		else
		{
			throw new Exception("TodoList with ID" + list_id + "not found");

		}

	}
	public void UpdateTodoListName(Guid list_id, string title)
	{
		var found_todolist = _todolist.FirstOrDefault(x => x.ID == list_id);

		if (found_todolist != null)
		{
			found_todolist.Title = title;
		}
		else
		{
			throw new Exception("TodoList with ID" + list_id + "not found");

		}
	}
	public void UpdateItemtoList(Guid list_id, Guid item_Id, string itemName)
	{
		var found_todolist = _todolist.FirstOrDefault(x => x.ID == list_id);

		if (found_todolist != null)
		{
			var getItem = found_todolist.Items.Find(x => x.ID == item_Id);
			if (getItem != null)
			{
				getItem.Name = itemName;

			}
		}
		else
		{
			throw new Exception("TodoList with ID" + list_id + "not found");

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
			throw new Exception("TodoList with ID" + id + " not found");
		}
	}
	public void DeleteTodoItem(Guid list_id, Guid item_id)
	{
		var found_todolist = _todolist.FirstOrDefault(x => x.ID == list_id);
		if (found_todolist != null)
		{
			var getItem = found_todolist.Items.Find(x => x.ID == item_id);
			if (getItem != null)
			{
				found_todolist.Items.Remove(getItem);

			}

		}
		else
		{
			throw new Exception("TodoList with ID" + list_id + "not found");

		}

	}



}
