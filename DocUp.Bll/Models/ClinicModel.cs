using System;
namespace DocUp.Bll.Models
{
    public class ClinicModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Place { get; set; }

        public string PhoneNumber { get; set; }

        public int DoctorCount { get; set; }
    }
}
