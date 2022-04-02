using Chillout.BusinesLogic.Core.Interfaces;
using Chillout.BusinesLogic.Core.Models;
using System;
using System.Threading.Tasks;

namespace Chillout.BusinesLogic.Services
{
    public class UserService : IUserService
    {
        public Task<bool> DoesExist(string Email, string Login)
        {
            throw new NotImplementedException();
        }

        public Task<UserInformationBlo> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<UserInformationBlo> Registration(string Email, string Login, string PassWord)
        {
            throw new NotImplementedException();
        }

        public Task<UserInformationBlo> Update(string Email, string Login, string PassWord, UserUpdateBlo userUpdateBlo)
        {
            throw new NotImplementedException();
        }
    }
}
