using DemoMapperDTO.Data;

namespace DemoMapperDTO.Services
{
    public class UserServices
    {
        private readonly ApplicationDbContext _dbContext;

        

        public UserServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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
    }
}
