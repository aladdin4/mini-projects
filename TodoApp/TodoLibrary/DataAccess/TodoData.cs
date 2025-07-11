﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoLibrary.Models;

namespace TodoLibrary.DataAccess;

public class TodoData : ITodoData
{
    private readonly ISqlDataAccess _sql;
    public TodoData(ISqlDataAccess sql)      //we must register this in the DI to receive this one, right??
                                             //Yes, but first we need to create the interface
    {
        _sql = sql;
    }

    public Task<List<TodoModel>> GetAllAssigned(int assignedTo)
    {
        return _sql.LoadData<TodoModel, dynamic>("dbo.spTodos_GetAllAssigned", new { AssignedTo = assignedTo }, "Default");
    }
    public async Task<TodoModel?> GetOneAssigned(int assignedTo, int todoId)
    {
        var result = await _sql.LoadData<TodoModel, dynamic>("dbo.spTodos_GetOneAssigned", new { AssignedTo = assignedTo, TodoId = todoId }, "Default");
        return result.FirstOrDefault();
    }

    public async Task<TodoModel?> Create(int assignedTo, string task)
    {
        var result = await _sql.LoadData<TodoModel, dynamic>("dbo.spTodos_Create", new { Task = task, AssignedTo = assignedTo }, "Default");
        return result.FirstOrDefault();
    }

    public Task UpdateTask(string Task, int assignedTo, int todoId)
    {
        return _sql.SaveData<dynamic>("dbo.spTodos_UpdateTask", new { Task = Task, AssignedTo = assignedTo, TodoId = todoId }, "Default");
    }

    public Task CompleteTodo(int assignedTo, int todoId)
    {
        return _sql.SaveData<dynamic>("dbo.spTodos_CompleteTodo", new { AssignedTo = assignedTo, TodoId = todoId }, "Default");
    }

    public Task DeleteTodo(int assignedTo, int todoId)
    {
        return _sql.SaveData<dynamic>("dbo.spTodos_Delete", new { TodoId = todoId, AssignedTo = assignedTo }, "Default");
    }

}
