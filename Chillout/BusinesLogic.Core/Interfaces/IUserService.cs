using Chillout.BusinesLogic.Core.Models;
using System.Threading.Tasks;

namespace Chillout.BusinesLogic.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserInformationBlo> Registration(string Email, string Login, string PassWord);
        Task<UserInformationBlo> Get(int UserId);
        Task<UserInformationBlo> Update(string Email, string Login, string password, UserUpdateBlo userUpdateBlo);
        Task<bool> DoesExist(string Email, string Login);
    }
}
