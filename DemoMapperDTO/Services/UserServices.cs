using AutoMapper;
using DemoMapperDTO.Data;
using DemoMapperDTO.DTO;
using DemoMapperDTO.Models;
using DemoMapperDTO.Repositories;

namespace DemoMapperDTO.Services
{
    public class UserServices
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserRepoistories userRepostories;
        private readonly IMapper _mapper;


        public UserServices(ApplicationDbContext dbContext, UserRepoistories _userRepostories, IMapper mapper)
        {
            this.userRepostories = _userRepostories;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Count()
        {
            try
            {
                int totalCount = _dbContext.userRegisterations.Count();
                return totalCount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddServices(UserDTO userdto)
        {
            try
            {
                UserRegisteration userRegisteration = _mapper.Map<UserRegisteration>(userdto);
                userRepostories.Add(userRegisteration);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(UserDTO userdto)
        {
            try
            {
                UserRegisteration userRegisteration=_mapper.Map<UserRegisteration>(userdto);
                userRepostories.Update(userRegisteration);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                userRepostories.Delete(id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<UserDTO> GetUsers()
        {
            try
            {
                var userRegisteration = userRepostories.GetUsers();
                List<UserDTO> userDTO = _mapper.Map<List<UserDTO>>(userRegisteration);
                return userDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public UserDTO GetUserById(int id)
        {
            try
            {
                var userRegisteration = userRepostories.GetUsersById(id);
                UserDTO userDTO = _mapper.Map<UserDTO>(userRegisteration);
                return userDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
