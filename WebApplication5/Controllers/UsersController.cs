using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext userContext;

        public UsersController(UserContext userContext)
        {
            this.userContext = userContext;
        }

        [HttpGet]
        [Route("GetUsers")]
        public ActionResult<IEnumerable<Users>> GetUsers()
        {
            return userContext.Users.ToList();
        }

        [HttpGet]
        [Route("GetUser")]
        public ActionResult<Users> GetUser(int id)
        {
            return userContext.Users.FirstOrDefault(x => x.ID == id);
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(Users users)
        {
            try
            {
                userContext.Users.Add(users);
                userContext.SaveChanges();
                return Ok("User added");
            }
            catch (DbUpdateException ex)
            {
                return BadRequest($"Error: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(Users users)
        {
            try
            {
                userContext.Entry(users).State = EntityState.Modified;
                userContext.SaveChanges();
                return Ok("User Updated");
            }
            catch (DbUpdateException ex)
            {
                return BadRequest($"Error: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            Users user = userContext.Users.FirstOrDefault(x => x.ID == id);
            if (user != null)
            {
                userContext.Users.Remove(user);
                userContext.SaveChanges();
                return Ok("User deleted");
            }
            else
            {
                return NotFound("No User found");
            }
        }
    }
}
