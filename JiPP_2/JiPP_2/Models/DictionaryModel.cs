using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace JiPP_2.Models
{
    public class DictionaryModel
    {

        public enum DictionaryType
        {
            VENDOR = 1,
            TRANSMISISON = 2,
        }

        public DictionaryType Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }

        [NotMapped]
        [DisplayName("Liczba elementów")]
        public int Size { get; set; }
    }
}
