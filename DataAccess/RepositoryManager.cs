using BusinessLogic.Interfaces;
using DataAccess.Repositories;

namespace DataAccess
{
    public class RepositoryManager : IRepositoryManager
    {
        private MoviesContext _repositoryContext;
        private IUsersRepository usersRepository;

        public RepositoryManager(MoviesContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IUsersRepository Users => usersRepository != null ? usersRepository : new UsersRepository(_repositoryContext);
        
        //Hacer lo mismo para movies
        //public IUsersRepository Users => usersRepository != null ? usersRepository : new UsersRepository(_repositoryContext);

        public void Save() => _repositoryContext.SaveChanges();
    }
}
