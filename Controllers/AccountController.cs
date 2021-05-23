using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using blogger_cs.Models;
using blogger_cs.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogger_cs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class AccountController : ControllerBase
    {
        private readonly AccountService _service;
        private readonly BlogsService _blogsService;

        public AccountController(AccountService service, BlogsService blogsService)
        {
            _service = service;
            _blogsService = blogsService;
        }

        [HttpGet]
        public async Task<ActionResult<Account>> GetAccount()
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                Account currentUser = _service.GetOrCreateAccount(user);
                return Ok(currentUser);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("blogs")]
        public async Task<ActionResult<IEnumerable<Blog>>> GetMyBlogs()
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                IEnumerable<Blog> blogs = _blogsService.GetByCreatorId(user.Id);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}