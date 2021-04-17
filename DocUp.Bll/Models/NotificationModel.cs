using System;
using DocUp.Dal.Entities;

namespace DocUp.Bll.Models
{
    public class NotificationModel
    {
        public NotificationModel()
        {
            Id = Guid.NewGuid().ToString();
            Processed = false;
        }

        public string Id { get; set; }

        public string Phone { get; set; }

        public IlnessEntity Ilness { get; set; }

        public PatientEntity Patient { get; set; }

        public int Percent { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public string Recipient { get; set; }

        public bool Processed { get; set; }

        public string Message =>
            $"Time: {DateTime}\n" +
            $"Phone: {Phone}\n" +
            $"Call resipient: {Recipient}\n"+
            $"Patient: {Patient.Name} {Patient.Surname} {Patient.Age} y.o.\n" +
            $"Ilness: {Ilness.Name}\n" +
            $"Condition patient: {Percent}%\n" +
            $"Address: {Patient.Address}";
    }
}
