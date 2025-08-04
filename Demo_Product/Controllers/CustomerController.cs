using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Demo_Product.Controllers
{
    [Authorize]  // ← Buraya ekledik
    public class CustomerController : Controller
    {
        private readonly CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        private readonly JobManager jobManager = new JobManager(new EfJobDal());

        public IActionResult Index()
        {
            var values = customerManager.GetCustomersListWithJob();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            var values = jobManager.TGetList()
                                   .Select(x => new SelectListItem
                                   {
                                       Text = x.Name,
                                       Value = x.JobID.ToString()
                                   })
                                   .ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            var validationRules = new CustomerValidator();
            ValidationResult results = validationRules.Validate(p);
            if (results.IsValid)
            {
                customerManager.TInsert(p);
                return RedirectToAction("Index");
            }

            foreach (var item in results.Errors)
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

            return View(p);
        }

        public IActionResult DeleteCustomer(int id)
        {
            var value = customerManager.TGetById(id);
            customerManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var values = jobManager.TGetList()
                                   .Select(x => new SelectListItem
                                   {
                                       Text = x.Name,
                                       Value = x.JobID.ToString()
                                   })
                                   .ToList();
            ViewBag.v = values;

            var value = customerManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer p)
        {
            customerManager.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
