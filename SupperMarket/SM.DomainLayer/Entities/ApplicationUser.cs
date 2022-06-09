using Microsoft.AspNetCore.Identity;
using SM.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.InfractureLayer
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
