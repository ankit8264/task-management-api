using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApi.Services.DomainObject;

namespace TaskManagementApi.Infra
{
  public class TaskDbContext : DbContext
  {
    public DbSet<TaskItem> Tasks { get; set; }

    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }
  }
}
