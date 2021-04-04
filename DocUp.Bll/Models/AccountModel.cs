using System;
namespace DocUp.Bll.Models
{
    public class AccountModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public string Role { get; set; }
    }
}
