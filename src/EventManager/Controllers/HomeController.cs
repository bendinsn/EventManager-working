using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventManager.Data;
using EventManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EventManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(ApplicationDbContext _context, UserManager<ApplicationUser> um)
            {
            context = _context;
            userManager = um;
            }


        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }


        public IActionResult AddGenre()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddGenre(Genre g)
        {
            var genres = context.Genres;
            genres.Add(g);
            context.SaveChanges();
            //return RedirectToAction("Index");
            var genres2 = context.Genres.ToList();
            //return View("Index", genres2);
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> NewEvent(string returnUrl = null)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (!user.IsArtist) //Don't let anyone but artists register new events.
            {
                ViewBag.Notification = "Only Artists can register new events.";
                ViewBag.Color = "Red";
                return View("Index");
            }

            ViewData["ReturnUrl"] = returnUrl;
            ViewBag.Genres = context.Genres.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewEvent(Models.NewEventViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var newEvent = new Event {
                    Artist = await userManager.GetUserAsync(HttpContext.User),
                    EventName = model.EventName,
                    Time = model.Time,
                    Venue = model.Venue
                };
                var events = context.Events;
                events.Add(newEvent);
                context.SaveChanges();
                ViewBag.Notification = "Your event has been added.";
                ViewBag.Color = "Green";
            }
            else {
                ViewBag.Notification = "Something went wrong — Event not added.";
                ViewBag.Color = "Red";
            }
            return View("Index");
        }
    }
}
