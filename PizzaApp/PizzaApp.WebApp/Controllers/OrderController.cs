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
                    var repoOrders = Repo.GetOrders().ToList();
                    var lastOrderId = repoOrders.Last().Id;
                    var newOrderId = lastOrderId + 1;

                    var userId = int.Parse(TempData["userId"].ToString());
                    var thisUser = Repo.GetUserById(userId);
                    
                    var currentTime = DateTime.Now;

                    var newOrder = new Library.Order
                    {
                        UserId = userId,
                        LocationId = order.LocationId,
                        DateTime = currentTime,
                        Price = order.Price,
                    };

                    var libPizzas = Repo.GetPizzas().ToList();

                    var lastId = libPizzas.Last().Id;
                    var pizzaList = new List<Library.Pizza>();
                    for (int i = 1; i <= order.PizzaCount; i++)
                    {                        
                        // create random pizzas
                        var random = new Random();
                        var randomChoice = random.Next(6);
                        var newPizza = new Library.Pizza();
                        switch (randomChoice)
                        {
                            case 0:
                                newPizza = new Library.Pizza
                                {
                                    Crust = new Crust(),
                                    Sauce = new Sauce(),
                                    Cheese = new Cheese(),
                                    Topping1 = new Topping(""),
                                    Topping2 = new Topping(""),
                                    Topping3 = new Topping(""),
                                    Topping4 = new Topping(""),
                                    Topping5 = new Topping(""),
                                    Topping6 = new Topping("")
                                };
                                break;
                            case 1:
                                newPizza = new Library.Pizza
                                {
                                    Crust = new Crust(),
                                    Sauce = new Sauce(),
                                    Cheese = new Cheese(),
                                    Topping1 = new Topping(),
                                    Topping2 = new Topping(""),
                                    Topping3 = new Topping(""),
                                    Topping4 = new Topping(""),
                                    Topping5 = new Topping(""),
                                    Topping6 = new Topping("")
                                };
                                break;
                            case 2:
                                newPizza = new Library.Pizza
                                {
                                    Crust = new Crust(),
                                    Sauce = new Sauce(),
                                    Cheese = new Cheese(),
                                    Topping1 = new Topping(),
                                    Topping2 = new Topping(),
                                    Topping3 = new Topping(""),
                                    Topping4 = new Topping(""),
                                    Topping5 = new Topping(""),
                                    Topping6 = new Topping("")
                                };
                                break;
                            case 3:
                                newPizza = new Library.Pizza
                                {
                                    Crust = new Crust(),
                                    Sauce = new Sauce(),
                                    Cheese = new Cheese(),
                                    Topping1 = new Topping(),
                                    Topping2 = new Topping(),
                                    Topping3 = new Topping(),
                                    Topping4 = new Topping(""),
                                    Topping5 = new Topping(""),
                                    Topping6 = new Topping("")
                                };
                                break;
                            case 4:
                                newPizza = new Library.Pizza
                                {
                                    Crust = new Crust(),
                                    Sauce = new Sauce(),
                                    Cheese = new Cheese(),
                                    Topping1 = new Topping(),
                                    Topping2 = new Topping(),
                                    Topping3 = new Topping(),
                                    Topping4 = new Topping(),
                                    Topping5 = new Topping(""),
                                    Topping6 = new Topping("")
                                };
                                break;
                            case 5:
                                newPizza = new Library.Pizza
                                {
                                    Crust = new Crust(),
                                    Sauce = new Sauce(),
                                    Cheese = new Cheese(),
                                    Topping1 = new Topping(),
                                    Topping2 = new Topping(),
                                    Topping3 = new Topping(),
                                    Topping4 = new Topping(),
                                    Topping5 = new Topping(),
                                    Topping6 = new Topping("")
                                };
                                break;
                            case 6:
                                newPizza = new Library.Pizza
                                {
                                    Crust = new Crust(),
                                    Sauce = new Sauce(),
                                    Cheese = new Cheese(),
                                    Topping1 = new Topping(),
                                    Topping2 = new Topping(),
                                    Topping3 = new Topping(),
                                    Topping4 = new Topping(),
                                    Topping5 = new Topping(),
                                    Topping6 = new Topping()
                                };
                                break;
                            default:
                                newPizza = new Library.Pizza
                                {
                                    Crust = new Crust(),
                                    Sauce = new Sauce(),
                                    Cheese = new Cheese()
                                };
                                break;
                        }
                        
                        newPizza.BuildPizza();
                        Repo.AddPizza(newPizza);
                        Repo.Save();
                        newPizza.Id = lastId + i;
                        
                        pizzaList.Add(newPizza);                        
                        newOrder.AddPizza(newPizza);
                    }
                    newOrder.ProcessPizzaList(pizzaList);
                    newOrder.BuildOrder();

                    // Check if order is within pizza count limit
                    // Otherwise, redirect to error page
                    var countCheck = true;
                    if (newOrder.PizzaList.Count() > newOrder.OrderPizzaLimit) countCheck = false;
                    if (countCheck == false)
                    {
                        // Remove pizzas from database if order fails
                        foreach (var pizza in newOrder.PizzaList)
                        {
                            Repo.DeletePizza(pizza.Id);
                        }
                        TempData["ErrorMessage"] = $"Your order exceeds the {newOrder.OrderPizzaLimit} pizza limit.";
                        return RedirectToAction(nameof(Index), "Order/Error");
                    }

                    // Check if order is within price limit
                    // Otherwise, redirect to error page
                    var priceCheck = true;
                    if (newOrder.Price > newOrder.OrderPriceLimit) priceCheck = false;
                    if (priceCheck == false)
                    {
                        TempData["ErrorMessage"] = $"Your order exceeds the ${newOrder.OrderPriceLimit} price limit.";
                        return RedirectToAction(nameof(Index), "Order/Error");
                    }

                    // If check passes, add order to database
                    Repo.AddOrder(newOrder);
                    Repo.Save();
                    
                    // Get the appropriate inventory
                    var libInventories = Repo.GetInventories().ToList();
                    var currentInventory = new Library.Inventory();
                    foreach (var item in libInventories)
                    {
                        if (order.LocationId == item.Id) currentInventory = item;
                    }

                    // Check if order can be fulfilled by location inventory
                    // Otherwise, redirect to error page
                    var inventoryCheck = true;
                    foreach (var pizza in newOrder.PizzaList)
                    {
                        foreach (var ingredient in pizza.PizzaComposition)
                        {
                            if (currentInventory.CheckIfInventoryIsSufficient(ingredient))
                            {
                                currentInventory.DeductInventoryCount(ingredient);
                            }
                            else inventoryCheck = false;
                            
                        }
                    }
                    if (inventoryCheck == false)
                    {
                        TempData["ErrorMessage"] = "That location does not have sufficient inventory to complete your order.";
                        return RedirectToAction(nameof(Index), "Order/Error");                        
                    }

                    // If check passes, update inventory in database
                    Repo.UpdateInventory(currentInventory);
                    Repo.Save();

                    thisUser.LatestLocation = newOrder.LocationId;
                    thisUser.LatestOrderId = newOrderId;

                    Repo.UpdateUser(thisUser);
                    Repo.Save();

                    TempData["OrderId"] = newOrderId;
                    return RedirectToAction(nameof(Index), "Order/Submitted");
                }
                return View(order);
            }
            catch
            {
                TempData["ErrorMessage"] = "Please try again.";
                return RedirectToAction(nameof(Index), "Order/Error");
            }
        }

        // GET: Order/Submitted
        public ActionResult Submitted()
        {
            return View();
        }

        // GET: Order/Error
        public ActionResult Error()
        {
            return View();
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
    }
}