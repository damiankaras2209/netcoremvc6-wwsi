using JiPP_2.Models;
using JiPP_2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JiPP_2.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerManager _customerManager;

        public CustomerController(CustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        public IActionResult Index()
        {
            return View(_customerManager.GetCustomers());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerModel customerModel)
        {
            try
            {
                _customerManager.AddCustomer(customerModel);
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
            return View(_customerManager.GetCustomer(id));
        }

        [HttpPost]
        public IActionResult Edit(CustomerModel customerModel)
        {
            _customerManager.UpdateCustomer(customerModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_customerManager.GetCustomer(id));
        }

        [HttpPost]
        public IActionResult Delete(CustomerModel customerModel)
        {
            _customerManager.RemoveCustomer(customerModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_customerManager.GetCustomer(id));
        }
    }
}
