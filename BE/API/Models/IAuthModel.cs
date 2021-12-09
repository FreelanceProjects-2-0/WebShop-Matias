using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace WebShop.API.Models
{
    public interface IAuthModel
    {
        Task<AuthResponse> AuthenticateWithCredentialsAsync(string username, string password);
        Task<AuthResponse> AuthenticateWithRefreshTokenAsync(string refreshTokenId);
    }
}