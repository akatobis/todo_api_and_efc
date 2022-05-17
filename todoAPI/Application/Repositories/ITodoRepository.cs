using todoAPI.Models;

namespace todoAPI.Application.Repositories
{
    public interface ITodoRepository
    {
        Todo GetTodoById( int id );
        void CreateTodo( Todo todo );
        void DeleteTodoById( int id );
        void CompleteTodo(int id);
    }
}
