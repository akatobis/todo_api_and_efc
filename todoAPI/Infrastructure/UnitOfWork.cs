using todoAPI.Application;

namespace todoAPI.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoDbContext _dbContext;

        public UnitOfWork(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
