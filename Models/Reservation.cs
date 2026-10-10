using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLibrary.Models
{
    public enum ReservationStatus
    {
        Pending,
        Ready,
        Fulfilled,
        Cancelled

    }
    public class Reservation
    {
        public int ResId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int BookId { get; set; }
        public DateTime ResDate { get; set; } = DateTime.UtcNow;
        public ReservationStatus ResStatus { get; set; } = ReservationStatus.Pending;

    }
}