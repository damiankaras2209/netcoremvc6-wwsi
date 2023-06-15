using System.ComponentModel;

namespace JiPP_2.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [DisplayName("Imię")]
        public String Name { get; set; }
        [DisplayName("Nazwisko")]
        public String Surname { get; set; }
        [DisplayName("PESEL")]
        public String Pesel { get; set; }
        [DisplayName("Ulica")]
        public String Street { get; set; }
        [DisplayName("Nr budynku")]
        public String StreetNumber { get; set; }
        [DisplayName("Kod pocztowy")]
        public String PostCode { get; set; }
        [DisplayName("Miejscowość")]
        public String City { get; set; }
        [DisplayName("Telefon")]
        public String Phone { get; set; }
        [DisplayName("Email")]
        public String Email { get; set; }


    }
}
