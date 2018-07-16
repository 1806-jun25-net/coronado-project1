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
    public class UserController : Controller
    {

        public PizzaRepository Repo { get; }

        public UserController(PizzaRepository repo)
        {
            Repo = repo;
        }

        // GET: User
        public ActionResult Index(string searchString)
        {
            var libUsers = Repo.GetUsers();
            var webUsers = libUsers.Select(x => new User
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DefaultLocation = x.DefaultLocation,
                LatestLocation = x.LatestLocation,
                LatestOrderId = x.LatestOrderId
            });

            // SEARCH: User
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower(); // search is case insensitive
                if (searchString.Contains(" ")) // if there is a space in the search string, split string into firstName and lastName
                {
                    string[] searchStrings = searchString.Split(" ");

                    string firstName = searchStrings[0];
                    string lastName = searchStrings[1];

                    // search whole name using firstName and lastName
                    webUsers = webUsers.Where(s => String.Concat(s.FirstName, s.LastName).ToLower().Contains(firstName) && String.Concat(s.FirstName, s.LastName).ToLower().Contains(lastName));
                }
                else
                    webUsers = webUsers.Where(s => String.Concat(s.FirstName, s.LastName).ToLower().Contains(searchString)); // search whole name using searchString
            }

            return View(webUsers);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var libUser = Repo.GetUserById(id);
            var webUser = new User
            {
                Id = libUser.Id,
                FirstName = libUser.FirstName,
                LastName = libUser.LastName,
                DefaultLocation = libUser.DefaultLocation,
                LatestLocation = libUser.LatestLocation,
                LatestOrderId = libUser.LatestOrderId
            };
            return View(webUser);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repo.AddUser(new Library.User
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        DefaultLocation = user.DefaultLocation,
                        LatestLocation = user.LatestLocation,
                        LatestOrderId = user.LatestOrderId

                    });
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(user);
            }
            catch
            {
                return View();
            }
        }


        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var libUser = Repo.GetUserById(id);
            var webUser = new User
            {
                Id = libUser.Id,
                FirstName = libUser.FirstName,
                LastName = libUser.LastName,
                DefaultLocation = libUser.DefaultLocation,
                LatestLocation = libUser.LatestLocation,
                LatestOrderId = libUser.LatestOrderId
            };
            return View(webUser);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromRoute]int id, User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var libUser = new Library.User
                    {
                        Id = id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        DefaultLocation = user.DefaultLocation,
                        LatestLocation = user.LatestLocation,
                        LatestOrderId = user.LatestOrderId
                    };
                    Repo.UpdateUser(libUser);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(user);
            }
            catch (Exception ex)
            {
                return View(user);
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var libUser = Repo.GetUserById(id);
            var webUser = new User
            {
                Id = libUser.Id,
                FirstName = libUser.FirstName,
                LastName = libUser.LastName,
                DefaultLocation = libUser.DefaultLocation,
                LatestLocation = libUser.LatestLocation,
                LatestOrderId = libUser.LatestOrderId
            };
            return View(webUser);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Repo.DeleteUser(id);
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