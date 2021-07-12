using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public AccountsController(IRepositoryWrapper repository,
                                IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await repository.Account.GetAllAccountsAsync();
            return Ok(mapper.Map<IEnumerable<AccountForRead>>(accounts));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(Guid id)
        {
            var account = await repository.Account.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<AccountForRead>(account));
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetAccountsByOwner(Guid ownerId)
        {
            var accounts = await repository.Account.GetAccountsByOwnerAsync(ownerId);
            if (accounts == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<IEnumerable<AccountForRead>>(accounts));
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
            return CreatedAtAction("GetAccountById", new { id = account.Id }, account);
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