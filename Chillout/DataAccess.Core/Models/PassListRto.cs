using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chillout.DataAccess.Core.Models
{
    [Table("PassList")]
    public class PassListRto
    {
        public int Id { get; set; }
        public string Website { get; set; }
        public string Login { get; set; }
        public string PassWord { get; set; }

        public ICollection<UserRto> Users { get; set; }        
        public PassListRto()
        {
            Users = new List<UserRto>();
        }
    }
}
