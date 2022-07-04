using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Controllers
{
    public class PersonController : Controller
    {
        public PersonController()
        {
            PersonModel[] persons = {
                new() { FirstName = "Hemangi "},
                new() { FirstName = "Sankudi"},
                new() { FirstName = "Ubo"}
            };

        }

        [HttpGet]
        public ViewResult ViewPerson()
        {

            return View();
        }
    }
}
