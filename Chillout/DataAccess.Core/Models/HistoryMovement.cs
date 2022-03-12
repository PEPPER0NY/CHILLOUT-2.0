using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chillout.DataAccess.Core.Models
{
    [Table("HistoryMovement")]
    public class HistoryMovement
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string PlaceId { get; set; }
        public UserRto Place { get; set; }

        public int TimeId { get; set; }
        public UserRto Time { get; set; }
        public DateTime DateTimeStamp { get; set; }

        public List<HistoryMovement> HistoryMovementPlace { get; set; }
        public List<HistoryMovement> HistoryMovementTime { get; set; }
        

    }
}
