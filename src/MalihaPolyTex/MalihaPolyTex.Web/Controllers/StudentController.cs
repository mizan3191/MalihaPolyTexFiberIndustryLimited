using Autofac;
using MalihaPolyTex.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            var model = _scope.Resolve<StudentCreateModel>();
            model.Resolve(_scope);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(StudentCreateModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);

                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Student not created");
                }
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
