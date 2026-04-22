using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    internal class UserService(IUserRepository userRepository) : IUserService
    {
        
    }
}
