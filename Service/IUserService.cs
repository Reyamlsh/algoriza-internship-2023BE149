using Core.Domain;
using Core.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IUserService : IBaseEntityService<User>
    {
        public Task Login(LoginDTO user);
        public Task<IdentityResult> Register(RegisterDTO registerDto);
    }
}
