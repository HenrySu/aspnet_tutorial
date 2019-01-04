using Microsoft.EntityFrameworkCore;

namespace webapi_spike.Models
{
    public class TodoContext:DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}