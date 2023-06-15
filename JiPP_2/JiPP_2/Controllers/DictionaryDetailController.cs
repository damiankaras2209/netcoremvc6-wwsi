using JiPP_2.Data;
using JiPP_2.Models;
using JiPP_2.Repositories;
using Microsoft.AspNetCore.Mvc;
using static JiPP_2.Models.DictionaryModel;

namespace JiPP_2.Controllers
{
    public class DictionaryDetailController : Controller
    {
        DictionaryDetailManager _dictionaryDetailManager;

        public DictionaryDetailController(DictionaryDetailManager dictionaryDetailManager)
        {
            _dictionaryDetailManager = dictionaryDetailManager;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var type = (DictionaryType)Enum.ToObject(typeof(DictionaryType), id);
            ViewData["DictionaryName"] = _dictionaryDetailManager.GetDictionaryByType(type).Name;
            ViewData["DictionaryId"] = id;
            var dictionaryDetails = _dictionaryDetailManager.GetDictionaryDetails(type);
            return View(_dictionaryDetailManager.GetDictionaryDetails(type));
        }

        [HttpGet]
        public IActionResult Create(int type)
        {
            ViewData["DictionaryType"] = type;
            return View();
        }

        [HttpPost]
        public IActionResult Create(DictionaryDetailModel dictionaryDetailModel)
        {
            _dictionaryDetailManager.AddDictionaryDetail(dictionaryDetailModel);
            return RedirectToAction("Index", new { id = (int)_dictionaryDetailManager.GetDictionaryDetail(dictionaryDetailModel.Id).Type });
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var dictionaryDetailModel = _dictionaryDetailManager.GetDictionaryDetail(id);
            var type = (DictionaryType)Enum.ToObject(typeof(DictionaryType), dictionaryDetailModel.Type);
            ViewData["DictionaryName"] = _dictionaryDetailManager.GetDictionaryByType(type).Name;
            return View(dictionaryDetailModel);
        }

        [HttpPost]
        public IActionResult Edit(DictionaryDetailModel dictionaryDetailModel) 
        {
            _dictionaryDetailManager.UpdateDictionaryDetail(dictionaryDetailModel);
            return RedirectToAction("Index", new {id = (int)dictionaryDetailModel.Type});
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var dictionaryDetailModel = _dictionaryDetailManager.GetDictionaryDetail(id);
            var type = (DictionaryType)Enum.ToObject(typeof(DictionaryType), dictionaryDetailModel.Type);
            ViewData["DictionaryName"] = _dictionaryDetailManager.GetDictionaryByType(type).Name;
            return View(dictionaryDetailModel);
        }

        [HttpPost]
        public IActionResult Delete(DictionaryDetailModel dictionaryDetailModel) 
        {
            var model = _dictionaryDetailManager.GetDictionaryDetail(dictionaryDetailModel.Id);
            _dictionaryDetailManager.RemoveDictionaryDetail(model);
            return RedirectToAction("Index", new { id = (int)model.Type});
        }
    }
}
