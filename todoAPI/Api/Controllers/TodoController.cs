using Microsoft.AspNetCore.Mvc;
using todoAPI.Application;
using todoAPI.Application.Repositories;
using todoAPI.Models;
using todoAPI.TODO.Dto;

namespace todoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TodoController( ITodoRepository todoRepository, IUnitOfWork unitOfWork)
        {
            _todoRepository = todoRepository;
            _unitOfWork = unitOfWork;   
        }

        [HttpGet]
        public IActionResult GetTodo( int todoId )
        {
            Todo? todo = _todoRepository.GetTodoById(todoId);
            if (todo == null)
                return BadRequest(todoId);

            return Ok(new TodoDto
            {
                Id = todo.Id,
                Title = todo.Title,
                IsDone = todo.IsDone
            });
        }

        [HttpPost]
        public IActionResult CreateTodo( [FromBody] TodoDto todo )
        {
            _todoRepository.CreateTodo( new Todo
            {
                Title = todo.Title,
                IsDone = todo.IsDone
            });
            
            _unitOfWork.Commit();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteTodo( int todoId )
        {
            Todo? todo = _todoRepository.GetTodoById(todoId);
            if (todo == null)
                return BadRequest($"Todo with Id: {todoId} is not found");
            _todoRepository.DeleteTodoById( todoId );
            _unitOfWork.Commit();
            return Ok();
        }

        [HttpPut]
        public IActionResult CompleteTodo( int todoId)
        {
            Todo? todo = _todoRepository.GetTodoById(todoId);
            if (todo == null)
                return BadRequest($"Todo with Id: {todoId} is not found");
            _todoRepository.CompleteTodo( todoId );
            _unitOfWork.Commit();
            return Ok();
        }
    }
}
