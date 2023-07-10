using bank_website_backend.Entities;

namespace bank_website_backend.Repository
{
    public interface IUserRepository
    {
        public List<User> GetAlls();
        public User AddUser();
        public List<User> FindById();
        public bool DeleteUser();
    }
}
