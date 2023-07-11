using AutoMapper;
using bank_website_backend.Entities;
using bank_website_backend.Model.Request;
using bank_website_backend.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace bank_website_backend.Services
{
    public class UserService :IUserService
    {
        IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public bool IsNameExsist(string name)
        {
            return _userRepository.IsNameExsist(name);
        }

        public User MapUserAndUserRequest(RegisterRequest registerRequest)
        {
            return _mapper.Map<User>(registerRequest);
        }
        public bool Register(User user)
        {
            return _userRepository.AddRecord(user);
        }
    }
} 