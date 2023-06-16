using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoMapperDTO.Models;
using DemoMapperDTO.DTO;
using AutoMapper;
using DemoMapperDTO.Data;
using Microsoft.EntityFrameworkCore;
using DemoMapperDTO.Repositories;
using DemoMapperDTO.Services;

namespace DemoMapperDTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepoistories userRepostories;
        private readonly UserServices userServices;


        public UserController(UserRepoistories _userRepostories,UserServices User)
        {
            this.userRepostories = _userRepostories;
            this.userServices =User;
            
            
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

        [HttpGet, Route("GetUsers")]
        public Task<List<UserDTO>> GetUsers()
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


        [HttpGet,Route("GetAllDetails")]
        public IActionResult GetAllDetails()
        {
            try
            {
                return StatusCode(200, userRepostories.GetAllDetails());
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpGet, Route("GetUsers/{id}")]
        public UserDTO GetUsersById(int id)
        {

            try
            {
                UserDTO userRegisteration = userRepostories.GetUsersById(id);
                return userRegisteration;

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut, Route("EditUser")]
        public IActionResult Edit(UserRegisteration userRegisteration)
        {
            try
            {
                userRepostories.Update(userRegisteration);
                return StatusCode(200, userRegisteration);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpDelete, Route("DeleteUser/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                userRepostories.Delete(id);
                return StatusCode(200, "User Deleted");
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
        [HttpGet, Route("Count")]
        public int Count()
        {
            try
            {
                int totalCount = userServices.Count();
                return totalCount;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}