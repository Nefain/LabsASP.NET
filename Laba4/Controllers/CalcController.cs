using Microsoft.AspNetCore.Mvc;
using System;
using ООП_л3.Manager;
using ООП_л3.Models;


namespace ООП_л3.Controllers
{
    public class CalcController : Controller
    {

        [HttpGet]

        public ViewResult MainPage()

        {
            return View();
        }

        public IActionResult CalcPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalcPage(Calc model)
        {
            ModelState.Clear();
            if (model.Expression != null)
                model.Result = new CalcManager().Evaluate(model.Expression);
            return View(model);
        }
    }
}
