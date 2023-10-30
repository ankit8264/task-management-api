using TaskManagementApi.Services.DomainObject;

namespace TaskManagementApi.Services.Domain.FilterStrategy;

//Strategy Pattern
public class CompletedTaskFilterStrategy : ITaskFilterStrategy
{
  public IEnumerable<TaskItem> FilterTasks(IEnumerable<TaskItem> tasks)
  {
    return tasks.Where(task => task.IsDone);
  }
}
