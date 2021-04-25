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
            $"Time: {DateTime}<br>" +
            $"Phone: {Phone}<br>" +
            $"Call resipient: {Recipient}<br>" +
            $"Patient: {Patient.Name} {Patient.Surname} {Patient.Age} y.o.<br>" +
            $"Ilness: {Ilness.Name}<br>" +
            $"Condition patient: {Percent}%<br>" +
            $"Address: {Patient.Address}";
    }
}
