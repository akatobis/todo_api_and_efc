using todoAPI.Application.Repositories;
using todoAPI.Models;

namespace todoAPI.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _dbContext;

        public TodoRepository( TodoDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public Todo GetTodoById( int id )
        {
            return _dbContext.Set<Todo>().FirstOrDefault(x => x.Id == id);
        }
        public void CreateTodo( Todo todo )
        {
            _dbContext.Set<Todo>().Add( todo );
        }

        public void DeleteTodoById( int id )
        {
            Todo todo = GetTodoById( id );

            if ( todo == null)
            {
                return;
            }

            _dbContext.Set<Todo>().Remove( todo );
        }

        public void CompleteTodo( int id )
        {
            Todo todo = GetTodoById(id);
            todo.IsDone = true;
            _dbContext.Update( todo );
        }
    }
}
