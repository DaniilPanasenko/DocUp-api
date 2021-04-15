using System;
using System.ComponentModel.DataAnnotations;

namespace DocUp.Api.Contracts.Dtos
{
    public class IlnessDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Range(0,100)]
        public int ClinicCall { get; set; }

        [Range(0, 100)]
        public int DoctorCall { get; set; }

        [Range(0, 100)]
        public int WatcherCall { get; set; }
    }
}
