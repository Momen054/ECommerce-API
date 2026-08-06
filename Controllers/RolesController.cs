using E_Commerce.Data;
using E_Commerce.DTOs.Role;
using E_Commerce.Intefaces;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class RolesController(IRoleService _roleService) : ControllerBase
    {
        
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<GetRoleDto>> Get(int Id)
        {
            
            return Ok(await _roleService.Get(Id));
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Create(RoleDto dto)
        {   
            await _roleService.Create(dto);
            return Ok();
        }
        [HttpPut]
        [Route("")]
        public async Task<ActionResult> Put(RoleDto dto)
        {
            await _roleService.Put(dto);
            return NoContent();
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            await _roleService.Delete(Id);
            return NoContent();
        }
    }
}
