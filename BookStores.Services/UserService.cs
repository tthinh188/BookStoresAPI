using BookStores.Domain.Models;
using BookStores.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStores.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;

        public UserService(IUnitOfWork Uow)
        {
            uow = Uow;
        }
        public async Task<User> CreateUser(User user)
        {
            await uow.Users.AddAsync(user);
            await uow.CommitAsync();
            return user;
        }

        public Task<User> GetUserById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SignIn(User user)
        {
            var UserExist = await uow.Users.GetUserAsync(user);
            return UserExist != null;
        }
    }
}
