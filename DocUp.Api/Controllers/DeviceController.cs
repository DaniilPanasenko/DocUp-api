using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using DocUp.Api.Auth;
using DocUp.Api.Contracts.Dtos;
using DocUp.Bll.Helpers;
using DocUp.Bll.Models;
using DocUp.Bll.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocUp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/device")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class DeviceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDeviceService _deviceService;

        public DeviceController(
            IMapper mapper,
            IDeviceService deviceService)
        {
            _mapper = mapper;
            _deviceService = deviceService;
        }

        [HttpPost("data")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> SendDataAsync(DeviceDataDto data)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var dataModel = _mapper.Map<DeviceDataDto, DeviceDataModel>(data);

            var result = await _deviceService.AddDataAsync(dataModel);

            if (result == ResultCode.NotFound) return NotFound();
            if (result == ResultCode.Success) return Ok();
            else return Conflict((int)result);
        }
    }
}