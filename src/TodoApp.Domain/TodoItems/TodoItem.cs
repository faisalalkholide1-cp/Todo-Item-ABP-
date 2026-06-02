using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace TodoApp.TodoItems
{
    public class TodoItem : AggregateRoot<Guid>
    {
        public string Text { get; private set;} = string .Empty;

        internal TodoItem( Guid id , string text):base(id) {
            SetText(text);
        }
        internal TodoItem ChangeText(string text)
        {
            SetText(text);
            return this;
        }
        private void SetText(string text)
        {
            Text = Check.NotNullOrWhiteSpace(
                text, 
                nameof(text), 
                maxLength: TodoItemConsts.MaxTextLengh);
        }
    }
}
