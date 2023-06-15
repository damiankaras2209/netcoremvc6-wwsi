using JiPP_2.Models;
using JiPP_2.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Diagnostics;

namespace JiPP_2.Controllers
{
    public class VehicleController : Controller
    {
        private VehicleManager _vehicleManager;

        public VehicleController(VehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }
        private void PopulateVievBag(VehicleModel vehicleModel = null)
        {
            var queryVendors = from d in _vehicleManager.GetVendors()
                               orderby d.Name
                               select d;
            var queryTransmissions = from d in _vehicleManager.GetTransmissions()
                                     orderby d.Name
                                     select d;

            ViewBag.VendorDicId = new SelectList(queryVendors, "Id", "Name", vehicleModel!=null ? vehicleModel.VendorDicId : null);
            ViewBag.TransmissionDicId = new SelectList(queryTransmissions, "Id", "Name", vehicleModel != null ? vehicleModel.TransmissionDicId : null);
        }

        public IActionResult Index()
        {
            return View(_vehicleManager.GetVehicles());
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateVievBag();
            return View();
        }

        [HttpPost]
        public IActionResult Create(VehicleModel vehicleModel)
        {
            try
            {
                _vehicleManager.AddVehicle(vehicleModel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var vehicleModel = _vehicleManager.GetVehicle(id);
            PopulateVievBag(vehicleModel);
            return View(vehicleModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var vehicleModel = _vehicleManager.GetVehicle(id);
            PopulateVievBag(vehicleModel);
            return View(vehicleModel);
        }

        [HttpPost]
        public IActionResult Edit(VehicleModel vehicleModel)
        {
            _vehicleManager.UpdateVehicle(vehicleModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_vehicleManager.GetVehicle(id));
        }

        [HttpPost]
        public IActionResult Delete(VehicleModel vehicleModel)
        {
            _vehicleManager.RemoveVehicle(vehicleModel);
            return RedirectToAction("Index");
        }
    }
}
