using Microsoft.Extensions.Logging;
using TaskManagementApi.Services.Domain;
using TaskManagementApi.Services.Domain.FilterStrategy;
using TaskManagementApi.Services.DomainObject;

namespace TaskManagementApi.Services.Utilities;

// Decorator Pattern
public class LoggingTaskServiceDecorator : ITaskService
{
  // Dependency Injection
  private readonly ITaskService _innerService;
  private readonly ILogger<LoggingTaskServiceDecorator> _logger;

  public LoggingTaskServiceDecorator(ITaskService innerService, ILogger<LoggingTaskServiceDecorator> logger)
  {
    _innerService = innerService;
    _logger = logger;
  }

  public async Task<IEnumerable<TaskItem>> GetAllTasks()
  {
    _logger.LogInformation("Getting all tasks.");
    return await _innerService.GetAllTasks();
  }

  public async Task<TaskItem> GetTaskById(int taskId)
  {
    _logger.LogInformation($"Getting task with ID: {taskId}.");
    return await _innerService.GetTaskById(taskId);
  }

  public async Task<TaskItem> AddTask(TaskItem task)
  {
    _logger.LogInformation($"Adding task: {task.Title}.");
    return await _innerService.AddTask(task);
  }

  public async Task<TaskItem> UpdateTask(int id, TaskItem task)
  {
    _logger.LogInformation($"Updating task with ID: {id}.");
    return await _innerService.UpdateTask(id, task);
  }

  public async Task DeleteTask(int id)
  {
    _logger.LogInformation($"Deleting task with ID: {id}.");
    await _innerService.DeleteTask(id);
  }

  public async Task<IEnumerable<TaskItem>> GetTasks(ITaskFilterStrategy filterStrategy)
  {
    _logger.LogInformation("Getting filtered tasks.");
    return await _innerService.GetTasks(filterStrategy);
  }
}

