using System;
namespace DocUp.Bll.Models
{
    public class DeviceDataModel
    {
        public int Seria { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public int Percent { get; set; }

        public string Data { get; set; }

        public int DeviceId { get; set; }
    }
}
