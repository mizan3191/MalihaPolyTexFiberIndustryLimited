using Autofac;
using MalihaPolyTex.Web.Models;
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

        public CourseController(ILifetimeScope scope, ILogger<CourseController> logger)
        {
            _scope = scope;
            _logger = logger;
        }
        
        public ActionResult Data()
        {
            var model = _scope.Resolve<CourseDataModel>();
            return View(model);
        }

        public async Task<JsonResult> GetData()
        {
            var dataTable = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<CourseDataModel>();
            model.Resolve(_scope);
            var data = await model.GetCourseListAsync(dataTable);

            return Json(data);
        }

        public ActionResult Create()
        {
            var model = _scope.Resolve<CourseCreateModel>();
            model.Resolve(_scope);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task< ActionResult> Create(CourseCreateModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Resolve(_scope);
                    await model.CreateAsync();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Course not created");

                }
            }

            return RedirectToAction(nameof(Data));
        }

        public async Task<ActionResult> Edit(int id)
        {
            var model = _scope.Resolve<CourseEditModel>();

            if (ModelState.IsValid)
            {
                try 
                {
                    await model.LoadCourseAsync(id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Course id doesn't load");
                }
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CourseEditModel model)
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
                    _logger.LogError(ex, "Course not updated");
                }
            }

            return RedirectToAction(nameof(Data));
        }

        public async Task<ActionResult> Delete(int id)
        {
            var model = _scope.Resolve<CourseCreateModel>();

            if (ModelState.IsValid)
            {
                try
                {
                    await model.DeleteAsync(id);
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Course doesn't delete");
                }
            }

            return RedirectToAction(nameof(Data));
        }
    }
}