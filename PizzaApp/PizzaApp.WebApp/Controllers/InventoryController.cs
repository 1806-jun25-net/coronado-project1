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
    public class InventoryController : Controller
    {

        public PizzaRepository Repo { get; }

        public InventoryController(PizzaRepository repo)
        {
            Repo = repo;
        }

        // GET: Inventory
        public ActionResult Index()
        {
            var libInventories = Repo.GetInventories();
            var webInventories = ConvertModel(libInventories);

            return View(webInventories);
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            var libInventory = Repo.GetInventoryById(id);
            var webInventory = ConvertModel(libInventory);

            return View(webInventory);
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inventory inventory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repo.AddInventory(ConvertModel(inventory));
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(inventory);
            }
            catch
            {
                return View();
            }
        }


        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            var libInventory = Repo.GetInventoryById(id);
            var webInventory = ConvertModel(libInventory);
            return View(webInventory);
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromRoute]int id, Inventory inventory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var libInventory = ConvertModel(inventory);
                    Repo.UpdateInventory(libInventory);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(inventory);
            }
            catch (Exception)
            {
                return View(inventory);
            }
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            var libInventory = Repo.GetInventoryById(id);
            var webInventory = ConvertModel(libInventory);
            return View(webInventory);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Repo.DeleteInventory(id);
                Repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Restock/5
        public ActionResult Restock(int id)
        {
            var libInventory = Repo.GetInventoryById(id);
            var webInventory = ConvertModel(libInventory);
            return View(webInventory);
        }

        // POST: Inventory/Restock/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Restock([FromRoute]int id, Inventory inventory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var libInventory = new Library.Inventory
                    {
                        Id = id,
                        LocationId = id,
                        Dough = 200.00,
                        TomatoSauce = 100.00,
                        WhiteSauce = 100.00,
                        Cheese = 200.00,
                        Pepperoni = 50.00,
                        Ham = 50.00,
                        Chicken = 50.00,
                        Beef = 50.00,
                        Sausage = 50.00,
                        Bacon = 50.00,
                        Anchovies = 50.00,
                        RedPeppers = 50.00,
                        GreenPeppers = 50.00,
                        Pineapple = 50.00,
                        Olives = 50.00,
                        Mushrooms = 50.00,
                        Garlic = 50.00,
                        Onions = 50.00,
                        Tomatoes = 50.00,
                        Spinach = 50.00,
                        Basil = 50.00,
                        Ricotta = 50.00,
                        Parmesan = 50.00,
                        Feta = 50.00
                    };
                    Repo.UpdateInventory(libInventory);
                    Repo.Save();

                    return RedirectToAction(nameof(Index), $"Inventory/Details/{id}");
                }
                return View(inventory);
            }
            catch (Exception)
            {
                return View(inventory);
            }
        }

        private IEnumerable<Inventory> ConvertModel(IEnumerable<Library.Inventory> libInventories)
        {
            var webInventories = libInventories.Select(x => new Inventory
            {
                Id = x.Id,
                LocationId = x.LocationId,
                Dough = x.Dough,
                TomatoSauce = x.TomatoSauce,
                WhiteSauce = x.WhiteSauce,
                Cheese = x.Cheese,
                Pepperoni = x.Pepperoni,
                Ham = x.Ham,
                Chicken = x.Chicken,
                Beef = x.Beef,
                Sausage = x.Sausage,
                Bacon = x.Bacon,
                Anchovies = x.Anchovies,
                RedPeppers = x.RedPeppers,
                GreenPeppers = x.GreenPeppers,
                Pineapple = x.Pineapple,
                Olives = x.Olives,
                Mushrooms = x.Mushrooms,
                Garlic = x.Garlic,
                Onions = x.Onions,
                Tomatoes = x.Tomatoes,
                Spinach = x.Spinach,
                Basil = x.Basil,
                Ricotta = x.Ricotta,
                Parmesan = x.Parmesan,
                Feta = x.Feta
            });
            return webInventories;
        }

        private Inventory ConvertModel(Library.Inventory libInventory)
        {
            var webInventory = new Inventory
            {
                Id = libInventory.Id,
                LocationId = libInventory.LocationId,
                Dough = libInventory.Dough,
                TomatoSauce = libInventory.TomatoSauce,
                WhiteSauce = libInventory.WhiteSauce,
                Cheese = libInventory.Cheese,
                Pepperoni = libInventory.Pepperoni,
                Ham = libInventory.Ham,
                Chicken = libInventory.Chicken,
                Beef = libInventory.Beef,
                Sausage = libInventory.Sausage,
                Bacon = libInventory.Bacon,
                Anchovies = libInventory.Anchovies,
                RedPeppers = libInventory.RedPeppers,
                GreenPeppers = libInventory.GreenPeppers,
                Pineapple = libInventory.Pineapple,
                Olives = libInventory.Olives,
                Mushrooms = libInventory.Mushrooms,
                Garlic = libInventory.Garlic,
                Onions = libInventory.Onions,
                Tomatoes = libInventory.Tomatoes,
                Spinach = libInventory.Spinach,
                Basil = libInventory.Basil,
                Ricotta = libInventory.Ricotta,
                Parmesan = libInventory.Parmesan,
                Feta = libInventory.Feta
            };
            return webInventory;
        }

        private Library.Inventory ConvertModel(Inventory inventory)
        {
            var libInventory = new Library.Inventory
            {
                LocationId = inventory.LocationId,
                Dough = inventory.Dough,
                TomatoSauce = inventory.TomatoSauce,
                WhiteSauce = inventory.WhiteSauce,
                Cheese = inventory.Cheese,
                Pepperoni = inventory.Pepperoni,
                Ham = inventory.Ham,
                Chicken = inventory.Chicken,
                Beef = inventory.Beef,
                Sausage = inventory.Sausage,
                Bacon = inventory.Bacon,
                Anchovies = inventory.Anchovies,
                RedPeppers = inventory.RedPeppers,
                GreenPeppers = inventory.GreenPeppers,
                Pineapple = inventory.Pineapple,
                Olives = inventory.Olives,
                Mushrooms = inventory.Mushrooms,
                Garlic = inventory.Garlic,
                Onions = inventory.Onions,
                Tomatoes = inventory.Tomatoes,
                Spinach = inventory.Spinach,
                Basil = inventory.Basil,
                Ricotta = inventory.Ricotta,
                Parmesan = inventory.Parmesan,
                Feta = inventory.Feta
            };
            return libInventory;
        }

    }
}