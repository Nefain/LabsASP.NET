using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laba5.Managers.Stores;
using Laba5.Storage.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Laba5.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreManager _manager;
        public StoreController(IStoreManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<ViewResult> ShowStore()
        {
            var entity = await _manager.GetAll();
            return View(entity);
        }
        #region Create
        public async Task<ViewResult> CreateStore()
        {
            var entity = await _manager.GetAllProduct();
            ViewBag.ProductId = new SelectList(entity, "Id", "Name", entity.Select(it => it.Id));
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateStore(CreateOrUpdateStoreRequest request)
        {
            await _manager.AddStore(request);
            return RedirectToAction(nameof(ShowStore));
        }
        #endregion
        #region Edit
        [HttpGet]
        public async Task<ViewResult> EditStore(Store key)
        {
            var entity = await _manager.GetById(key.Id);
            var ent = await _manager.GetAllProduct();
            ViewBag.ProductId = new SelectList(ent, "Id", "Name", ent.Select(it => it.Id));
            return View(entity);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Store key, CreateOrUpdateStoreRequest request)
        {
            await _manager.EditStore(key.Id, request);
            return RedirectToAction(nameof(ShowStore));
        }
        #endregion

        #region Details
        [HttpGet]
        public async Task<ViewResult> DetailsStore(Store key)
        {
            var entity = await _manager.GetById(key.Id);
            return View(entity);
        }
        #endregion
        #region Delete
        [HttpGet]
        public async Task<ViewResult> DeleteStore(Store key)
        {
            var entity = await _manager.GetById(key.Id);
            return View(entity);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(Store key)
        {
            await _manager.DataRemove(key.Id);
            return RedirectToAction(nameof(ShowStore));
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}