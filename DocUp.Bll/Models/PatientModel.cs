using System;
namespace DocUp.Bll.Models
{
    public class PatientModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

        public string WatcherName { get; set; }

        public string WatcherSurname { get; set; }

        public string WatcherPhoneNumber { get; set; }

        public string DoctorName { get; set; }

        public string ClinicName { get; set; }
    }
}
