using AutoMapper;
using WebShop.API.Auth;
using WebShop.API.Data;
using WebShop.API.Helpers;
using WebShop.API.Models;
using WebShop.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.API.Controllers.Admin
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthModel _authModel;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;

        public AuthController(IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions, IAuthModel authModel)
        {
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
            _authModel = authModel;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] CredentialsViewModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authModel.AuthenticateWithCredentialsAsync(credentials.UserName, credentials.Password);

            return Ok(await GetJwtResult(response));
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Post([FromBody] string refreshTokenId)
        {
            var response = await _authModel.AuthenticateWithRefreshTokenAsync(refreshTokenId);

            return Ok(await GetJwtResult(response));
        }

        private async Task<AuthResponseViewModel> GetJwtResult(AuthResponse response)
        {
            return new AuthResponseViewModel
            {
                Id = response.User.Id,
                Token = await _jwtFactory.GenerateEncodedToken(response.User.UserName, response.Identity),
                Expires = DateTimeOffset.Now.AddSeconds(_jwtOptions.ValidFor.TotalSeconds),
                RefreshToken = response.RefreshTokenId,
                Username = response.User.UserName,
                Name = response.User.Name,
                Roles = response.Roles.ToList(),
            };
        }
    }
}
