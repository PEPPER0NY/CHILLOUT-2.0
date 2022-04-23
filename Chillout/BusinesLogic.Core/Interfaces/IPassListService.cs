using Chillout.BusinesLogic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chillout.BusinesLogic.Core.Interfaces
{
    interface IPassListService
    {
        Task<UserInformationBlo> Get(int UserId);
        Task<UserInformationBlo> Update(string Website, string Login, string PassWord, UserUpdateBlo userUpdateBlo);
        Task<bool> DoesExist(string Email, string Login);
    }
}
