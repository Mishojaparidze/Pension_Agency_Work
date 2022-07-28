using Api.Data;
using Api.Domain;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pension_Agency_Test.Models;
using Pension_Agency_Test.Services;
using System.Threading.Tasks;

namespace Pension_Agency_Test.Controllers
{
    
    [Route("api/[Controller]")]
    public class AdminController : Controller
    {
        private readonly UserContext _context;
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService, UserContext context)
        {
            _context = context;
            _adminService = adminService;
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult<User>> AddUser(UserModel registerData)
        {
            var validation = new ValidationService(_context);
            ValidationResult result = validation.Validate(registerData);
            if (result.IsValid)
            {
                _adminService.RegisterUser(registerData);
                await _context.SaveChangesAsync(); 
                return Ok("User Created");
            }
            else
            {
                return BadRequest(result);
            }
        }

        
        [HttpGet("GetUserByRole")]
        public User GetUserByRole(string RoleId)
        {
            var user = _adminService.GetUserByRole(RoleId);
            return user;
        }


        [HttpPut("ModifyUserRole")]
        public User ModifyUserRole(GiveUserRoleModel modifyRole)
        {
            var tempUser = _adminService.ModifyUserRole(modifyRole);
            
            _adminService.ModifyUserRole(modifyRole);
            _context.SaveChanges();

            return tempUser;
        }

        [HttpPut("ModifyUserInfo")]
        public User ModifyUserInfo(ModifyUserModel modify)
        {
            var tempUser = _adminService.ModifyUserInfo(modify);

            _adminService.ModifyUserInfo(modify);
            _context.SaveChanges();

            return tempUser;
        }

        [HttpPost("GiveUserRole")]
        public User GiveUserRole(GiveUserRoleModel model)
        {
            var tempUser=_adminService.ModifyUserRole(model);
            _adminService.ModifyUserRole(model);
            return tempUser;
        }

    }
}
