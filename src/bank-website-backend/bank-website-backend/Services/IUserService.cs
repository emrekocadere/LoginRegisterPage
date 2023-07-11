using bank_website_backend.Entities;
using bank_website_backend.Model.Request;

namespace bank_website_backend.Services
{
    public interface IUserService
    {
        public bool IsNameExsist(string name);
        public User MapUserAndUserRequest(RegisterRequest registerRequest);
        public bool Register(User user);
    }
}
