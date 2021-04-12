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
    public class AdminController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AdminController(
            IAccountService accountService,
            IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpPost("new_admin")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Conflict)]
        public async Task<ActionResult> AddAdminAsync(AccountDto account)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var accountModel = _mapper.Map<AccountDto, AccountModel>(account);
            accountModel.Role = Roles.Admin;

            var result = await _accountService.AddAccountAsync(accountModel);

            if (result != ResultCode.Success)
            {
                return Conflict((int)result);
            }
            return Ok();
        }

        [HttpPost("new_clinic")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Conflict)]
        public async Task<ActionResult> AddClinicAsync(AccountDto account)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var accountModel = _mapper.Map<AccountDto, AccountModel>(account);
            accountModel.Role = Roles.Clinic;

            var result = await _accountService.AddAccountAsync(accountModel);

            if (result != ResultCode.Success)
            {
                return Conflict((int)result);
            }
            return Ok();
        }
    }
}
