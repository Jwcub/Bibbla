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
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
        public DateTime ResDate { get; set; } = DateTime.UtcNow;
        public ReservationStatus ResStatus { get; set; } = ReservationStatus.Pending;
    }
}