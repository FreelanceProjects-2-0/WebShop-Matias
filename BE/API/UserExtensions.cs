using WebShop.API.Data;
using WebShop.API.Helpers;
using WebShop.API.Models.Entities;
using System;
using System.Linq;
using System.Security.Claims;

namespace WebShop.API
{
    public static class UserExtensions
    {
        public static Guid GetCompanyId(this ClaimsPrincipal claims)
        {
            return new Guid(claims.FindFirstValue(AuthConstants.JwtClaimIdentifiers.CompanyId));
        }

        public static bool HasRole(this ClaimsPrincipal claims, string role)
        {
            return claims.HasClaim(AuthConstants.JwtClaimIdentifiers.Rol, role);
        }

        public static bool HasAnyRole(this ClaimsPrincipal claims, params string[] roles)
        {
            return roles.Any(x => claims.HasRole(x));
        }

        public static bool IsAdmin(this ClaimsPrincipal claims)
        {
            return claims.HasRole(AuthRoles.Admin);
        }

        public static string GetUserId(this ClaimsPrincipal claims)
        {
            return claims.FindFirstValue(AuthConstants.JwtClaimIdentifiers.Id);
        }

        public static ApiUser GetUser(this ClaimsPrincipal claims, ApiDbContext context)
        {
            var user = context.Users.Find(claims.GetUserId());

            if (user == null)
            {
                throw new InvalidOperationException($"User {claims.GetUserId()} not found");
            }

            return user;
        }
    }
}
