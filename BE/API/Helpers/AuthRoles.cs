﻿using System.Collections.Generic;

namespace WebShop.API.Helpers
{
    public static class AuthRoles
    {
        public const string Admin = "admin";

        public static IReadOnlyList<string> List { get; }
                = new List<string>()
                {
                    Admin
                };
    }
}
