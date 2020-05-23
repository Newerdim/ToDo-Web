using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo_Web.Dtos;
using ToDo_Web.Models;

namespace ToDo_Web.Data
{
    public interface IAuthRepository
    {
        Task<User> Login(string username, string password);
        Task<User> Register(UserForRegisterDto user, string password);
        Task<bool> UserExist(string username);
    }
}
