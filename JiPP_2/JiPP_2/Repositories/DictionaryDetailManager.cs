using JiPP_2.Data;
using JiPP_2.Models;
using static JiPP_2.Models.DictionaryDetailModel;
using static JiPP_2.Models.DictionaryModel;

namespace JiPP_2.Repositories
{
    public class DictionaryDetailManager
    {
        private ApplicationDbContext _context;
        public DictionaryDetailManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public DictionaryDetailManager AddDictionaryDetail(DictionaryDetailModel dictionaryModel)
        {

            _context.DictionaryDetails.Add(dictionaryModel);
            _context.SaveChanges();
            return this;
        }

        public DictionaryDetailManager UpdateDictionaryDetail(DictionaryDetailModel dictionaryModel)
        {
            var model = GetDictionaryDetail(dictionaryModel.Id);
            model.Name = dictionaryModel.Name;
            model.isActive = dictionaryModel.isActive;
            _context.DictionaryDetails.Update(model);
            _context.SaveChanges();
            return this;
        }

        public DictionaryDetailManager RemoveDictionaryDetail(DictionaryDetailModel dictionaryModel)
        {
            _context.DictionaryDetails.Remove(dictionaryModel);
            _context.SaveChanges();
            return this;
        }

        public DictionaryModel GetDictionaryByType(DictionaryType type)
        {
            return _context.Dictionaries.SingleOrDefault(dictionary => dictionary.Id == type);
        }

        public DictionaryDetailModel GetDictionaryDetail(int id)
        {
            return _context.DictionaryDetails.SingleOrDefault(dictionaryDetail => dictionaryDetail.Id == id);
        }

        public List<DictionaryDetailModel> GetDictionaryDetails(DictionaryType type)
        {
            return _context.DictionaryDetails.Where(dictionaryDetail => dictionaryDetail.Type == type).ToList();
        }

    }
}
