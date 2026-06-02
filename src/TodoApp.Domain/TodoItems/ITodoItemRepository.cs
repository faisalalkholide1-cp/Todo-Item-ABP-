using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TodoApp.TodoItems
{
    public interface ITodoItemRepository : IRepository<TodoItem, Guid>
    {
        Task<TodoItem> FindByTextAsync(string text);
    }
}
