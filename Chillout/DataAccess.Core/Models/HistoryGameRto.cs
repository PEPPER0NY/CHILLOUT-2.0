using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chillout.DataAccess.Core.Models
{
    [Table("HistoryGame")]
    public class HistoryGameRto
    {
        public int Id { get; set; }

        public int LeftUserId { get; set; }
        public UserRto LeftUser { get; set; }

        public int RightUserId { get; set; }
        public UserRto RightUser { get; set; }

        public int WinnerUserId { get; set; }
        public UserRto WinnerUser { get; set; }

        public int AdditionMoney { get; set; }
        public DateTime DateTimeStamp { get; set; }
    }
}
