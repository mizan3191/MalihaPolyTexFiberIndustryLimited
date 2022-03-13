using Autofac;
using MalihaPolyTex.Academy.BusinessObjects;
using MalihaPolyTex.Academy.Utilities;
using MalihaPolyTex.Web.Models;
using MalihaPolyTex.Web.Models.DepartmentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BO = MalihaPolyTex.Academy.BusinessObjects;

namespace MalihaPolyTex.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger, ILifetimeScope scope)
        {
            _scope = scope;
            _logger = logger;
        }
       
        public IActionResult Create()
        {
            var model = _scope.Resolve<CreateDepartmentModel>();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(CreateDepartmentModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    model.Resolve(_scope);
                    await model.CerateDepartmentAsync();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Department dosen't create.");
                }
            }

            return View(model);
        }

        public IActionResult Data()
        {
            var model = _scope.Resolve<DataDepartmentModel>();
            return View(model);
        }

        public async Task<JsonResult> GetDepartmentData()
        {
            var dataTable = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<DataDepartmentModel>();
            var data = await model.DepartmentListAsync(dataTable);

            return Json(data);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = _scope.Resolve<EditDepartmentModel>();
            if(ModelState.IsValid)
            {
                try
                {
                    await model.LoadDepartmentDataAsync(id);
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Department dosen't Load.");
                }
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditDepartmentModel model)
        {
            if(ModelState.IsValid)
            {
                model.Resolve(_scope);
                await model.UpdateDepartmentAsync();
            }

            return RedirectToAction(nameof(Data));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = _scope.Resolve<DataDepartmentModel>();

            await model.DeleteDepartmentAsync(id);
            return RedirectToAction(nameof(Data));
        }
        public IActionResult Enroll()
        {
            var model = _scope.Resolve<EnrollModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Enroll(EnrollModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    model.Resolve(_scope);

                    await model.EnrollStudentAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Doesn't Enroll student");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Form()
        {
            var model = _scope.Resolve<FormModel>();
            model.Resolve(_scope);
            await model.LoadStudenDataAsync();
            var studentList = model.StudentList;

            var studentName = (from y in studentList
                      select new SelectListItem()
                      {
                          Text = y.Name,
                          Value = y.Id.ToString()
                      }).ToList();


            studentName.Insert(0, new SelectListItem
            {
                Text = "--Select Student--",
                Value = String.Empty
            });

            var courseList = model.CourseList;

            var courseName = (from y in courseList
                               select new SelectListItem()
                               {
                                   Text = y.Title,
                                   Value = String.Empty
                               }).ToList();

            courseName.Insert(0, new SelectListItem
            {
                Text = "--Select course--",
                Value = String.Empty
            });

            ViewBag.messageCourse = courseName;
            ViewBag.messagestudent = studentName;
            return View(model);
        }

        public async Task<IActionResult> DropDown()
        {
            var model = _scope.Resolve<FormModel>();

            await model.LoadStudenDataAsync();
            var studentList = model.StudentList.ToList();

            studentList.Insert(0, new Student { Id = 0, Name = "Select Group" });

            ViewBag.messageStudent = studentList;
            return View(model);
        }

        public async Task<JsonResult> GetDeptName(int studentId)
        {
            var model = _scope.Resolve<FormModel>();

            if (ModelState.IsValid)
            {
                await model.DeptList(studentId);
            }

            return Json(new {model.DeptId, model.DeptName });
        }
    }
}