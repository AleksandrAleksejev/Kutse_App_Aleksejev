
using Kutse_App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kutse_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int mouth = DateTime.Now.Month;
            int hour = DateTime.Now.Hour;
            if (hour > 6 && hour < 12)
            {
                ViewBag.Greeting = "Tere hommikust!";
            }
            else if (hour > 12 && hour < 18)
            {
                ViewBag.Greeting = "Tere päevast!";
            }
            else if (hour > 18 && hour < 0)
            {
                ViewBag.Greeting = "Tere õhtust!";
            }
            else
            {
                ViewBag.Greeting = "On aeg magada, öösel inimesed ja programm magasid!";
            }
            
            return View();
        }
        [HttpGet]
        public ViewResult Ankeet()
        {
            return View();
        }
        [HttpPost]

        public ViewResult Ankeet(Guest guest)
        {
            E_mail(guest);
            if (ModelState.IsValid)
            {
                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
        }

        public void E_mail(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "sashaaleksejev813577@gmail.com";
                WebMail.Password = "Kukuruku813577";
                WebMail.From = "sashaaleksejev813577@gmail.com";
                WebMail.Send(guest.Email, "Vastus kutsele", guest.Name + "vastas" + ((guest.WillAttend ?? false) ?
                     "tuleb peole" : "ei tule peole"));
                ViewBag.Message = "Kiri on saatnud!";        
            }
            catch (Exception)
            {

                ViewBag.Message = "Mul on kahju! Ei saa  kirja saatnud!";
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            
            return View();
        }

    }
}

