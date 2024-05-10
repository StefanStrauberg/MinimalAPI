using Microsoft.EntityFrameworkCore;

namespace TodoAPI;

public class TodoDb(DbContextOptions<TodoDb> options) : DbContext(options)
{
  public DbSet<TodoItem> Todos { get; set; }
}
