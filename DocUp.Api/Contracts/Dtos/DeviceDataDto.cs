using System;
using System.ComponentModel.DataAnnotations;

namespace DocUp.Api.Contracts.Dtos
{
    public class DeviceDataDto
    {
        public int Seria { get; set; }

        public DateTimeOffset DateTime { get; set; }

        [Range(0,100)]
        public int Percent { get; set; }

        public string Data { get; set; }
    }
}
