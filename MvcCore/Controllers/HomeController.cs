using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcCore.Models;
using MvcCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [Route("")]
        [Route("/Home")]
        [Route("/Home/Index")]
        public ViewResult Index()
        {
           
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
            
        }

        
        [Route("Home/Details/{id?}")]
        public ViewResult Details(int id)
        {
            /*Employee model = _employeeRepository.GetEmployee(1);//default view of employee having id=1
            //return _employeeRepository.GetEmployee(1).Name;
            //return View("Test");
            ViewBag.PageTitle = "Emplyee Details (view bag title)";*/

            Employee employee = _employeeRepository.GetEmployee(id);
            if(employee== null)
            {
                Response.StatusCode = 404;
                return View("Home/Error");
            }

                HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
                {
                    Employee = _employeeRepository.GetEmployee(id),
                    PageTitle = "Employee Details"
                };

                return View(homeDetailsViewModel);
           
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid) {
                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("Details", new { id = newEmployee.Id });
            }
            return View();
        }
        public IActionResult Error()
        {
           // return View();
           return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
