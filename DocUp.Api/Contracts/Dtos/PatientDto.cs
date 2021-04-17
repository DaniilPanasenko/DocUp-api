using System;
using System.ComponentModel.DataAnnotations;

namespace DocUp.Api.Contracts.Dtos
{
    public class PatientDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        public int Age { get; set; }

        [Required]
        public string WatcherName { get; set; }

        [Required]
        public string WatcherSurname { get; set; }

        [Required]
        [Phone]
        public string WatcherPhoneNumber { get; set; }
    }
}
