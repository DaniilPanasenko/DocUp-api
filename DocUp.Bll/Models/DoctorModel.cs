using System;
namespace DocUp.Bll.Models
{
    public class DoctorModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Position { get; set; }

        public string PhoneNumber { get; set; }

        public string ClinicName { get; set; }

        public int PatientCount { get; set; }
    }
}
