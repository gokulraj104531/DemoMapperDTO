using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoMapperDTO.Models;
using DemoMapperDTO.DTO;
using AutoMapper;
using DemoMapperDTO.Data;
using Microsoft.EntityFrameworkCore;
using DemoMapperDTO.Repositories;
using DemoMapperDTO.Services;
using Microsoft.AspNetCore.Authorization;

namespace DemoMapperDTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserServices userServices;


        public UserController(UserServices User,ApplicationDbContext dbContext)
        {
            this.userServices =User;
            _dbContext = dbContext;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]Loginmodel loginmodel)
        {
            if(loginmodel == null)
            {
                return BadRequest();
            }
            var user=await _dbContext.userRegisterations.FirstOrDefaultAsync(x=> x.UserName == loginmodel.UserName && x.Password==loginmodel.Password);
            if(user == null)
            {
                return BadRequest();
            }
            return Ok("Success");
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(UserDTO userdto)
        {
            try
            {
                userServices.AddServices(userdto);
                return StatusCode(200, userdto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetUsers")]
        public List<UserDTO> GetUsers()
        {
            try
            {
                return userServices.GetUsers();
            }
            catch (Exception)
            {
                throw;
            }
        }


        //[HttpGet,Route("GetAllDetails")]
        //public IActionResult GetAllDetails()
        //{
        //    try
        //    {
        //        return StatusCode(200, userServices.GetAllDetails());
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500,ex.Message);
        //    }
        //}

        [HttpGet, Route("GetUsers/{id}")]
        public UserDTO GetUsersById(int id)
        {

            try
            {
                return userServices.GetUserById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut, Route("EditUser")]
        public IActionResult Edit(UserDTO userdto)
        {
            try
            {
                userServices.Update(userdto);
                return StatusCode(200, userdto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpDelete, Route("DeleteUser/{id}")]
        public void Delete(int id)
        {
            try
            {
                userServices.Delete(id);
               // return StatusCode(200, "User Deleted");
            }
            catch(Exception ex)
            {
                //return StatusCode(500,ex.Message);
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