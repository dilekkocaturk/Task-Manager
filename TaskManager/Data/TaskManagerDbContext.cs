using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Data
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>().ToTable("TaskModels");
        }

        public static void Initialize(TaskManagerDbContext context)
        {
            if (!context.Tasks.Any())
            {
                var tasks = new List<TaskModel>
        {
            new TaskModel {
                Title = "Daily report preparation",
                Description = "Collect and analyze data for daily work reports",
                Assignee = "John Smith",
                Creator = "Emily Johnson",
                CreatedAt = DateTime.Now.AddDays(-1),
                UpdatedAt = DateTime.Now.AddDays(-1).AddHours(4),
                IsCompleted = true
            },
            new TaskModel {
                Title = "Weekly meeting preparation",
                Description = "Prepare presentation materials for the weekly meeting",
                Assignee = "Emily Johnson",
                Creator = "John Smith",
                CreatedAt = DateTime.Now.AddDays(-3),
                UpdatedAt = DateTime.Now.AddDays(-2).AddHours(2),
                IsCompleted = true
            },
            new TaskModel {
                Title = "Monthly performance report analysis",
                Description = "Review and analyze the performance report of the previous month",
                Assignee = "John Smith",
                Creator = "Emily Johnson",
                CreatedAt = DateTime.Now.AddDays(-10),
                UpdatedAt = DateTime.Now.AddDays(-9).AddHours(6),
                IsCompleted = true
            }
        };

                context.Tasks.AddRange(tasks);
                context.SaveChanges();
            }
        }
    }
}