using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laba5.Managers.TypeProducts;
using Laba5.Storage.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Laba5.Controllers
{
    public class TypeProductController : Controller
    {
        private readonly ITypeProductManager _manager;

        public TypeProductController(ITypeProductManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<ViewResult> ShowTypeProduct()
        {
            var entity = await _manager.GetAll();
            return View(entity);
        }
        #region Create
        public  ViewResult CreateTypeProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateTypeProduct(CreateOrUpdateTypeProductRequest request)
        {
            await _manager.AddTypeProduct(request);
            return RedirectToAction(nameof(ShowTypeProduct));
        }
        #endregion

        #region Update
        [HttpGet]
        public async Task<ViewResult> EditTypeProduct(TypeProduct key)
        {
            var entity = await _manager.GetById(key.Id);
            return View(entity);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(TypeProduct key, CreateOrUpdateTypeProductRequest request)
        {
            await _manager.EditTypeProduct(key.Id, request);
            return RedirectToAction(nameof(ShowTypeProduct));
        }
        #endregion

        #region Details
        [HttpGet]
        public async Task<ViewResult> DetailsTypeProduct(TypeProduct key)
        {
            var entity = await _manager.GetById(key.Id);
            return View(entity);
        }
        #endregion
        #region Delete
        [HttpGet]
        public async Task<ViewResult> DeleteTypeProduct(TypeProduct key)
        {
            var entity = await _manager.GetById(key.Id);
            return View(entity);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(TypeProduct key)
        {
            await _manager.DataRemove(key.Id);
            return RedirectToAction(nameof(ShowTypeProduct));
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}