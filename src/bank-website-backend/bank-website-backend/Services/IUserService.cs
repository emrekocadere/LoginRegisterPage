using bank_website_backend.Entities;
using bank_website_backend.Model.Request;
using Microsoft.AspNetCore.Identity;

namespace bank_website_backend.Services
{
    public interface IUserService
    {

        public  Task<IdentityResult> Register(RegisterRequest registerRequest);
        public  Task<SignInResult> Login(LoginRequest loginRequest);
        public  Task<TUser> IsUserExist(string userName);
    }
}
