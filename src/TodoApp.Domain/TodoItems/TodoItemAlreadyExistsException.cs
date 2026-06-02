using System.Net;
using Volo.Abp;

namespace TodoApp.TodoItems
{
    public class TodoItemAlreadyExistsException : BusinessException
    {
        private readonly int HttpStatusCode;

        public TodoItemAlreadyExistsException(string text) : 
            base(TodoItemErrorCodes.TodoItemAlreadyExists)
        {
            WithData("text", text);
            HttpStatusCode = 422;
        }
    }
}
