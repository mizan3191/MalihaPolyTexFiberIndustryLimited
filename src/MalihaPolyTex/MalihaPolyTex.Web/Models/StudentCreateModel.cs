﻿using Autofac;
using MalihaPolyTex.Institute.BusinessObjects;
using MalihaPolyTex.Institute.Services;
using System;

namespace MalihaPolyTex.Web.Models
{
    public class StudentCreateModel
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        private ILifetimeScope _scope;
        private IStudentService _service;

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _service = _scope.Resolve<IStudentService>();

        }

        public StudentCreateModel(IStudentService service)
        {
            _service = service;
        }

        public StudentCreateModel()
        {

        }

        internal void CreateStudent()
        {
            var student = new Student()
            {
                Name = Name,
                DateOfBirth = DateOfBirth,
                DepartmentId = DepartmentId
            };

            _service.CreateStudent(student);
        }
    }
}