using Core.Domain;
using Core.DTOs;
using Core.Service;
using Microsoft.AspNetCore.Identity;

namespace Web.Models
{
    public class SQLUserService : IUserService
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(User entity)
        {
            throw new NotImplementedException();
        }


        public Task Login(LoginDTO user)
        {
            throw new NotImplementedException();
        }


        public Task<IdentityResult> Register(RegisterDTO registerDto)
        {
            throw new NotImplementedException();
        }

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
