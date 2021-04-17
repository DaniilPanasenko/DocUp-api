using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using DocUp.Api.Auth;
using DocUp.Api.Contracts.Dtos;
using DocUp.Api.Contracts.ViewModels;
using DocUp.Bll.Helpers;
using DocUp.Bll.Models;
using DocUp.Bll.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocUp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/clinic")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [Authorize(Roles = Roles.Clinic)]
    public class ClinicController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IClinicService _clinicService;
        private readonly IMapper _mapper;
        private readonly IApplicationUser _applicationUser;

        public ClinicController(
            IAccountService accountService,
            IMapper mapper,
            IApplicationUser applicationUser,
            IClinicService clinicService)
        {
            _accountService = accountService;
            _mapper = mapper;
            _applicationUser = applicationUser;
            _clinicService = clinicService;
        }

        private async Task<int> UserId() => await _accountService.GetUserIdByAccountIdAsync(_applicationUser.Id, _applicationUser.Role);

        [HttpPost("doctor")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Conflict)]
        public async Task<ActionResult> AddDoctorAsync(AccountDto account)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var accountModel = _mapper.Map<AccountDto, AccountModel>(account);
            var result = await _accountService.AddDoctorAsync(accountModel, await UserId());

            if (result != ResultCode.Success)
            {
                return Conflict((int)result);
            }
            return Ok();
        }

        [HttpGet("info")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetInfoAsync()
        {
            var result = await _clinicService.GetInfoAsync(await UserId());

            if (result.Code == ResultCode.NotFound)
            {
                return NotFound();
            }

            var info = _mapper.Map<ClinicModel, ClinicVm>(result.Value);
            return Ok(info);
        }

        [HttpPut("info")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> UpdateInfoAsync(ClinicDto clinic)
        {
            var model = _mapper.Map<ClinicDto, ClinicModel>(clinic);
            model.Id = await UserId();

            var result = await _clinicService.UpdateAsync(model);
            return StatusCode((int)result);
        }
    }
}