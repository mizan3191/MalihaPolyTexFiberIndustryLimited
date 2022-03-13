using Autofac;
using MalihaPolyTex.Academy.Utilities;
using MalihaPolyTex.Web.Models;
using MalihaPolyTex.Web.Models.StudentModel;
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

        public StudentController(ILogger<StudentController> logger, ILifetimeScope scope)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Create()
        {
            var model = _scope.Resolve<CreateStudentModel>();
            model.A();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentModel model)
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
                    _logger.LogError(ex, "Student doesn't create");
                }
            }
            return View();
        }

        public IActionResult Data()
        {
            var model = _scope.Resolve<DataStudentModel>();
            return View(model);
        }

        public async Task<JsonResult> GetStudentData()
        {
            var dataTable = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<DataStudentModel>();
            var data = await model.StudentListAsync(dataTable);

            return Json(data);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var model = _scope.Resolve<EditStudentModel>();
            await model.LoadStudentDataAsync(id);

            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditStudentModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Resolve(_scope);
                    await model.UpdateStudentAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Student update failed");
                }
            }
            return RedirectToAction(nameof(Data));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var model = _scope.Resolve<DataStudentModel>();
            await model.DeleteStudentAsync(id);
            return RedirectToAction(nameof(Data));
        }
    }
}
