﻿using System;
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

	private List<TodoList> _todolist=new List<TodoList>();
	private List<Group> _grouplist=new List<Group>();


	public void CreateANewList(int list_id, string Name)
	{
		TodoList list=new TodoList { ID= list_id, Title = Name,  };
		_todolist.Add(list);
	}

	public void CreateANewGroup(int group_id, string Name)
	{
		Group group = new Group { ID = group_id, Name = Name, };
	    _grouplist.Add(group);
	}
	public void AddListToAGroup(int group_id, int list_id)
	{
		Group found_group = null;
		foreach (var group in _grouplist)
		{
			if(group.ID == group_id)
			{
				found_group = group;

			}
		}
		if (found_group != null)
		{
			foreach (var list in found_group.TodoLists)
			{
				if (list.ID == list_id)
				{
					found_group.TodoLists.Add(list);
				}
			}
		}
		else
		{
			throw new NotImplementedException();

		}

	}

	public void AddTodoItemTotheList( int list_id,int id,string name, DateTime date_created, List<string> _steps, PriorityType? _priority, bool _isCompleted, bool _isImportant)
	{
		TodoList found_todolist = null;
		foreach (var list in _todolist)
		{
			if (list.ID == list_id)
			{
				found_todolist = list;
			}
		}
		if (found_todolist != null)
		{
			TodoItem item =new TodoItem { ID=id, Name=name, DateCreated=date_created, IsCompleted=_isCompleted, IsImportant=_isImportant};
			found_todolist.Items.Add(item);
		}
		else
		{
			throw new NotImplementedException();

		}

	}
	public void UpdateTodoListName(int list_id,string title)
	{
		TodoList found_todolist = null;
        foreach (var list in _todolist)
        {

			if (list.ID == list_id)
			{
				found_todolist = list;
			}
		}
		if (found_todolist != null)
		{
			found_todolist.Title = title;
		}
		else
		{
			throw new NotImplementedException();

		}
	}
	public void UpdateItemtoList(int list_id, int item_Id, string itemName)
	{
		TodoList found_todolist = null;
		foreach (var list in _todolist)
		{

			if (list.ID == list_id)
			{
				found_todolist = list;
			}
		}
		if (found_todolist != null)
		{
			foreach (var item in found_todolist.Items)
			{
				if (item.ID == item_Id)
				{
					item.Name = itemName;
				}
			}
		}
		else
		{
			throw new NotImplementedException();

		}
	}

	public void DeleteTodoList(int id)
	{
		TodoList found_todolist = null;
		foreach (var list in _todolist)
		{

			if (list.ID == id)
			{
				found_todolist = list;
			}
		}
		if (found_todolist != null)
		{
			_todolist.Remove(found_todolist);
		}
		else { throw new NotImplementedException(); }
	}
	public void DeleteTodoItem(int list_id, int item_id)
	{
		TodoList found_todolist = null;
		foreach (var list in _todolist)
		{

			if (list.ID == list_id)
			{
				found_todolist = list;
			}
		}
		if (found_todolist != null)
		{
			foreach (var item in found_todolist.Items)
			{
				if (item.ID == item_id)
				{
					found_todolist.Items.Remove(item);
				}
			}
		}
		else
		{
			throw new NotImplementedException();

		}

	}



}
