using System.CodeDom;

namespace TodoApp.Permissions;

public static class TodoAppPermissions
{
    public const string GroupName = "TodoApp";


    
    public static class TodoItems
    {
        public const string Default = GroupName + ".TodoItems";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
