using System;
using System.ComponentModel.DataAnnotations;

namespace DocUp.Api.Contracts.Dtos
{
    public class DoctorDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
