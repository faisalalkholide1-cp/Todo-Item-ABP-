using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace TodoApp.TodoItems
{
    public interface ITodoAppService : IApplicationService
    {
        Task<List<TodoItemDto>> GetListAsync();
        Task<TodoItemDto> CreateAsync(CreateTodoDto input);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Guid id, CreateTodoDto input);
    }
}
