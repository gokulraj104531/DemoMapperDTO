using AutoMapper;
using DemoMapperDTO.Data;
using DemoMapperDTO.DTO;
using DemoMapperDTO.Migrations;
using DemoMapperDTO.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace DemoMapperDTO.Repositories

{
    public class UserRepoistories
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepoistories(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Add(UserRegisteration userRegisteration)
        {
            try
            {
                _dbContext.userRegisterations.Add(userRegisteration);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(UserRegisteration userRegisteration)
        {
            try
            {
                _dbContext.userRegisterations.Update(userRegisteration);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Delete(int id)
        {
            try
            {

                UserRegisteration userRegisteration = _dbContext.userRegisterations.Find(id);
                _dbContext.Remove(userRegisteration);
                _dbContext.SaveChanges();
            }
            catch (Exception ex) 
            { 
                throw;
            }
        }

        //Only certain details will be displayed
        public UserDTO GetUsersById(int id)
        {
            var users = _dbContext.userRegisterations.Find(id);
            return  _mapper.Map<UserDTO>(users);
             
        }

        //Only certain details will be displayed
        public async Task<List<UserDTO>> GetUsers()
        {
            var usersid = await _dbContext.userRegisterations.ToListAsync();
            return _mapper.Map<List<UserDTO>>(usersid);
        }

        public  List<UserRegisteration> GetAllDetails()
        {
            try
            {
                List<UserRegisteration> userRegisterations = _dbContext.userRegisterations.ToList();
                return userRegisterations;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
    }
}
