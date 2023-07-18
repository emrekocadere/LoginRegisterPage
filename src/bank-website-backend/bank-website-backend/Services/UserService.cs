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
        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<TUser> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IdentityResult> Register(RegisterRequest registerRequest)
        {
            return await _userManager.CreateAsync(new TUser() {
                UserName=registerRequest.Name,
                Email=registerRequest.Email,
                PhoneNumber=registerRequest.Phone,       
            },registerRequest.Password);
        }
    }
} 