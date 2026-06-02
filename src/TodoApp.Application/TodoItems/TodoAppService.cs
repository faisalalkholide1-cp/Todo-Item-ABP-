using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Permissions;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TodoApp.TodoItems
{
    public class TodoAppService : ApplicationService, ITodoAppService
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly TodoItemManager _todoItemManager;

        public TodoAppService(
            ITodoItemRepository todoItemRepository,
            TodoItemManager todoItemManager
            )
        {
            _todoItemRepository = todoItemRepository;
            _todoItemManager = todoItemManager;
        }

        [Authorize(TodoAppPermissions.TodoItems.Create)]
        public async Task<TodoItemDto> CreateAsync(CreateTodoDto input)
        {
            var todoItem = await _todoItemManager.CreateAsync(input.text);

            await _todoItemRepository.InsertAsync(todoItem);
            return ObjectMapper.Map<TodoItem, TodoItemDto>(todoItem);

        }
        [Authorize(TodoAppPermissions.TodoItems.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _todoItemRepository.DeleteAsync( id );
        }
        public async Task<List<TodoItemDto>> GetListAsync()
        {
            var items = await _todoItemRepository.GetListAsync();
            
            return ObjectMapper.Map<List<TodoItem>, List<TodoItemDto>>(items!);

        }
        [Authorize(TodoAppPermissions.TodoItems.Edit)]
        public async Task UpdateAsync(Guid id, CreateTodoDto input)
        {
            var todoItem = await _todoItemRepository.GetAsync(id);
            if (todoItem.Text != input.text)
            {
                await _todoItemManager.ChangeTextAsync(todoItem, input.text);

            }
            await _todoItemRepository.UpdateAsync(todoItem);
        }
    }
}
