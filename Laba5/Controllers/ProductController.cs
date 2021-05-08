using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Laba5.Managers.Products;
using Laba5.Storage.Entity;
using Laba5.Storage;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laba5.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _manager;

        public ProductController(IProductManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<ViewResult> ShowProduct()
        {
            var entity = await _manager.GetAll();
            return View(entity);
        }
        #region Create
        public async Task<ViewResult> CreateProduct()
        {
            var ent = await _manager.GetAllTypeProduct();
            ViewBag.TypeProductId = new SelectList(ent, "Id", "Name", ent.Select(it => it.Id));
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateOrUpdateProductsRequest request)
        {
            await _manager.AddProduct(request);
            return RedirectToAction(nameof(ShowProduct));
        }
        #endregion

        #region Update
        [HttpGet]
        public async Task<ViewResult> EditProduct(Product key)
        {
            var entity = await _manager.GetById(key.Id);
            var ent = await _manager.GetAllTypeProduct();
            ViewBag.TypeProductId = new SelectList(ent, "Id", "Name", ent.Select(it => it.Id));
            return View(entity);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Product key, CreateOrUpdateProductsRequest request)
        {
            await _manager.EditProduct(key.Id, request);
            return RedirectToAction(nameof(ShowProduct));
        }
        #endregion

        #region Details
        [HttpGet]
        public async Task<ViewResult> DetailsProduct(Product key)
        {
            var entity = await _manager.GetById(key.Id);
            return View(entity);
        }
        #endregion
        #region Delete
        [HttpGet]
        public async Task<ViewResult> DeleteProduct(Product key)
        {
            var entity = await _manager.GetById(key.Id);
            return View(entity);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(Product key)
        {
            await _manager.DataRemove(key.Id);
            return RedirectToAction(nameof(ShowProduct));
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}