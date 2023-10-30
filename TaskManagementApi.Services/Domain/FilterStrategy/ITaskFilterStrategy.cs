using TaskManagementApi.Services.DomainObject;

namespace TaskManagementApi.Services.Domain.FilterStrategy;
public interface ITaskFilterStrategy
{
  IEnumerable<TaskItem> FilterTasks(IEnumerable<TaskItem> tasks);
}

