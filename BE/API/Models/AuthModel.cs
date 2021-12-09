using WebShop.API.Auth;
using WebShop.API.Data;
using WebShop.API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebShop.API.Models
{
    public class AuthModel : IAuthModel
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly ApiDbContext _context;
        private readonly ILogger<AuthModel> _logger;

        public AuthModel(UserManager<ApiUser> userManager, IJwtFactory jwtFactory, ApiDbContext context, ILogger<AuthModel> logger)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _context = context;
            _logger = logger;
        }

        public async Task<AuthResponse> AuthenticateWithCredentialsAsync(string username, string password)
        {
            ClaimsIdentity identity = null;
            IList<string> roles = null;

            var user = await _userManager.Users
                .Where(x => x.NormalizedUserName == username).FirstOrDefaultAsync();

            if (user != null)
            {
                if (user.Disabled)
                {
                    _logger.LogWarning("User {username} {userId} is disabled", user.UserName, user.Id);
                    throw new InvalidOperationException("User is disabled");
                }

                // check the credentials
                if (await _userManager.CheckPasswordAsync(user, password))
                {
                    _logger.LogInformation("Valid login for user {username} {userId}", user.UserName, user.Id);

                    roles = await _userManager.GetRolesAsync(user);

                    identity = _jwtFactory.GenerateClaimsIdentity(user.UserName, user.Id, roles);
                }
                else
                {
                    _logger.LogInformation("Wrong password for {username} {userId}", user.UserName, user.Id);
                }
            }
            else
            {
                _logger.LogInformation("Unknown user login attempt {username}", username);
            }

            if (identity == null)
            {
                throw new InvalidOperationException("Invalid username or password");
            }

            var refreshToken = _context.AuthRefreshTokens.Where(x => x.User == user && x.Enabled).FirstOrDefault();

            if (refreshToken == null)
            {
                refreshToken = new AuthRefreshToken()
                {
                    User = user,
                    Enabled = true
                };

                _context.AuthRefreshTokens.Add(refreshToken);

                _context.SaveChanges();
            }

            return new AuthResponse()
            {
                User = user,
                Identity = identity,
                Roles = roles,
                RefreshTokenId = Convert.ToBase64String(refreshToken.Id.ToByteArray()),
            };
        }


        public async Task<AuthResponse> AuthenticateWithRefreshTokenAsync(string refreshTokenId)
        {
            Guid targetGuid = new(Convert.FromBase64String(refreshTokenId));

            var token = await _context.AuthRefreshTokens
                .Include(x => x.User)
                .Where(x => x.Id == targetGuid)
                .FirstOrDefaultAsync();

            if (token == null)
            {
                _logger.LogWarning("Unknown refresh token {tokenId}", refreshTokenId);

                throw new NotAuthorizedException();
            }

            if (!token.Enabled)
            {
                _logger.LogWarning("Attempt to use refresh token {tokenId} for user {username} that is not enabled", refreshTokenId, token.User.UserName);

                throw new NotAuthorizedException();
            }

            _logger.LogDebug("Generating token for user {username} {userId} from valid refresh token {tokenId}", token.User.UserName, token.User.Id, token.Id);

            IList<string> roles = await _userManager.GetRolesAsync(token.User);

            return new AuthResponse()
            {
                User = token.User,
                Identity = _jwtFactory.GenerateClaimsIdentity(token.User.UserName, token.User.Id, roles),
                RefreshTokenId = Convert.ToBase64String(token.Id.ToByteArray()),
                Roles = roles,
            };
        }
    }
}
