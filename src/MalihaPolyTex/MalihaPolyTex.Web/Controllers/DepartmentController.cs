using Autofac;
using MalihaPolyTex.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILifetimeScope scope,
            ILogger<DepartmentController> logger)
        {
            _scope = scope;
            _logger = logger;
        }

        public ActionResult Data()
        {
            var model = _scope.Resolve<DepartmentDataModel>();
            return View(model);
        }

        public async Task<JsonResult> GetData()
        {
            var dataTable = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<DepartmentDataModel>();
            var data = await model.GetDepartmentListAsync(dataTable);

            return Json(data);
        }

        public IActionResult Create()
        {
            var model = _scope.Resolve<DepartmentCreateModel>();
            
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentCreateModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Resolve(_scope);
                    await model.CreateDepartmentAsync();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Department doesn't create");
                }
            }

            return RedirectToAction(nameof(Data));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = _scope.Resolve<DepartmentEditModel>();

            if (ModelState.IsValid)
            {
                try
                {
                   await model.LoadDataAsync(id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Data doesn't loaded");
                }
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DepartmentEditModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Resolve(_scope);
                    await model.UpdateAsync();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Update failed");
                }
            }

            return RedirectToAction(nameof(Data));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = _scope.Resolve<DepartmentDataModel>();

            if (ModelState.IsValid)
            {
                try
                {
                    await model.DeleteAsync(id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Delete failed");
                }
            }

            return RedirectToAction(nameof(Data));
        }
    }
}