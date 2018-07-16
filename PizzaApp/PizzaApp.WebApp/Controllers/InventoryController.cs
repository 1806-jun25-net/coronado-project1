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
            var libInventorys = Repo.GetInventories();
            var webInventorys = libInventorys.Select(x => new Inventory
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

            return View(webInventorys);
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            var libInventory = Repo.GetInventoryById(id);
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
                    Repo.AddInventory(new Library.Inventory
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
                    });
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
                    var libInventory = new Library.Inventory
                    {
                        Id = id,
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
                    Repo.UpdateInventory(libInventory);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(inventory);
            }
            catch (Exception ex)
            {
                return View(inventory);
            }
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            var libInventory = Repo.GetInventoryById(id);
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

    }
}