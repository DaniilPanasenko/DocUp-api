using System;
namespace DocUp.Api.Contracts.ViewModels
{
    public class NotificationVm
    {
        public string Id { get; set; }

        public string Phone { get; set; }

        public string Message { get; set; }

        public bool Processed { get; set; }
    }
}
