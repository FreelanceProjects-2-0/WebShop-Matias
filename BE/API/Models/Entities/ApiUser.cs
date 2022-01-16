using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.API.Models.Entities
{
    public class ApiUser : IdentityUser, IDatedEntity
    {
        public DateTimeOffset Created { get; set; }

        public DateTimeOffset Updated { get; set; }

        public string Name { get; set; }

        public bool Disabled { get; set; }

        public List<IdentityRole> Roles { get; set; }

        public UserSettings UserSettings { get; set; }
    }
}
