using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using static JiPP_2.Models.DictionaryModel;

namespace JiPP_2.Models
{
    public class DictionaryDetailModel
    {
        public int Id { get; set; }
        [DisplayName("Słownik")]
        public DictionaryType Type { get; set; }
        [DisplayName("Wartość")]
        public string Name { get; set; }
        [DisplayName("Czy aktywne")]
        public bool isActive { get; set; }
    }
}
