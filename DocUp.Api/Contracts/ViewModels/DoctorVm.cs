using System;
namespace DocUp.Api.Contracts.ViewModels
{
    public class DoctorVm
    {
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
