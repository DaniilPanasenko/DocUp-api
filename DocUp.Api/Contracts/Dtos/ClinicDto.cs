using System;
using System.ComponentModel.DataAnnotations;

namespace DocUp.Api.Contracts.Dtos
{
    public class ClinicDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Place { get; set; }

        [Phone]
        [Required]
        public string PhoneNumber { get; set; }
    }
}
