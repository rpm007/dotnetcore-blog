using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Core.Domain;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public static class SeedDataContext
    {
        public static async Task<int> Initialize(IServiceProvider serviceProvider, DataContext context, IConfiguration configuration)
        {
            if (!context.Users.Any())
            {
                string email = configuration.GetValue<string>("TestUserEmail");
                string password = configuration.GetValue<string>("TestUserPassword");

                UserManager<User> userManager = (UserManager<User>)serviceProvider.GetService(typeof(UserManager<User>));
                var result = await userManager.CreateAsync(getUser(email), password);
            }

            return 1;
        }

        private static User getUser(string email)
        {
            User user = new User()
            {
                UserName = email,
                Email = email
            };

            return user;
        }
    }
}
