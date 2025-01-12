﻿using EBook.Dtos.Users;
using EBook.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EBook.Controllers
{
    [ApiController]
    [Route("api/users")]
    // [EnableCors("MyCors")]
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _usersServices;

        public UsersController(ILogger<UsersController> logger, IUserService usersServices) : base(logger)
        {
            _usersServices = usersServices;
        }

        [Authorize]
        [HttpGet("my-info")]
        public IActionResult MyInfo()
        {
            try
            {
                var result = _usersServices.FindMyInfo();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [HttpPost("register")]
        public IActionResult Add([FromBody] CreateUserDto input)
        {
            try
            {
                _usersServices.Create(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }


        [Authorize]
        [HttpPost("add-info")]
        public IActionResult AddUserInfo([FromBody] CreateUserInfoDto input)
        {
            try
            {
                _usersServices.CreateInfoUser(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto input)
        {
            try
            {
                var result = _usersServices.Login(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
    }
}
