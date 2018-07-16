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
    public class LocationController : Controller
    {

        public PizzaRepository Repo { get; }

        public LocationController(PizzaRepository repo)
        {
            Repo = repo;
        }

        // GET: Location
        public ActionResult Index()
        {
            var libLocations = Repo.GetLocations();
            var webLocations = libLocations.Select(x => new Location
            {
                Id = x.Id,
                Name = x.Name,
                InventoryId = x.InventoryId
            });

            return View(webLocations);
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            var libLocation = Repo.GetLocationById(id);
            var webLocation = new Location
            {
                Id = libLocation.Id,
                Name = libLocation.Name,
                InventoryId = libLocation.InventoryId
            };
            return View(webLocation);
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Location location)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repo.AddLocation(new Library.Location
                    {
                        Name = location.Name,
                        InventoryId = location.InventoryId
                    });
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(location);
            }
            catch
            {
                return View();
            }
        }


        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            var libLocation = Repo.GetLocationById(id);
            var webLocation = new Location
            {
                Id = libLocation.Id,
                Name = libLocation.Name,
                InventoryId = libLocation.InventoryId
            };
            return View(webLocation);
        }

        // POST: Location/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromRoute]int id, Location location)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var libLocation = new Library.Location
                    {
                        Id = id,
                        Name = location.Name,
                        InventoryId = location.InventoryId
                    };
                    Repo.UpdateLocation(libLocation);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(location);
            }
            catch (Exception ex)
            {
                return View(location);
            }
        }

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            var libLocation = Repo.GetLocationById(id);
            var webLocation = new Location
            {
                Id = libLocation.Id,
                Name = libLocation.Name,
                InventoryId = libLocation.InventoryId
            };
            return View(webLocation);
        }

        // POST: Location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Repo.DeleteLocation(id);
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