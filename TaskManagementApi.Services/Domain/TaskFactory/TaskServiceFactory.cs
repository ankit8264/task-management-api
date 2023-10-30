using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TaskManagementApi.Services.Utilities;

namespace TaskManagementApi.Services.Domain.TaskFactory;

//Factory Pattern
public class TaskServiceFactory : ITaskServiceFactory
{
  private readonly IServiceProvider _serviceProvider;

  public TaskServiceFactory(IServiceProvider serviceProvider)
  {
    _serviceProvider = serviceProvider;
  }

  public ITaskService CreateTaskService()
  {
    var innerService = _serviceProvider.GetRequiredService<ITaskService>();
    var logger = _serviceProvider.GetRequiredService<ILogger<LoggingTaskServiceDecorator>>();
    return new LoggingTaskServiceDecorator(innerService, logger);
  }
}
