using Autofac;
using MalihaPolyTex.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILifetimeScope scope,
            ILogger<StudentController> logger)
        {
            _scope = scope;
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Data()
        {
            var model = _scope.Resolve<StudentDataModel>();
            return View(model);
        }

        public async Task< JsonResult> GetData()
        {
            var model = _scope.Resolve<StudentDataModel>();
            var dataTable = new DataTablesAjaxRequestModel(Request);
            var data = await model.GetStudentListAsync(dataTable);
            return Json(data);
        }

        public ActionResult Create()
        {
            var model = _scope.Resolve<StudentCreateModel>();
            model.Resolve(_scope);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StudentCreateModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Resolve(_scope);
                    await model.CreateStudentAsync();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Student not created");
                }
            }

            return RedirectToAction(nameof(Data));
        }

        public async Task<ActionResult> Edit(int id)
        {
            var model = _scope.Resolve<StudentEditModel>();

            if (ModelState.IsValid)
            {
                try
                {
                    await model.LoadStudentAsync(id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Student doesn't  load");
                }
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task< ActionResult> Edit(StudentEditModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Resolve(_scope);
                    await model.UpdateAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Student doesn't exist");
                }
            }

            return RedirectToAction(nameof(Data));
        }

        public async Task<ActionResult> Delete(int id)
        {
            var model = _scope.Resolve<StudentDataModel>();

            if (ModelState.IsValid)
            {
                try
                {
                    model.Resolve(_scope);
                    await model.DeleteAsync(id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Student doesn't exist");
                }
            }

            return RedirectToAction(nameof(Data));
        }
    }
}