using Messenger.Core.RequestModels;
using Messenger.Domain.Repositories.Interfaces;
using Messenger.Services.Interfaces;
using System.Threading.Tasks;
using Messenger.Domain.Models;
using System;
using Microsoft.AspNetCore.Identity;

namespace Messenger.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(IUserRepository userRepository, 
            UserManager<User> userManager, 
            SignInManager<User> signInManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task CreateUser(RegisterModel model)
        {
            var user = GetFilledUser(model);

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // setting cookies
                await _signInManager.SignInAsync(user, false);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    throw new InvalidOperationException(error.Description);
                }
            }
        }

        private User GetFilledUser(RegisterModel model)
        {
            var user = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
            };

            return user;
        }
    }
}
