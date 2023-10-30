using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApi.Services.DomainObject;

namespace TaskManagementApi.Infra;
public interface ITaskRepository
{
  Task<IEnumerable<TaskItem>> GetAllTasks();

  // Signature of other repository methods similarly
}
