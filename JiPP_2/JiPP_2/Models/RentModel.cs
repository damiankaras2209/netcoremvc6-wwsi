using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace JiPP_2.Models
{
    public class RentModel
    {

        public enum RentStatus
        {
            ACTIVE = 1,
            CANCELLED = 2,
            ENDED = 3,
        }

        public static List<String> RentStatusStrings = new List<String>()
        {
            "Aktywne", "Anulowane", "Zakończone"
        };

        public int Id { get; set; }
        [DisplayName("Samochód")]
        public VehicleModel Vehicle { get; set; }
        public int VehicleId { get; set; }
        [DisplayName("Klient")]
        public CustomerModel Customer { get; set; }
        public int CustomerId { get; set; }
        [DisplayName("Data startu")]
        public DateTime StartDate { get; set; }
        [DisplayName("Data zakończenia")]
        public DateTime EndDate { get; set; }
        [DisplayName("Data zwrotu")]
        public DateTime? ReturnDate { get; set; }
        [DisplayName("Status")]
        public RentStatus Status { get; set; }
        public string StatusName
        {
            get
            {
                return (Status.ToString());/*RentStatusStrings[((int)Status) - 1] ?? Status.ToString();*/
            }
        }

        [NotMapped]
        [DisplayName("Koszt")]
        public decimal Cost
        {
            get
            {
                if (ReturnDate != null)
                {
                    return Decimal.Multiply(Vehicle.Rate, (decimal)Math.Ceiling(((DateTime)ReturnDate - StartDate).TotalDays));
                }
                return 0.0m;
            }
        }

    }
}
