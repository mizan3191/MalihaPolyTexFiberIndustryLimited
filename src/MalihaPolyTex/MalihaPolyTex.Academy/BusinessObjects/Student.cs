using Microsoft.Extensions.Options;
using System;
using System.Collections;

namespace MalihaPolyTex.Academy.BusinessObjects
{
    public class Student
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int DeptId { get; set; } 
        public DateTime DateOfBirth { get; set; }
    }
}