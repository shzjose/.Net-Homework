namespace BusinessLogic.Interfaces
{
    public interface IRepositoryManager
    {
        IUsersRepository Users { get; }
        void Save();
    }

}
