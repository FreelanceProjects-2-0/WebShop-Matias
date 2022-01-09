using AutoMapper;
using AutoMapper.QueryableExtensions;
using WebShop.API.Data;
using WebShop.API.Helpers;
using WebShop.API.Models.Entities;
using WebShop.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.API.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicies.RequireAdmin)]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<ApiUser> _userManager;
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, ApiDbContext context, IMapper mapper, UserManager<ApiUser> userManager)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            IQueryable<ApiUser> request = _context.Users;

            var user = await request.ProjectTo<UserViewModel>(_mapper.ConfigurationProvider).ToListAsync();
            return new OkObjectResult(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _context.Users
                .Where(x => x.Id == id)
                .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (user == null || !User.IsAdmin())
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(user);
        }

        [HttpPut]
        public async Task<IActionResult> ItemPut([FromBody] UserEditViewModel viewModel)
        {
            ApiUser newUser;

            if (!User.IsAdmin())
            {
                // additional checks for non-admins
                if (viewModel.Roles?.Any(x => x == AuthRoles.Admin) == true)
                {
                    _logger.LogError("User {username} does not have access to assign the specified roles", User.Identity.Name);

                    throw new NotAuthorizedException();
                }
            }

            // check for invalid roles
            if (viewModel.Roles?.Any(x => !AuthRoles.List.Contains(x)) == true)
            {
                _logger.LogError($"Invalid roles in request ({string.Join(", ", viewModel.Roles)})");

                return BadRequest();
            }

            if (viewModel.Id == null)
            {
                if (!User.HasAnyRole(AuthRoles.Admin))
                {
                    _logger.LogError("User is not allowed to add users");

                    return BadRequest();
                }

                newUser = new ApiUser()
                {
                    Email = viewModel.Email,
                    UserName = viewModel.Email,
                    PhoneNumber = viewModel.PhoneNumber,
                    Name = viewModel.Name
                };

                string userPassword = GeneratePassword();

                IdentityResult result = await _userManager.CreateAsync(newUser, userPassword);

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException("Unable to create user");
                }

                if (viewModel.Roles != null)
                {
                    await _userManager.AddToRolesAsync(newUser, viewModel.Roles);
                }
            }
            else
            {
                newUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == viewModel.Id);

                if (newUser == null)
                {
                    _logger.LogError("User with id {userid} not found", viewModel.Id);

                    return NotFound();
                }

                newUser.Email = viewModel.Email;
                newUser.UserName = viewModel.Email;
                newUser.PhoneNumber = viewModel.PhoneNumber;
                newUser.Name = viewModel.Name;

                _logger.LogInformation($"User {newUser.Email} with id {newUser.Id} updated by {User.GetUserId()}");

                var result = await _userManager.UpdateAsync(newUser);

                if (!result.Succeeded)
                {
                    _logger.LogError("Unable to update user {userid}", viewModel.Id);

                    return BadRequest(result);
                }

                await _userManager.SetRolesAsync(newUser, viewModel.Roles);

                if (!string.IsNullOrEmpty(viewModel.Password))
                {
                    string token = await _userManager.GeneratePasswordResetTokenAsync(newUser);
                    await _userManager.ResetPasswordAsync(newUser, token, viewModel.Password);
                }
            }

            await _context.SaveChangesAsync();

            _logger.LogInformation("Updated user {userid}", newUser.Id);

            return new OkResult();
        }

        private static readonly Random Random = new();

        private static string GeneratePassword()
        {
            byte[] buffer = new byte[48];
            Random.NextBytes(buffer);
            return Convert.ToBase64String(buffer);
        }
    }
}

