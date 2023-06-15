using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JiPP_2.Models
{

    public class VehicleModel
    {
        public int Id { get; set; }
        [DisplayName("Marka")]
        public DictionaryDetailModel Vendor { get; set; }
        [ForeignKey("Vendor")]
        public int VendorDicId { get; set; }
        [DisplayName("Model")]
        public string Model { get; set; }
        [DisplayName("Rok produkcji")]
        public int ProductionYear { get; set; }
        [DisplayName("Skrzynia biegów")]
        public virtual DictionaryDetailModel Transmission { get; set; }
        [ForeignKey("Transmission")]
        public int TransmissionDicId { get; set; }
        [DisplayName("Stawka za dzień")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Rate { get; set; }
        [NotMapped]
        [DisplayName("Czy wypożyczony")]
        public bool isRented { get; set; }


    }

}
