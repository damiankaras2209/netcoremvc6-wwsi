using JiPP_2.Data;
using JiPP_2.Models;
using static JiPP_2.Models.DictionaryModel;

namespace JiPP_2.Repositories
{
    public class DictionaryManager
    {
        private ApplicationDbContext _context;

        public DictionaryManager(ApplicationDbContext context)
        { 
            _context = context;
        }

        public List<DictionaryModel> GetDictionaries()
        {
            return _context.Dictionaries.ToList();
        }

        public int GetDictionarySize(DictionaryType type)
        {
            return _context.DictionaryDetails.Where(dictionaryDetail => dictionaryDetail.Type == type).ToList().Count();
        }
    }
}
