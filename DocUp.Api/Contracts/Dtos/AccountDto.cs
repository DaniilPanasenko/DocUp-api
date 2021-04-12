using System;
using System.ComponentModel.DataAnnotations;
using DocUp.Api.Validators;

namespace DocUp.Api.Contracts.Dtos
{
    public class AccountDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 5)]
        [NotAllowSpaces]
        public string Login { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 5)]
        [NotAllowSpaces]
        public string Password { get; set; }
    }
}
