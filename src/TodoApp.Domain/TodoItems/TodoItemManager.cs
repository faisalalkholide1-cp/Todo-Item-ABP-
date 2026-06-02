using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace TodoApp.TodoItems
{
    public class TodoItemManager : DomainService
    {
        private readonly ITodoItemRepository _todoItemRepository;
        
        public TodoItemManager(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<TodoItem> CreateAsync(string text)
        {
            Check.NotNullOrWhiteSpace(text, nameof(text));
            var existingTodoItem = await _todoItemRepository.FindByTextAsync(text);
            if(existingTodoItem != null)
            {
                throw new TodoItemAlreadyExistsException(text);
            }
            return new TodoItem(
                GuidGenerator.Create(),
                text
                );
        }

        public async Task ChangeTextAsync(TodoItem todoItem, string newText)
        {
            Check.NotNull(todoItem, nameof(todoItem));
            Check.NotNullOrWhiteSpace(newText, nameof(newText));
            var existingTodoItem = await _todoItemRepository.FindByTextAsync(newText);
            if(existingTodoItem != null && existingTodoItem.Id != todoItem.Id)
            {
                throw new TodoItemAlreadyExistsException(newText);
            }
            todoItem.ChangeText(newText);
        }
    }
}
