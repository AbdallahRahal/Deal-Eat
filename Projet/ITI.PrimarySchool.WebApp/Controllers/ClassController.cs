using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITI.PrimarySchool.DAL;
using Microsoft.AspNetCore.Mvc;

namespace ITI.PrimarySchool.WebApp.Controllers
{
    public class ClassController : Controller
    {
        readonly ClassGateway _classGateway;

        public ClassController(ClassGateway classGateway)
        {
            if (classGateway == null) throw new ArgumentNullException(nameof(classGateway));
            _classGateway = classGateway;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<ClassData> viewModel = await _classGateway.GetAll();
            return View(viewModel);
        }

        public async Task<IActionResult> Index(int id)
        {
            ClassData viewModel = await _classGateway.GetById(id);
            if(viewModel != null) return View(viewModel);

            return NotFound();
        }
    }
}
