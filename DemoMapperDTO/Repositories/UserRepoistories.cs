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

        public UserRepoistories(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public List<UserRegisteration> GetUsers()
        {
            try
            {
                List<UserRegisteration> usersid = _dbContext.userRegisterations.ToList();
                return usersid;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public UserRegisteration GetUsersById(int id)
        {
            try
            {
                var users = _dbContext.userRegisterations.Find(id);
                return users;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
