using System;
using System.ComponentModel.DataAnnotations;

namespace DocUp.Api.Contracts.Requests
{
    public class LoginRequest
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.-]{5,}$", ErrorMessage = "Invalid login")]
        public string Login { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.-]{5,}$", ErrorMessage = "Invalid password")]
        public string Password { get; set; }
    }
}
