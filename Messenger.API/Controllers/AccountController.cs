using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messenger.Core.Extensions;
using Messenger.Core.RequestModels;
using Messenger.Core.ResponseModels;
using Messenger.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.API.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
    
        [ProducesResponseType(typeof(ErrorMessage), 500)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(typeof(SuccessMessage), 200)]
        [HttpPost("api/account")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.ToErrorMessage());
            }

            try
            {
                await _userService.CreateUser(model);
                return Ok(new SuccessMessage());
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new ErrorMessage { Code = 400, Message = ex.Message });
            }
        }
    }
}