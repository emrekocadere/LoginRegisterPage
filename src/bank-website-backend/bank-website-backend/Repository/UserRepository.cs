using bank_website_backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace bank_website_backend.Repository
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        BankWebsiteDbContext dbContext;
        public UserRepository(BankWebsiteDbContext dbContext):base(dbContext) {
             this.dbContext = dbContext;
        }

        //public bool IsNameExsist(string name)
        //{
        //    if (dbContext.Users.FirstOrDefault(u => u.Name == name) == null)
        //    {
        //        return false;
        //    }
        //    else
        //        return true;
        //}

    }
}

