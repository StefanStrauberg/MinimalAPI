using Bogus;
using Microsoft.EntityFrameworkCore;

namespace TodoAPI;

public class DbInitializer
{
  public static void Seed(IServiceProvider serviceProvider)
  {
    using var context = new TodoDb(serviceProvider.GetRequiredService<DbContextOptions<TodoDb>>());
    context.Todos.AddRange(GenerateFakeData());
    context.SaveChanges();
  }

  private static List<TodoItem> GenerateFakeData()
  {
    int todoId = 0;
    var fakeSimpleTodos = new Faker<TodoItem>()
      .RuleFor(x => x.Id, f => ++todoId)
      .RuleFor(x => x.Name, f => f.Name.JobArea())
      .RuleFor(x => x.IsComplete, f => f.Random.Bool());
    var todos = fakeSimpleTodos.Generate(5);
    return todos;
  }
}
