using System;
using DocUp.Dal.Context;

namespace DocUp.Api.Extensions
{
    public static class SeedingExtension
    {
        internal static void EnsureAdminCreated(DocUpContext context)
        {
            /*
            var adminUser = context.Users.Any(x => x.Email == "admin@admin.com"
                                                  && x.Login == "admin");
            if (!adminUser)
            {
                context.Users.Add(new User
                {
                    Email = "admin@admin.com",
                    Login = "admin",
                    PasswordHash = PasswordHash.CreateHash("admin"),
                    Role = "admin",
                });
            }
            context.SaveChanges();
            */
        }
    }
}
