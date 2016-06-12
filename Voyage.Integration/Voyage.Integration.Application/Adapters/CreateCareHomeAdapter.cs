using System;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;

namespace Voyage.Integration.Application.Adapters
{
    public class CreateCareHomeAdapter : ICreateCareHomeAdapter
    {
        IHomeRepository _homeRepository;

        public CreateCareHomeAdapter(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public int CreateHome(string homeName, string executingUser)
        {
            if(string.IsNullOrEmpty(executingUser))
            {
                return CreateHomeInRepository(homeName, Environment.UserName);
            }

            return CreateHomeInRepository(homeName, executingUser);
        }

        private int CreateHomeInRepository(string homeName, string executingUser)
        {
            return _homeRepository.CreateHome(homeName, executingUser);
        }
    }
}
