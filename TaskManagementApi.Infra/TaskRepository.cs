using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApi.Services.DomainObject;

namespace TaskManagementApi.Infra;
public class TaskRepository : ITaskRepository
{
  private readonly TaskDbContext _dbContext;

  public TaskRepository(TaskDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<IEnumerable<TaskItem>> GetAllTasks()
  {
    return await _dbContext.Tasks.ToListAsync();
  }

  // Implement other repository methods similarly
}
