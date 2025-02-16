using Microsoft.EntityFrameworkCore;

namespace TaskManagerAPI.Controllers.Models {
    public class TaskContext : DbContext {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) {
        }

        public DbSet<TaskClass> TaskItems { get; set; } = null!;
    }
}
