using bank_website_backend.Entities;
using bank_website_backend.Repository;
using System.Globalization;

namespace bank_website_backend.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool IsNameExsist(string name)
        {
            return _userRepository.IsNameExsist(name);
        }
    }
}
