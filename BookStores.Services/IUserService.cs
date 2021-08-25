using BookStores.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStores.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int Id);
        Task<User> CreateUser(User author);
    }
}
