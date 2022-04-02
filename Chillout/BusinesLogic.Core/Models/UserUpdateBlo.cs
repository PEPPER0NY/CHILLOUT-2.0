using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chillout.BusinesLogic.Core.Models
{
    public class UserUpdateBlo
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string AvatarUrl { get; set; }
        public string Introduction { get; set; }
    }
}
