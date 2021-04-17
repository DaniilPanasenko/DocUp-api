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
    [Route("api/v1/doctor")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [Authorize(Roles = Roles.Doctor)]
    public class DoctorController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IApplicationUser _applicationUser;
        private readonly IDoctorService _doctorService;

        public DoctorController(
            IAccountService accountService,
            IMapper mapper,
            IApplicationUser applicationUser,
            IDoctorService doctorService)
        {
            _accountService = accountService;
            _mapper = mapper;
            _applicationUser = applicationUser;
            _doctorService = doctorService;
        }

        private int UserId => _accountService.GetUserIdByAccountIdAsync(_applicationUser.Id, _applicationUser.Role).Result;

        [HttpPost("patient")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Conflict)]
        public async Task<ActionResult> AddPatientAsync(AccountDto account)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var accountModel = _mapper.Map<AccountDto, AccountModel>(account);

            var result = await _accountService.AddPatientAsync(accountModel, UserId);

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
            var result = await _doctorService.GetInfoAsync(UserId);

            if (result.Code == ResultCode.NotFound)
            {
                return NotFound();
            }

            var info = _mapper.Map<DoctorModel, DoctorVm>(result.Value);
            return Ok(info);
        }

        [HttpPut("info")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> UpdateInfoAsync(DoctorDto doctor)
        {
            var model = _mapper.Map<DoctorDto, DoctorModel>(doctor);
            model.Id = UserId;

            var result = await _doctorService.UpdateAsync(model);
            return StatusCode((int)result);
        }
    }
}
