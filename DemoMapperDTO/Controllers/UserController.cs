using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoMapperDTO.Models;
using DemoMapperDTO.DTO;
using AutoMapper;
using DemoMapperDTO.Data;
using Microsoft.EntityFrameworkCore;
using DemoMapperDTO.Repositories;

namespace DemoMapperDTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserRepostories userRepostories;
       

        public UserController(UserRepostories _userRepostories)
        {
            this.userRepostories = _userRepostories;
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(UserRegisteration userRegisteration)
        {
            try
            {
                userRepostories.Add(userRegisteration);
                return StatusCode(200, userRegisteration);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        
        [HttpGet,Route("GetUsers")]
        public  Task<List<UserDTO>> GetUsers()
        {
            try
            {
                return userRepostories.GetUsers();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("GetUsers/{id}")]
        public Task<List<UserDTO>> GetUsersById()
        {
            try
            {
                return userRepostories.GetUsers();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}