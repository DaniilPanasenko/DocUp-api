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
    [Route("api/v1/admin")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize(Roles = Roles.Admin)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public class AdminController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IIlnessService _ilnessService;
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;

        public AdminController(
            IAccountService accountService,
            IIlnessService ilnessService,
            IDeviceService deviceService,
            IMapper mapper)
        {
            _accountService = accountService;
            _ilnessService = ilnessService;
            _deviceService = deviceService;
            _mapper = mapper;
        }

        [HttpPost("admin")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Conflict)]
        public async Task<ActionResult> AddAdminAsync(AccountDto account)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var accountModel = _mapper.Map<AccountDto, AccountModel>(account);

            var result = await _accountService.AddAdminAsync(accountModel);

            if (result != ResultCode.Success)
            {
                return Conflict((int)result);
            }
            return Ok();
        }

        [HttpPost("clinic")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Conflict)]
        public async Task<ActionResult> AddClinicAsync(AccountDto account)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var accountModel = _mapper.Map<AccountDto, AccountModel>(account);

            var result = await _accountService.AddClinicAsync(accountModel);

            if (result != ResultCode.Success)
            {
                return Conflict((int)result);
            }
            return Ok();
        }

        [HttpPatch("blocked_status/{userId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> BlockOrUnblockUserAsync(int userId)
        {
            var  result = await _accountService.ChangeBlockedStatusAsync(userId);
            return StatusCode((int)result);
        }

        [HttpPost("ilness")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> AddIlnessAsync(IlnessDto ilness)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ilnessModel = _mapper.Map<IlnessDto, IlnessModel>(ilness);

            await _ilnessService.AddIlnessAsync(ilnessModel);

            return Ok();
        }

        [HttpPost("device")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public async Task<ActionResult> AddDeviceAsync(DeviceDto device)
        {
            var deviceModel = _mapper.Map<DeviceDto, DeviceModel>(device);
            var result = await _deviceService.AddAsync(deviceModel);

            if (result == ResultCode.NotFound) return NotFound();
            if (result == ResultCode.Success) return Ok();
            else return Conflict((int)result);
        }

        //TODO: data export / import
    }
}
