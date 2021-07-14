using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OwnerAPI.Contracts;
using OwnerAPI.Dtos;
using OwnerAPI.Entities;

namespace OwnerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;
        private readonly IMapper mapper;
        private readonly ILogger<AccountsController> logger;

        public AccountsController(IRepositoryWrapper repository,
                                IMapper mapper,
                                ILogger<AccountsController> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await repository.Account.GetAllAccountsAsync();
            var accountForReads = mapper.Map<IEnumerable<AccountForRead>>(accounts);
            return Ok(accountForReads);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(Guid id)
        {
            var account = await repository.Account.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            var accountForRead = mapper.Map<AccountForRead>(account);
            return Ok(accountForRead);
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetAccountWithDetails(Guid id)
        {
            var account = await repository.Account.GetAccountWithDetailsAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            var accountDetailsForRead = mapper.Map<AccountDetailsForRead>(account);
            return Ok(accountDetailsForRead);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(AccountForCreate accountForCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var account = mapper.Map<Account>(accountForCreate);
            repository.Account.CreateAccount(account);
            await repository.SaveAsync();
            var accountForRead = mapper.Map<AccountForRead>(account);
            return CreatedAtAction("GetAccountById", new { id = account.Id }, accountForRead);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(Guid id, AccountForUpdate accountForUpdate)
        {
            var account = await repository.Account.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            mapper.Map(accountForUpdate, account);
            repository.Account.UpdateAccount(account);
            await repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            var account = await repository.Account.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            repository.Account.DeleteAccount(account);
            await repository.SaveAsync();
            return NoContent();
        }
    }
}