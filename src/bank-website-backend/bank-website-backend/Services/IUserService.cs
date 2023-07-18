using bank_website_backend.Entities;
using bank_website_backend.Model.Request;
using Microsoft.AspNetCore.Identity;

namespace bank_website_backend.Services
{
    public interface IUserService
    {
        public bool IsNameExsist(string name);
        public User MapUserAndUserRequest(RegisterRequest registerRequest);
        public  Task<IdentityResult> Register(RegisterRequest registerRequest);
    }
}
