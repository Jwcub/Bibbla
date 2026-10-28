using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLibrary.Models
{
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