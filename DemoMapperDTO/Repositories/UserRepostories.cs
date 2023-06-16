using AutoMapper;
using DemoMapperDTO.Data;
using DemoMapperDTO.DTO;
using DemoMapperDTO.Migrations;
using DemoMapperDTO.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace DemoMapperDTO.Repositories

{
    public class UserRepostories
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepostories(ApplicationDbContext dbContext, IMapper mapper)
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
        public void Delete(UserRegisteration userRegisteration)
        {
            try
            {
                _dbContext.Remove(userRegisteration);
                _dbContext.SaveChanges();
            }
            catch (Exception ex) 
            { 
                throw;
            }
        }

        public async Task<UserDTO> GetUsersById(int id)
        {
            var users =await _dbContext.userRegisterations.FindAsync(id);
            return  _mapper.Map<UserDTO>(users);
             
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            var users = await _dbContext.userRegisterations.ToListAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }
    }
}
