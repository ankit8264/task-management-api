using TaskManagementApi.Services.Domain.FilterStrategy;
using TaskManagementApi.Services.DomainObject;

namespace TaskManagementApi.Services.Domain;

public interface ITaskService
{
  Task<IEnumerable<TaskItem>> GetAllTasks();
  Task<IEnumerable<TaskItem>> GetTasks(ITaskFilterStrategy filterStrategy);
  Task<TaskItem> GetTaskById(int id);
  Task<TaskItem> AddTask(TaskItem task);
  Task<TaskItem> UpdateTask(int id, TaskItem task);
  Task DeleteTask(int id);
}
