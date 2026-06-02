using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Mapperly;

namespace TodoApp.TodoItems
{
    [Mapper]
    public partial class Mapper : MapperBase<TodoItem, TodoItemDto>
    {
        public override partial TodoItemDto Map(TodoItem source);


        public override partial void Map(TodoItem source, TodoItemDto destination);
        
    }
}
