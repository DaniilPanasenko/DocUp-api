using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using DocUp.Api.Auth;
using DocUp.Api.Contracts.ViewModels;
using DocUp.Bll.Models;
using DocUp.Bll.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocUp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/notifications")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public class NotificatonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public NotificatonController(
            INotificationService notificationService,
            IMapper mapper)
        {
            _mapper = mapper;
            _notificationService = notificationService;
        }

        [HttpGet("all")]
        public ActionResult GetAll()
        {
            var notifications = _notificationService.GetAllNotifications();
            return Ok(_mapper.Map<List<NotificationModel>, List<NotificationVm>>(notifications));
        }

        [HttpGet("unreaded")]
        public ActionResult GetUnreaded()
        {
            var notifications = _notificationService.GetUnreadedNotifications();
            return Ok(_mapper.Map<List<NotificationModel>, List<NotificationVm>>(notifications));
        }

        [HttpGet("read/{id}")]
        public ActionResult Read(string id)
        {
            _notificationService.ReadNotification(id);
            return Ok();
        }
    }
}
