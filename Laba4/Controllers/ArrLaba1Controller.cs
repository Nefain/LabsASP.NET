using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ООП_л3.Manager;
using ООП_л3.Models;

namespace ООП_л3.Controllers
{
    public class ArrLaba1Controller : Controller
    {
        private IArrLaba1Manager _arrLaba1Manager;

        public ArrLaba1Controller(IArrLaba1Manager arrLaba1Manager)
        {
            _arrLaba1Manager = arrLaba1Manager;
        }

        public ViewResult ArrPage()
        {
            var arr = _arrLaba1Manager.ArrLaba1s;
            return View(arr);
        }

        public ViewResult MainPage()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Add(string num)
        {
            if (num == null)
                num = "0";
            ModelState.Clear();
            _arrLaba1Manager.ArrLaba1s.Add(new ArrLaba1(int.Parse(num)));
            return RedirectToAction(nameof(ArrPage));
        }

        public ActionResult Result(string Crat)
        {
            int k = Convert.ToInt32(Crat);
            var Result = _arrLaba1Manager.FuncOnLaba1(k);
            return RedirectToAction(nameof(ArrPage));
        }
    }
}