using System;
using System.Linq;
using System.Threading.Tasks;
using DocUp.Bll.Models;
using DocUp.Dal.Storages;

namespace DocUp.Bll
{
    public class ReadingsHandler
    {
        private readonly TimeSpan spamTime = TimeSpan.FromHours(1);

        private readonly IDeviceStorage _deviceStorage;
        private readonly IIlnessStorage _ilnessStorage;
        private readonly NotificationsBus _notificationsBus;
        private readonly ReadingsTimeCheck _timeCheck;

        public ReadingsHandler(
            IDeviceStorage deviceStorage,
            IIlnessStorage ilnessStorage,
            NotificationsBus notificationsBus,
            ReadingsTimeCheck timeCheck)
        {
            _deviceStorage = deviceStorage;
            _ilnessStorage = ilnessStorage;
            _notificationsBus = notificationsBus;
            _timeCheck = timeCheck;
        }

        public async Task MakeScoreTransactionAsync()
        {
            var lastChecking = _timeCheck.LastChecking;
            _timeCheck.DoCheck();

            var readings = await _deviceStorage.GetDataDueTimeAsync(lastChecking);

            foreach(var reading in readings)
            {
                var percent = reading.Percent;
                var ilness = reading.Device.Ilness;
                var patient = reading.Device.PatientIlness.Patient;

                if (percent > ilness.WatcherCall &&
                    _notificationsBus.HasRecipientNotificationDueTime(
                        patient.WatcherPhoneNumber,
                        patient.Id,
                        reading.DateTime - spamTime))
                {
                    var notification = new NotificationModel
                    {
                        Phone = patient.WatcherPhoneNumber,
                        Ilness = ilness,
                        Patient = patient,
                        Percent = percent,
                        DateTime = reading.DateTime,
                        Recipient = $"Watcher {patient.WatcherName} {patient.WatcherSurname}"
                    };
                    _notificationsBus.AddNotification(notification);
                }

                if (percent > ilness.WatcherCall &&
                    _notificationsBus.HasRecipientNotificationDueTime(
                        patient.Doctor.PhoneNumber,
                        patient.Id,
                        reading.DateTime - spamTime))
                {
                    var notification = new NotificationModel
                    {
                        Phone = patient.Doctor.PhoneNumber,
                        Ilness = ilness,
                        Patient = patient,
                        Percent = percent,
                        DateTime = reading.DateTime,
                        Recipient = $"Doctor {patient.Doctor.Name} {patient.Doctor.Surname}"
                    };
                    _notificationsBus.AddNotification(notification);
                }

                if(percent > ilness.WatcherCall &&
                    _notificationsBus.HasRecipientNotificationDueTime(
                        patient.Doctor.Clinic.PhoneNumber,
                        patient.Id,
                        reading.DateTime - spamTime))
                {
                    var notification = new NotificationModel
                    {
                        Phone = patient.Doctor.Clinic.PhoneNumber,
                        Ilness = ilness,
                        Patient = patient,
                        Percent = percent,
                        DateTime = reading.DateTime,
                        Recipient = $"Clinic {patient.Doctor.Clinic.Name}"
                    };
                    _notificationsBus.AddNotification(notification);
                }
            }
            
        }
    }
}
