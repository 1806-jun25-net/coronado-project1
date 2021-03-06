﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Context;
using PizzaApp.Library;

namespace PizzaApp.WebApp.Controllers
{
    public class PizzaController : Controller
    {

        public PizzaRepository Repo { get; }

        public PizzaController(PizzaRepository repo)
        {
            Repo = repo;
        }

        // Order Builder
        public IActionResult Builder()
        {
            return View();
        }

        private IEnumerable<Pizza> CheckSearchString(string searchString, IEnumerable<Pizza> webPizzas)
        {
            // SEARCH
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower(); // search is case insensitive
                // search pizza name because that contains all ingredients
                webPizzas = webPizzas.Where(s => s.Name.ToLower().Contains(searchString));

            }
            return webPizzas;
        }              

        // GET: Pizza
        public ActionResult Index(string searchString)
        {
            var libPizzas = Repo.SortPizzasByLatest();
            var webPizzas = ConvertModel(libPizzas);
            webPizzas = CheckSearchString(searchString, webPizzas);

            return View(webPizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            var libPizza = Repo.GetPizzaById(id);
            var webPizza = ConvertModel(libPizza);
            return View(webPizza);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pizza/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pizza pizza)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newPizza = ConvertModel(pizza);
                    newPizza.BuildPizza();
                    Repo.AddPizza(newPizza);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(pizza);
            }
            catch
            {
                return View();
            }
        }


        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            var libPizza = Repo.GetPizzaById(id);
            var webPizza = ConvertModel(libPizza);
            return View(webPizza);
        }

        // POST: Pizza/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromRoute]int id, Pizza pizza)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var libPizza = ConvertModel(id, pizza);
                    Repo.UpdatePizza(libPizza);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(pizza);
            }
            catch (Exception)
            {
                return View(pizza);
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            var libPizza = Repo.GetPizzaById(id);
            var webPizza = ConvertModel(libPizza);
            return View(webPizza);
        }

        // POST: Pizza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Repo.DeletePizza(id);
                Repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // Sort Pizzas
        public ActionResult ByEarliest(string searchString)
        {
            var libPizzas = Repo.SortPizzasByEarliest();
            var webPizzas = ConvertModel(libPizzas);
            webPizzas = CheckSearchString(searchString, webPizzas);

            return View(webPizzas);
        }
        // made latest the default index
        /*
        public ActionResult ByLatest(string searchString)
        {
            var libPizzas = Repo.SortPizzasByLatest();
            var webPizzas = ConvertToWebModel(libPizzas);
            webPizzas = CheckSearchString(searchString, webPizzas);

            return View(webPizzas);
        }
        */
        public ActionResult ByCheapest(string searchString)
        {
            var libPizzas = Repo.SortPizzasByCheapest();
            var webPizzas = ConvertModel(libPizzas);
            webPizzas = CheckSearchString(searchString, webPizzas);

            return View(webPizzas);
        }

        public ActionResult ByMostExpensive(string searchString)
        {
            var libPizzas = Repo.SortPizzasByMostExpensive();
            var webPizzas = ConvertModel(libPizzas);
            webPizzas = CheckSearchString(searchString, webPizzas);

            return View(webPizzas);
        }

        private IEnumerable<Pizza> ConvertModel(IEnumerable<Library.Pizza> libPizzas)
        {
            var webPizzas = libPizzas.Select(x => new Pizza
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Crust = x.Crust.IngredientName,
                Sauce = x.Sauce.IngredientName,
                Cheese = x.Cheese.IngredientName,
                Topping1 = x.Topping1.IngredientName,
                Topping2 = x.Topping2.IngredientName,
                Topping3 = x.Topping3.IngredientName,
                Topping4 = x.Topping4.IngredientName,
                Topping5 = x.Topping5.IngredientName,
                Topping6 = x.Topping6.IngredientName
            });
            return webPizzas;
        }

        private Pizza ConvertModel(Library.Pizza libPizza)
        {
            var webPizza = new Pizza
            {
                Id = libPizza.Id,
                Name = libPizza.Name,
                Price = libPizza.Price,
                Crust = libPizza.Crust.IngredientName,
                Sauce = libPizza.Sauce.IngredientName,
                Cheese = libPizza.Cheese.IngredientName,
                Topping1 = libPizza.Topping1.IngredientName,
                Topping2 = libPizza.Topping2.IngredientName,
                Topping3 = libPizza.Topping3.IngredientName,
                Topping4 = libPizza.Topping4.IngredientName,
                Topping5 = libPizza.Topping5.IngredientName,
                Topping6 = libPizza.Topping6.IngredientName
            };
            return webPizza;
        }

        private Library.Pizza ConvertModel(Pizza pizza)
        {
            var libPizza = new Library.Pizza
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price,
                Crust = new Crust(pizza.Crust),
                Sauce = new Sauce(pizza.Sauce),
                Cheese = new Cheese(pizza.Cheese),
                Topping1 = new Topping(pizza.Topping1),
                Topping2 = new Topping(pizza.Topping2),
                Topping3 = new Topping(pizza.Topping3),
                Topping4 = new Topping(pizza.Topping4),
                Topping5 = new Topping(pizza.Topping5),
                Topping6 = new Topping(pizza.Topping6)
            };
            return libPizza;
        }

        private Library.Pizza ConvertModel(int id, Pizza pizza)
        {
            var libPizza = new Library.Pizza
            {
                Id = id,
                Name = pizza.Name,
                Price = pizza.Price,
                Crust = new Crust(pizza.Crust),
                Sauce = new Sauce(pizza.Sauce),
                Cheese = new Cheese(pizza.Cheese),
                Topping1 = new Topping(pizza.Topping1),
                Topping2 = new Topping(pizza.Topping2),
                Topping3 = new Topping(pizza.Topping3),
                Topping4 = new Topping(pizza.Topping4),
                Topping5 = new Topping(pizza.Topping5),
                Topping6 = new Topping(pizza.Topping6)
            };
            return libPizza;
        }
        
    }
}