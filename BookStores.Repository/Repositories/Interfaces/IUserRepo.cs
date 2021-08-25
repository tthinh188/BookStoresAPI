using BookStores.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStores.Repository.Repositories.Interfaces
{
    public interface IUserRepo : IRepository<User>
    {
        Task<User> AddUser(User user);
        Task<User> GetUser(User user);

    }
}
