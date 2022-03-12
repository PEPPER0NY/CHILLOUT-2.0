using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chillout.DataAccess.Core.Models
{
    [Table("User")]
    public class PassListRto
    {
        public int Website { get; set; }
        public int Login { get; set; }
        public int PassWord { get; set; }
    }
}
