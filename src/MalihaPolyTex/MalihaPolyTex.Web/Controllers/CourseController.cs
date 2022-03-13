using Autofac;
using MalihaPolyTex.Academy.Utilities;
using MalihaPolyTex.Web.Models.CourseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger, ILifetimeScope scope)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Create()
        {
            var model = _scope.Resolve<CreateCourseModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCourseModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);

                try
                {
                    await model.CreateCourseAsync();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Course dosen't create.");
                }
            }
            return View(model);
        }
        public IActionResult Data()
        {
            var model = _scope.Resolve<DataCourseModel>();
            return View(model);
        }
        public async Task<JsonResult> GetCourseData()
        {
            var dataTable = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<DataCourseModel>();
            var data = await model.CourseListAsync(dataTable);

            return Json(data);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var model = _scope.Resolve<EditCourseModel>();

            if (ModelState.IsValid)
            {
                try
                {
                    await model.LoadCourseDataAsync(id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Course dosen't Load.");
                }
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCourseModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                await model.UpdateCourseAsync();
            }
            return RedirectToAction(nameof(Data));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = _scope.Resolve<DataCourseModel>();

            await model.DeleteCourseAsync(id);
            return RedirectToAction(nameof(Data));
        }
    }
}
