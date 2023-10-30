using TaskManagementApi.Services.Domain.FilterStrategy;
using TaskManagementApi.Services.DomainObject;

namespace TaskManagementApi.Services.Domain;
public class TaskService : ITaskService
{
  private readonly List<TaskItem> _tasks;

  public TaskService(ITaskFilterStrategy filterStrategy)
  {
    _tasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Title = "Task 1", IsDone = false },
            new TaskItem { Id = 2, Title = "Task 2", IsDone = true }
        };
  }

  public async Task<IEnumerable<TaskItem>> GetAllTasks()
  {
    return await Task.FromResult(_tasks);
  }

  public async Task<IEnumerable<TaskItem>> GetTasks(ITaskFilterStrategy filterStrategy)
  {
    //Strategy Pattern
    var tasks = await GetAllTasks();
    return filterStrategy.FilterTasks(tasks);
  }

  public async Task<TaskItem> GetTaskById(int id)
  {
    return await Task.FromResult(_tasks.FirstOrDefault(t => t.Id == id)!);
  }

  public async Task<TaskItem> AddTask(TaskItem task)
  {
    task.Id = _tasks.Max(t => t.Id) + 1;
    _tasks.Add(task);
    return await Task.FromResult(task);
  }

  public async Task<TaskItem> UpdateTask(int id, TaskItem task)
  {
    var existingTask = _tasks.FirstOrDefault(t => t.Id == id);
    if (existingTask != null)
    {
      existingTask.Title = task.Title;
      existingTask.IsDone = task.IsDone;
    }
    return await Task.FromResult(existingTask!);
  }

  public async Task DeleteTask(int id)
  {
    var taskToRemove = _tasks.FirstOrDefault(t => t.Id == id);
    if (taskToRemove != null)
    {
      _tasks.Remove(taskToRemove);
    }
    await Task.CompletedTask;
  }
}
