using TodoApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace TodoApp.Permissions;

public class TodoAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TodoAppPermissions.GroupName,L("Permission:TodoItem"));

        var todoItems = myGroup.AddPermission(
            TodoAppPermissions.TodoItems.Default,L("Permission:TodoItems"));
        todoItems.AddChild(TodoAppPermissions.TodoItems.Create, L("Permission:TodoItems.Create"));
        todoItems.AddChild(TodoAppPermissions.TodoItems.Edit, L("Permission:TodoItems.Edit"));
        todoItems.AddChild(TodoAppPermissions.TodoItems.Delete, L("Permission:TodoItems.Delete"));

        //Define your own permissions here. Example:
        //myGroup.AddPermission(TodoAppPermissions.MyPermission1, L("Permission:MyPermission1"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TodoAppResource>(name);
    }
}
