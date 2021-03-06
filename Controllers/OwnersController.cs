using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using OwnerAPI.Contracts;
using OwnerAPI.Dtos;
using OwnerAPI.Entities;

namespace OwnerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;
        private readonly IMapper mapper;
        private readonly ILogger<OwnersController> logger;

        public OwnersController(IRepositoryWrapper repository,
                                IMapper mapper,
                                ILogger<OwnersController> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            var owners = await repository.Owner.GetAllOwnersAsync();
            var ownerForReads = mapper.Map<IEnumerable<OwnerForRead>>(owners);
            return Ok(ownerForReads);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwnerById(Guid id)
        {
            var owner = await repository.Owner.GetOwnerByIdAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            var ownerForRead = mapper.Map<OwnerForRead>(owner);
            return Ok(ownerForRead);
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetOwnerWithDetails(Guid id)
        {
            var owner = await repository.Owner.GetOwnerWithDetailsAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            var ownerDetailsForRead = mapper.Map<OwnerDetailsForRead>(owner);
            return Ok(ownerDetailsForRead);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner(OwnerForCreate ownerForCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var owner = mapper.Map<Owner>(ownerForCreate);
            repository.Owner.CreateOwner(owner);
            await repository.SaveAsync();
            var ownerForRead = mapper.Map<OwnerForRead>(owner);
            return CreatedAtAction("GetOwnerById", new { id = owner.Id }, ownerForRead);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(Guid id, OwnerForUpdate ownerForUpdate)
        {
            var owner = await repository.Owner.GetOwnerByIdAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            mapper.Map(ownerForUpdate, owner);
            repository.Owner.UpdateOwner(owner);
            await repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {
            var owner = await repository.Owner.GetOwnerByIdAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            var accounts = await repository.Account.GetAccountsByOwnerAsync(id);
            if (accounts.Any())
            {
                var errorModel = new ModelStateDictionary();
                errorModel.AddModelError("error", "You need to delete owner's account(s) first");
                return BadRequest(errorModel);
            }            
            repository.Owner.DeleteOwner(owner);
            await repository.SaveAsync();
            return NoContent();
        }        
    }
}