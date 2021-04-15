using System;
namespace DocUp.Bll.Models
{
    public class IlnessModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ClinicCall { get; set; }

        public int DoctorCall { get; set; }

        public int WatcherCall { get; set; }
    }
}
