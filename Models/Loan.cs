using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eLibrary.Models
{
    // Klass för lån
    public class Loan
    {
        public int LoanId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
        public DateTime LoanDate { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }

        // Räkna ut antal dagar kvar av lån
        [NotMapped]
        public int DaysRemaining => (DueDate.Date - DateTime.Today).Days;

        // Status på lån
        public string Status
        {
            get
            {
                if (ReturnedDate.HasValue)
                {
                    return "Återlämnad";
                }

                if (DateTime.UtcNow > DueDate)
                {
                    return "Försenad";
                }

                return "Utlånad";
            }
        }
    };
}