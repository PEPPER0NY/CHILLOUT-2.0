using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chillout.DataAccess.Core.Models
{
    [Table("User")]
    public class UserRto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
        public int MaxWinCountAce { get; set; }

        public List<HistoryGameRto> HistoryGamesLeftUser { get; set; }
        public List<HistoryGameRto> HistoryGamesRightUser { get; set; }
        public List<HistoryGameRto> HistoryGamesWinnerUser { get; set; }
        public List<HistoryMovement> HistoryMovementPlace { get; set; }
        public List<HistoryMovement> HistoryMovementTime { get; set; }
    }
}
