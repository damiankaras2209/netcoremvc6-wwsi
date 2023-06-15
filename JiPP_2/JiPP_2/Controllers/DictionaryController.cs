using JiPP_2.Models;
using JiPP_2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JiPP_2.Controllers
{
    public class DictionaryController : Controller
    {
        private DictionaryManager _dictionaryManager;

        public DictionaryController(DictionaryManager dictionaryManager)
        {
            _dictionaryManager = dictionaryManager;
        }
        public ActionResult Index() 
        {
            var dictionaries = _dictionaryManager.GetDictionaries();
            foreach (var dictionary in dictionaries)
                dictionary.Size = _dictionaryManager.GetDictionarySize(dictionary.Id);
            return View(dictionaries);
        }
    }
}
