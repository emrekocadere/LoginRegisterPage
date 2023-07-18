using AutoMapper;
using bank_website_backend.Entities;
using bank_website_backend.Model.Request;
using bank_website_backend.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace bank_website_backend.Services
{
    public class UserService :IUserService
    {
        IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<TUser> _userManager; 
        private readonly SignInManager<TUser> _signInManager;
        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<TUser> userManager,SignInManager<TUser> signInManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Register(RegisterRequest registerRequest)
        {
            return await _userManager.CreateAsync(new TUser() {
                UserName=registerRequest.Name,
                Email=registerRequest.Email,
                PhoneNumber=registerRequest.Phone,       
            },registerRequest.Password);
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(LoginRequest loginRequest)
        {
            return await _signInManager.PasswordSignInAsync(loginRequest.Name, loginRequest.Password,false,true);
        }
    }
} 