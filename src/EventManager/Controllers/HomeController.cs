﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventManager.Data;
using EventManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

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
                    Venue = model.Venue,
                    GenreID = model.GenreID
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

        public IActionResult EventList()
        {
            var events = context.Events.ToList();
            ViewBag.genres = context.Genres.ToList();
            ViewBag.artists = context.Artists.ToList();
            return View(events);
        }

        public IActionResult EventListByArtist(string ID)
        {
            var events = context.Events.ToList();
            ViewBag.genres = context.Genres.ToList();
            ViewBag.artists = context.Artists.ToList();
            ViewBag.ID = ID;
            return View("EventList", events);
        }

        public IActionResult SearchByUser()
        {
            return View();
        }

        public IActionResult SubmitUserSearch(SearchByUserViewModel m)
        {
            return RedirectToAction("EventListByArtist", m.ID);
        }

        public IActionResult EventDetails(int ID)
        {
            //ViewBag.ID = ID;
            var events = context.Events;
            Event e = context.Events.Where(x => x.EventID == ID).Include(x => x.Artist).Include(x => x.Genre).FirstOrDefault();
            if (e == null)
            {
                ViewBag.Notification = "Something Went Wrong: No Such Event Found";
                return View("Index");
            }
            ViewBag.isYours = false;
            //ViewBag.Notification = "something went wrong: e.Artist is null. e.EventName is " + e.EventName;
            //return View("Index");
            if (e.Artist.Id == userManager.GetUserId(HttpContext.User))
            {
                ViewBag.isYours = true;
            }
            ViewBag.Event = e;
            return View();
        }

        public IActionResult DeleteEvent(int ID)
        {
            var events = context.Events;
            Event e = context.Events.Where(x => x.EventID == ID).Include(x => x.Artist).Include(x => x.Genre).FirstOrDefault();
            if (e == null)
            {
                ViewBag.Notification = "Something Went Wrong: No Such Event Found";
                return View("Index");
            }
            ViewBag.isYours = false;
            //ViewBag.Notification = "something went wrong: e.Artist is null. e.EventName is " + e.EventName;
            //return View("Index");
            if (e.Artist.Id == userManager.GetUserId(HttpContext.User))
            {
                ViewBag.isYours = true;
            }
            ViewBag.Event = e;
            return View();
        }

        public IActionResult DeleteConfirmed(int ID)
        {
            Event e = context.Events.Where(x => x.EventID == ID).Include(x => x.Artist).Include(x => x.Genre).FirstOrDefault();
            context.Events.Remove(e);
            context.SaveChanges();
            return RedirectToAction("EventList");
        }

        public async Task<IActionResult> EditEvent(int ID)
        {
            Event e = context.Events.Where(x => x.EventID == ID).Include(x => x.Artist).Include(x => x.Genre).FirstOrDefault();
            ViewBag.Event = e;
            ViewBag.genres = context.Genres.ToList();

            var user = await userManager.GetUserAsync(HttpContext.User);
            ViewBag.isYours = true;
            if (!user.UserName.Equals(e.Artist.UserName)) //Don't let anyone but artists register new events.
            {
                ViewBag.isYours = false;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditEvent(NewEventViewModel evm, int ID)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            ViewBag.genres = context.Genres.ToList();

            var events = context.Events.ToList();
            Event e = events.FirstOrDefault(x => x.EventID == ID);

            if (e.Artist.UserName == user.UserName)
            {
                e.EventName = evm.EventName;
                e.Artist = user;
                e.GenreID = evm.GenreID;
                e.Time = evm.Time;
                e.Venue = evm.Venue;
                ViewBag.Notification = "Event Data Changed.";
            }else
            {
                ViewBag.Notification = "You do not have access to edit this event.";
            }
            context.SaveChanges();

            return RedirectToAction("EventList");
        }

        [HttpPost]
        public IActionResult AddToCalendar(int ID)
        {
            var events = context.Events.ToList();
            Event _e = events.FirstOrDefault(x => x.EventID == ID);
            var calendars = context.Calendars.ToList();
            UserCalendar c = new UserCalendar
            {
                UserID = userManager.GetUserAsync(HttpContext.User).Result.UserName,
                EventID = _e.EventID
            };
            calendars.Add(c);
            context.SaveChanges();
            return View("Index");
        }

        public IActionResult MyCalendar(string ID)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            ViewBag.user = userManager.GetUserAsync(HttpContext.User).Result;
            ViewBag.eventIDs = context.Calendars.Where(x => x.UserID == user.UserName).Select(x => x.EventID).ToList();
            ViewBag.calendarView = true;
            ViewBag.genres = context.Genres.ToList();
            ViewBag.artists = context.Artists.ToList();
            var events = context.Events.ToList();
            return View("EventList", events);
        }
    }

}
