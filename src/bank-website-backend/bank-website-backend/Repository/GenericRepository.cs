using bank_website_backend.Entities;
using System.Linq.Expressions;

namespace bank_website_backend.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        BankWebsiteDbContext dbContext;
        public GenericRepository(BankWebsiteDbContext dbContext) { 
            this.dbContext = dbContext;
        }
        public bool AddRecord(T entity)
        {
            try
            {
                dbContext.Add(entity);
                dbContext.SaveChanges();
                return true;
            }
            catch(Exception e) {
                Console.WriteLine(e);
                return false;
            }
            
        }

        public bool DeleteRecord(T entity)
        {
            try
            {
                dbContext.Set<T>().Remove(entity);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public T FindById(int id)
        {
            try{

                return dbContext.Set<T>().Find(id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
            
        }

        public List<T> GetAlls()
        {
            return dbContext.Set<T>().ToList();
        }
    }
}
