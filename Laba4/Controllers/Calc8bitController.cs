using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ООП_л3.Manager;
using ООП_л3.Models;

namespace ООП_л3.Controllers
{
    public class Calc8bitController : Controller
    {
        [HttpGet]

        public ViewResult MainPage()

        {
            return View();
        }

        public IActionResult Calc8bitPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calc8bitPage(Calc8bit model)
        {
            ModelState.Clear();
            if(new Calc8bitManager().TryIsIt8(model.NumberA, (int)model.SystemNum) || new Calc8bitManager().TryIsIt8(model.NumberB, (int)model.SystemNum))
            {
                model.Result = 0;
                return View(model);
            }
            switch (model.OperationType8bit)
            {
                case OperationType8bit.Addition:
                    model.Result = new Calc8bitManager().Sum(model);
                    break;
                case OperationType8bit.Subtraction:
                    model.Result = new Calc8bitManager().Sub(model);
                    break;
                case OperationType8bit.Multiplication:
                    model.Result = new Calc8bitManager().Mult(model);
                    break;
                case OperationType8bit.Division:
                    model.Result = new Calc8bitManager().Div(model);
                    break;
                case OperationType8bit.Mod:
                    model.Result = new Calc8bitManager().Mod(model);
                    break;
            }
            return View(model);
        }
    }
}