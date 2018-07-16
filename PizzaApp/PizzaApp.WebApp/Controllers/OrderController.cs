using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Context;
using PizzaApp.Library;

namespace PizzaApp.WebApp.Controllers
{
    public class OrderController : Controller
    {

        public PizzaRepository Repo { get; }

        public OrderController(PizzaRepository repo)
        {
            Repo = repo;
        }

        // Order Builder
        public IActionResult Builder()
        {
            return View();
        }

        // GET: Order
        public ActionResult Index(string searchString)
        {
            var libOrders = Repo.GetOrders();
            var webOrders = libOrders.Select(x => new Order
            {
                Id = x.Id,
                UserId = x.UserId,
                LocationId = x.LocationId,
                DateTime = x.DateTime,
                Price = x.Price,
                PizzaId1 = x.PizzaId1,
                PizzaId2 = x.PizzaId2,
                PizzaId3 = x.PizzaId3,
                PizzaId4 = x.PizzaId4,
                PizzaId5 = x.PizzaId5,
                PizzaId6 = x.PizzaId6,
                PizzaId7 = x.PizzaId7,
                PizzaId8 = x.PizzaId8,
                PizzaId9 = x.PizzaId9,
                PizzaId10 = x.PizzaId10,
                PizzaId11 = x.PizzaId11,
                PizzaId12 = x.PizzaId12
            });

            // SEARCH
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower(); // search is case insensitive
                // search based on either user id or location name
                if (searchString == "reston") webOrders = webOrders.Where(s => s.LocationId == 1);
                else if (searchString == "herndon") webOrders = webOrders.Where(s => s.LocationId == 2);
                else if (searchString == "sterling") webOrders = webOrders.Where(s => s.LocationId == 3);
                else webOrders = webOrders.Where(s => s.UserId.ToString() == searchString);
                
            }

