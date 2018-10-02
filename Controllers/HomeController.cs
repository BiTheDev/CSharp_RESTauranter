using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;
using Microsoft.EntityFrameworkCore;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        private RESTcontext _context;
        public HomeController(RESTcontext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
           return View("index");
        }

        [HttpPost]
        [Route("/write")]
        public IActionResult Write(restaurant Reviews){
            if(ModelState.IsValid){ 
            Reviews.created_at = DateTime.Now;   
            Reviews.updated_at = DateTime.Now;
            if(Reviews.VisitDate > DateTime.Today){
                ModelState.AddModelError("VisitDate", "Date cannot be set to future!");
                return View("index");
            }                         
            _context.Add(Reviews);
            _context.SaveChanges();
            return RedirectToAction("Reviews");
            }else{
                return View("index");
            }
            
            
        }

        [HttpGet]
        [Route("/reviews")]
        public IActionResult Reviews(){
            // List<restaurant> allRestaurant = _context.Restaurant.ToList();
            List<restaurant> allRestaurant = _context.Restaurant.OrderByDescending(p => p.Id).ToList();
            ViewBag.allRestaurant = allRestaurant;
            return View("review");
        }

        
    }
}
