using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Library;
using PizzaApp.WebApp.Models;

namespace PizzaApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public PizzaRepository Repo { get; }

        public HomeController(PizzaRepository repo)
        {
            Repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }


        // GET: Home/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Home/Login
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repoUsers = Repo.GetUsers().ToList();
                    var searchedUser = new Library.User();
                    int searchedUserId = 0;
                    bool found = false;

                    if(login.FirstName == "Admin" && login.LastName == "Mama")
                    {
                        return RedirectToAction(nameof(Index), "Home/Admin");
                    }

                    foreach (var user in repoUsers)
                    {
                        if (login.FirstName == user.FirstName && login.LastName == user.LastName)
                        {
                            searchedUser = user;
                            searchedUserId = user.Id;
                            found = true;
                            TempData["UserId"] = user.Id;
                            TempData["DefaultLocationId"] = user.DefaultLocation;
                            if (user.LatestOrderId != null)
                            {
                                var latestOrder = Repo.GetOrderById((int)user.LatestOrderId);
                                TempData["LatestPizzaCount"] = latestOrder.CountPizzas();
                                TempData["LatestOrderTime"] = latestOrder.DateTime;
                                TempData["LatestOrderLocation"] = latestOrder.LocationId;
                            }
                        }
                    }
                    if (!found)
                    {
                        return RedirectToAction(nameof(Index), "User/Create");
                    }

                    return RedirectToAction(nameof(Index), "Order/Create");
                }
                return RedirectToAction(nameof(Index), "Order/Create");
            }
            catch
            {
                return View();
            }
        }


        public IActionResult Admin()
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

        public IActionResult Privacy()
        {
            return View();
        }
                
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
