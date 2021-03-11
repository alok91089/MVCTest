using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCDateApp.Helper;
using MVCDateApp.Models;

namespace MVCDateApp.Controllers
{
    public class DateController : Controller
    {
        private readonly IDateHelper _dateHelper;
        private readonly IValidator _validator;

        public DateController(IDateHelper dateHelper, IValidator validator)
        {
            _dateHelper = dateHelper;
            _validator = validator;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Post(DateViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View("Index");
            }

            if (!_validator.Validate(model.StartDate))
            {
                model.ErrorMessage = string.Format("Start Date is not a valid date.");
                return View("Index", model);
            }

            if (!_validator.Validate(model.EndDate))
            {
                model.ErrorMessage = string.Format("End Date is not a valid date.");
                return View("Index", model);
            }

            model.Difference = _dateHelper.GetDifference(model.StartDate, model.EndDate);
            return View("Index", model);
        }


    }
}