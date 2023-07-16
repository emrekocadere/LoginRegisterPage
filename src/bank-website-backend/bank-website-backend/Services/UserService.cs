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
        public bool Register(RegisterRequest user)
        {
            if(!IsNameExsist(user.Name))
            {
                return _userRepository.AddRecord(new User {Name=user.Name,Password=user.Password});          
            }
            else
            {
                return false;
            }
        }
    }
} 