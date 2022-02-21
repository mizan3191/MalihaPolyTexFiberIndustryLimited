using Autofac;
using MalihaPolyTex.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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
            var model = _scope.Resolve<CourseCreateModel>();
            model.Resolve(_scope);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(CourseCreateModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Course not created");

                }
            }

            return View();

        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
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
    }
}