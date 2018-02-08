using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog
{
    public class MasterController : Controller
    {
        public UnitOfWork UnitOfWork { get; set; }
        public UserManager<User> UserManager { get; set; }

        public MasterController() { }

        public async Task<User> GetCurrentIdentityUser()
        {
            foreach (var claim in User.Claims)
            {
                if (claim.Type.Contains("id"))
                    return await UserManager.FindByIdAsync(claim.Value);

            }

            return null;
        }
    }
}