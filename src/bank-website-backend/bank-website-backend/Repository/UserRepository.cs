using bank_website_backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace bank_website_backend.Repository
{
    public class UserRepository:IUserRepository
    {
        BankWebsiteDbContext dbContext;
        public UserRepository(BankWebsiteDbContext dbContext) {
             this.dbContext = dbContext;
        }

        public bool AddRecord(User entity)
        {
            try
            {
                dbContext.Users.Add(entity);
                dbContext.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }



        public bool DeleteRecord(User entity)
        {
            try
            {
                dbContext.Users.Remove(entity);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public User FindById(int id)
        {
            try
            {
                return dbContext.Users.Find(id);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            
        }

        public List<User> GetAlls()
        {
            try
            {
                return dbContext.Users.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }


    }
}
