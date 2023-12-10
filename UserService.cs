using Core.Domain;
using Core.DTOs;
using Core.Repository;
using Core.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : BaseEntityService<User>, IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task Login(LoginDTO loginDTO)
        {

            var user = await _userManager.FindByEmailAsync(loginDTO.email);

            if (user == null)
            {
                throw new Exception();
            }

            var isPasswordRight = await _userManager.CheckPasswordAsync(user, loginDTO.password);

            if (!isPasswordRight)
            {
                throw new Exception("Incorrect password.");
            }
        }

        public async Task<IdentityResult> Register(RegisterDTO registerDto)
        {
            var newUser = new IdentityUser() { UserName = registerDto.firstName + " " + registerDto.lastName, PhoneNumber = registerDto.phoneNumber, Email = registerDto.email, PasswordHash = registerDto.password};

            var isRegisteredWithEmailBefore = await _userManager.FindByEmailAsync(newUser.Email);

            if (isRegisteredWithEmailBefore != null)
            {
                throw new Exception("This email is registered.");
            }
            return await _userManager.CreateAsync(newUser, registerDto.password);

        }

    }
}
