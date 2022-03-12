﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chillout.DataAccess.Core.Models
{
    [Table("User")]
    public class UserRto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Login { get; set; }
        public int PassWord { get; set; }

    }

}

