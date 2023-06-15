using JiPP_2.Models;
using JiPP_2.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace JiPP_2.Controllers
{
    public class RentController : Controller
    {
        private RentManager _rentManager;

        public RentController(RentManager rentManager)
        {
            _rentManager = rentManager;
        }

        private void PopulateVievBag(RentModel rentModel = null)
        {

            var customers = _rentManager.GetCustomers().Select(x => new { Id = x.Id, Name = x.Name + " " + x.Surname }).OrderBy(x => x.Name);
            var vehicles = _rentManager.GetVehicles().Select(x => new { Id = x.Id, Name = x.Vendor.Name + " " + x.Model }).OrderBy(x => x.Name);
            var statuses = Enum.GetValues(typeof(RentModel.RentStatus)).Cast<RentModel.RentStatus>().Select(x => new { Id = x, Name = RentModel.RentStatusStrings[(int)x - 1] });

            ViewBag.CustomerId = new SelectList(customers, "Id", "Name", rentModel != null ? rentModel.CustomerId : null);
            ViewBag.VehicleId = new SelectList(vehicles, "Id", "Name", rentModel != null ? rentModel.VehicleId : null);
            ViewBag.StatusId = new SelectList(statuses, "Id", "Name", rentModel != null ? (int)rentModel.Status : null);
        }

        public IActionResult Index()
        {
            return View(_rentManager.GetRents());
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateVievBag();
            return View();
        }

        [HttpPost]
        public IActionResult Create(RentModel rentModel)
        {
            try
            {
                _rentManager.AddRent(rentModel);
                return RedirectToAction("Index");
            }
            catch (RentManager.VehicleAlreadyRentedException ex)
            {
                PopulateVievBag();
                ViewBag.Error = true;
                return View(rentModel);
            }
        }

        [HttpGet]
        public IActionResult Return(int id)
        {
            PopulateVievBag();
            return View(_rentManager.GetRent(id));
        }

        [HttpPost]
        public IActionResult Return(RentModel rentModel)
        {
            try
            {
                rentModel.Status = RentModel.RentStatus.ENDED;
                rentModel.ReturnDate = DateTime.Now;
                _rentManager.UpdateRent(rentModel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Cancel(int id)
        {
            PopulateVievBag();
            return View(_rentManager.GetRent(id));
        }

        [HttpPost]
        public IActionResult Cancel(RentModel rentModel)
        {
            try
            {
                rentModel.Status = RentModel.RentStatus.CANCELLED;
                _rentManager.UpdateRent(rentModel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PopulateVievBag();
            return View(_rentManager.GetRent(id));
        }

        [HttpPost]
        public IActionResult Edit(RentModel rentModel)
        {
            try
            {
                _rentManager.UpdateRent(rentModel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
