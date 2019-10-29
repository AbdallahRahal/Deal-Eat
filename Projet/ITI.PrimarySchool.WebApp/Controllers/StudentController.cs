using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITI.PrimarySchool.DAL;
using Microsoft.AspNetCore.Mvc;

namespace ITI.PrimarySchool.WebApp.Controllers
{
    public class StudentController : Controller
    {
        readonly StudentGateway _studentGateway;

        public StudentController(StudentGateway studentGateway)
        {
            if (studentGateway == null) throw new ArgumentNullException(nameof(studentGateway));
            _studentGateway = studentGateway;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<StudentData> students = await _studentGateway.GetAll();
            return View(students);
        }
    }
}