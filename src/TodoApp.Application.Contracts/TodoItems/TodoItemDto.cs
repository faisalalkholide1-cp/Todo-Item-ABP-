using System;

namespace TodoApp.TodoItems
{
    public class TodoItemDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;

    }
}
