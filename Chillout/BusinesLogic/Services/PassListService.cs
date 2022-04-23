using Chillout.BusinesLogic.Core.Interfaces;
using Chillout.BusinesLogic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chillout.BusinesLogic.Services
{
    public class PassListService : IPassListService
    {
        public Task<bool> DoesExist(string Email, string Login)
        {
            throw new NotImplementedException();
        }

        public Task<UserInformationBlo> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<UserInformationBlo> Update(string Website, string Login, string PassWord, UserUpdateBlo userUpdateBlo)
        {
            throw new NotImplementedException();
        }
    }
}

