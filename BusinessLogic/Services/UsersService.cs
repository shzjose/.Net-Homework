using BusinessLogic.Extensions;
using BusinessLogic.Interfaces;
using DTO;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLogic.Services
{
    public class UsersService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UsersService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public List<User> GetUsers()
        {
            return _repositoryManager.Users.GetAll().Select(x => new User()
            {
                Email = x.Email,
                Name = x.Name,
                UserId = x.UserId
            }).ToList();

        }

        public User CreateUser(UserSession user)
        {
            List<User> users = GetUsers();
            int x = 0;

                foreach (User u in users)
                {
                    if (u.Email == user.Email)
                    {
                        x++;
                        break;
                    }

                }
                //VALIDACIÓN
                if (x == 0)
                {

                    var domainUser = new DomainModels.User()
                    {
                        Email = user.Email,
                        Name = user.Name,
                        Password = user.Password
                    };

                    var dbUser = _repositoryManager.Users.Add(domainUser);
                    _repositoryManager.Save();

                    return dbUser.ToDTO();

                }
                else
                {
                    return null;
                }

        }

        public User Login(UserLogin login)
        {
            return null;
        }

    }
}
