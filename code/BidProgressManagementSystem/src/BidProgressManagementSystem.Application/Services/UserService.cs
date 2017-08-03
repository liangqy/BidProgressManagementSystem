using BidProgressManagementSystem.EntityFramework;
using BidProgressManagementSystem.EntityFramework.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;



namespace BidProgressManagementSystem.Application.Services
{

    
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        public User CheckUser(string userName, string password)
        {
            return _repository.CheckUser(userName, password);
        }

    }
}