            return View(webOrders);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            var libOrder = Repo.GetOrderById(id);
            var webOrder = new Order
            {
                Id = libOrder.Id,
                UserId = libOrder.UserId,
                LocationId = libOrder.LocationId,
                DateTime = libOrder.DateTime,
                Price = libOrder.Price,
                PizzaId1 = libOrder.PizzaId1,
                PizzaId2 = libOrder.PizzaId2,
                PizzaId3 = libOrder.PizzaId3,
                PizzaId4 = libOrder.PizzaId4,
                PizzaId5 = libOrder.PizzaId5,
                PizzaId6 = libOrder.PizzaId6,
                PizzaId7 = libOrder.PizzaId7,
                PizzaId8 = libOrder.PizzaId8,
                PizzaId9 = libOrder.PizzaId9,
                PizzaId10 = libOrder.PizzaId10,
                PizzaId11 = libOrder.PizzaId11,
                PizzaId12 = libOrder.PizzaId12
            };
            return View(webOrder);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repo.AddOrder(new Library.Order
                    {
                        UserId = order.UserId,
                        LocationId = order.LocationId,
                        DateTime = order.DateTime,
                        Price = order.Price,
                        PizzaId1 = order.PizzaId1,
                        PizzaId2 = order.PizzaId2,
                        PizzaId3 = order.PizzaId3,
                        PizzaId4 = order.PizzaId4,
                        PizzaId5 = order.PizzaId5,
                        PizzaId6 = order.PizzaId6,
                        PizzaId7 = order.PizzaId7,
                        PizzaId8 = order.PizzaId8,
                        PizzaId9 = order.PizzaId9,
                        PizzaId10 = order.PizzaId10,
                        PizzaId11 = order.PizzaId11,
                        PizzaId12 = order.PizzaId12
                    });
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(order);
            }
            catch
            {
                return View();
            }
        }


        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            var libOrder = Repo.GetOrderById(id);
            var webOrder = new Order
            {
                Id = libOrder.Id,
                UserId = libOrder.UserId,
                LocationId = libOrder.LocationId,
                DateTime = libOrder.DateTime,
                Price = libOrder.Price,
                PizzaId1 = libOrder.PizzaId1,
                PizzaId2 = libOrder.PizzaId2,
                PizzaId3 = libOrder.PizzaId3,
                PizzaId4 = libOrder.PizzaId4,
                PizzaId5 = libOrder.PizzaId5,
                PizzaId6 = libOrder.PizzaId6,
                PizzaId7 = libOrder.PizzaId7,
                PizzaId8 = libOrder.PizzaId8,
                PizzaId9 = libOrder.PizzaId9,
                PizzaId10 = libOrder.PizzaId10,
                PizzaId11 = libOrder.PizzaId11,
                PizzaId12 = libOrder.PizzaId12
            };
            return View(webOrder);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromRoute]int id, Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var libOrder = new Library.Order
                    {
                        Id = id,
                        UserId = order.UserId,
                        LocationId = order.LocationId,
                        DateTime = order.DateTime,
                        Price = order.Price,
                        PizzaId1 = order.PizzaId1,
                        PizzaId2 = order.PizzaId2,
                        PizzaId3 = order.PizzaId3,
                        PizzaId4 = order.PizzaId4,
                        PizzaId5 = order.PizzaId5,
                        PizzaId6 = order.PizzaId6,
                        PizzaId7 = order.PizzaId7,
                        PizzaId8 = order.PizzaId8,
                        PizzaId9 = order.PizzaId9,
                        PizzaId10 = order.PizzaId10,
                        PizzaId11 = order.PizzaId11,
                        PizzaId12 = order.PizzaId12
                    };
                    Repo.UpdateOrder(libOrder);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(order);
            }
            catch (Exception)
            {
                return View(order);
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            var libOrder = Repo.GetOrderById(id);
            var webOrder = new Order
            {
                Id = libOrder.Id,
                UserId = libOrder.UserId,
                LocationId = libOrder.LocationId,
                DateTime = libOrder.DateTime,
                Price = libOrder.Price,
                PizzaId1 = libOrder.PizzaId1,
                PizzaId2 = libOrder.PizzaId2,
                PizzaId3 = libOrder.PizzaId3,
                PizzaId4 = libOrder.PizzaId4,
                PizzaId5 = libOrder.PizzaId5,
                PizzaId6 = libOrder.PizzaId6,
                PizzaId7 = libOrder.PizzaId7,
                PizzaId8 = libOrder.PizzaId8,
                PizzaId9 = libOrder.PizzaId9,
                PizzaId10 = libOrder.PizzaId10,
                PizzaId11 = libOrder.PizzaId11,
                PizzaId12 = libOrder.PizzaId12
            };
            return View(webOrder);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Repo.DeleteOrder(id);
                Repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // Sort Orders
        public ActionResult ByEarliest(string searchString)
        {
            var libOrders = Repo.SortOrdersByEarliest();
            var webOrders = libOrders.Select(x => new Order
            {
                Id = x.Id,
                UserId = x.UserId,
                LocationId = x.LocationId,
                DateTime = x.DateTime,
                Price = x.Price,
                PizzaId1 = x.PizzaId1,
                PizzaId2 = x.PizzaId2,
                PizzaId3 = x.PizzaId3,
                PizzaId4 = x.PizzaId4,
                PizzaId5 = x.PizzaId5,
                PizzaId6 = x.PizzaId6,
                PizzaId7 = x.PizzaId7,
                PizzaId8 = x.PizzaId8,
                PizzaId9 = x.PizzaId9,
                PizzaId10 = x.PizzaId10,
                PizzaId11 = x.PizzaId11,
                PizzaId12 = x.PizzaId12
            });

            // SEARCH
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower(); // search is case insensitive
                // search based on either user id or location name
                if (searchString == "reston") webOrders = webOrders.Where(s => s.LocationId == 1);
                else if (searchString == "herndon") webOrders = webOrders.Where(s => s.LocationId == 2);
                else if (searchString == "sterling") webOrders = webOrders.Where(s => s.LocationId == 3);
                else webOrders = webOrders.Where(s => s.UserId.ToString() == searchString);

            }

            return View(webOrders);
        }

        public ActionResult ByLatest(string searchString)
        {
            var libOrders = Repo.SortOrdersByLatest();
            var webOrders = libOrders.Select(x => new Order
            {
                Id = x.Id,
                UserId = x.UserId,
                LocationId = x.LocationId,
                DateTime = x.DateTime,
                Price = x.Price,
                PizzaId1 = x.PizzaId1,
                PizzaId2 = x.PizzaId2,
                PizzaId3 = x.PizzaId3,
                PizzaId4 = x.PizzaId4,
                PizzaId5 = x.PizzaId5,
                PizzaId6 = x.PizzaId6,
                PizzaId7 = x.PizzaId7,
                PizzaId8 = x.PizzaId8,
                PizzaId9 = x.PizzaId9,
                PizzaId10 = x.PizzaId10,
                PizzaId11 = x.PizzaId11,
                PizzaId12 = x.PizzaId12
            });

            // SEARCH
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower(); // search is case insensitive
                // search based on either user id or location name
                if (searchString == "reston") webOrders = webOrders.Where(s => s.LocationId == 1);
                else if (searchString == "herndon") webOrders = webOrders.Where(s => s.LocationId == 2);
                else if (searchString == "sterling") webOrders = webOrders.Where(s => s.LocationId == 3);
                else webOrders = webOrders.Where(s => s.UserId.ToString() == searchString);

            }

            return View(webOrders);
        }

        public ActionResult ByCheapest(string searchString)
        {
            var libOrders = Repo.SortOrdersByCheapest();
            var webOrders = libOrders.Select(x => new Order
            {
                Id = x.Id,
                UserId = x.UserId,
                LocationId = x.LocationId,
                DateTime = x.DateTime,
                Price = x.Price,
                PizzaId1 = x.PizzaId1,
                PizzaId2 = x.PizzaId2,
                PizzaId3 = x.PizzaId3,
                PizzaId4 = x.PizzaId4,
                PizzaId5 = x.PizzaId5,
                PizzaId6 = x.PizzaId6,
                PizzaId7 = x.PizzaId7,
                PizzaId8 = x.PizzaId8,
                PizzaId9 = x.PizzaId9,
                PizzaId10 = x.PizzaId10,
                PizzaId11 = x.PizzaId11,
                PizzaId12 = x.PizzaId12
            });

            // SEARCH
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower(); // search is case insensitive
                // search based on either user id or location name
                if (searchString == "reston") webOrders = webOrders.Where(s => s.LocationId == 1);
                else if (searchString == "herndon") webOrders = webOrders.Where(s => s.LocationId == 2);
                else if (searchString == "sterling") webOrders = webOrders.Where(s => s.LocationId == 3);
                else webOrders = webOrders.Where(s => s.UserId.ToString() == searchString);

            }

            return View(webOrders);
        }

        public ActionResult ByMostExpensive(string searchString)
        {
            var libOrders = Repo.SortOrdersByMostExpensive();
            var webOrders = libOrders.Select(x => new Order
            {
                Id = x.Id,
                UserId = x.UserId,
                LocationId = x.LocationId,
                DateTime = x.DateTime,
                Price = x.Price,
                PizzaId1 = x.PizzaId1,
                PizzaId2 = x.PizzaId2,
                PizzaId3 = x.PizzaId3,
                PizzaId4 = x.PizzaId4,
                PizzaId5 = x.PizzaId5,
                PizzaId6 = x.PizzaId6,
                PizzaId7 = x.PizzaId7,
                PizzaId8 = x.PizzaId8,
                PizzaId9 = x.PizzaId9,
                PizzaId10 = x.PizzaId10,
                PizzaId11 = x.PizzaId11,
                PizzaId12 = x.PizzaId12
            });

            // SEARCH
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower(); // search is case insensitive
                // search based on either user id or location name
                if (searchString == "reston") webOrders = webOrders.Where(s => s.LocationId == 1);
                else if (searchString == "herndon") webOrders = webOrders.Where(s => s.LocationId == 2);
                else if (searchString == "sterling") webOrders = webOrders.Where(s => s.LocationId == 3);
                else webOrders = webOrders.Where(s => s.UserId.ToString() == searchString);

            }

            return View(webOrders);
        }

        //// Session
        //[HttpPost]
        //public ActionResult Index(ImageSwapModel imageSwap)
        //{
        //    var oldFileFound = false;
        //    var newFileFound = false;

        //    if (ModelState.IsValid)
        //    {
        //        this.HttpContext.Session["ImageSwap"] = imageSwap;
        //    }
        //}
    }
}