using ErrorOr;

namespace FlowControlDemo.Domain.Common.Errors;

public static partial class Errors
{
    public static class TaskItem
    {
        public static Error DuplicateName => Error.Conflict(
            code: "TaskItem.DuplicateName",
            description: "Name already in use.");
    }
}