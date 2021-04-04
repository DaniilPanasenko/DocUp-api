using System;
using System.Linq;
using DocUp.Api.Auth;
using DocUp.Bll.Helpers;
using DocUp.Dal.Context;
using DocUp.Dal.Entities;

namespace DocUp.Api.Extensions
{
    public static class SeedingExtension
    {
        internal static void EnsureAdminCreated(DocUpContext context)
        {
            var adminUser = context.Accounts.Any(x => x.Email == "admin@admin.com"
                                                  && x.Login == "admin");
            if (!adminUser)
            {
                context.Accounts.Add(new AccountEntity
                {
                    Email = "admin@admin.com",
                    Login = "admin",
                    PasswordHash = PasswordHash.CreateHash("admin"),
                    Role = Roles.Admin,
                });
            }
            context.SaveChanges();
        }
    }
}
