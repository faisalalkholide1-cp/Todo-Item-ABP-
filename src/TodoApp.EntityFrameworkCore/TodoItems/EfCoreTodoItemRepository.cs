using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TodoApp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TodoApp.TodoItems
{
    public class EfCoreTodoItemRepository :EfCoreRepository<TodoAppDbContext, TodoItem, Guid>, ITodoItemRepository
    {
        public EfCoreTodoItemRepository(
            IDbContextProvider<TodoAppDbContext> dbContextProvider):
            base(dbContextProvider) { }

        public async Task<TodoItem> FindByTextAsync(string text)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(item => item.Text == text);
        }
    }
}
