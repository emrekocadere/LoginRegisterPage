using bank_website_backend.Repository;

namespace bank_website_backend.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        public List<T> GetAlls();
        public bool AddRecord(T entity);
        public T FindById(int id);
        public bool DeleteRecord(T entity);
    }
}
