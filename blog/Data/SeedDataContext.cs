using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Core.Domain;

namespace Data
{
    public static class SeedDataContext
    {
        public static async void Initialize(IServiceProvider serviceProvider, DataContext context)
        {
            if (!context.Users.Any())
            {
                UserManager<User> userManager = (UserManager<User>)serviceProvider.GetService(typeof(UserManager<User>));
                var result = await userManager.CreateAsync(getApplicationAdmin(), "Mq5KStki");
            }
        }

        private static User getApplicationAdmin()
        {
            User adminUser = new User()
            {
                UserName = "robin.mckavanagh@gmail.com",
                Email = "robin.mckavanagh@gmail.com"
            };

            return adminUser;
        }
    }
}
