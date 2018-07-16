//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using PizzaApp.Library;

//namespace PizzaApp.WebApp.Controllers
//{
//    public class SessionController : Controller
//    {
//        public PizzaRepository Repo { get; }

//        public SessionController(PizzaRepository repo)
//        {
//            Repo = repo;
//        }

//        [HttpPost]
//        public ActionResult StartOrder(Session model)
//        {
//            var libUsers = Repo.GetUsers();
//            var webUsers = libUsers.Select(x => new User
//            {
//                Id = x.Id,
//                FirstName = x.FirstName,
//                LastName = x.LastName,
//                DefaultLocation = x.DefaultLocation,
//                LatestLocation = x.LatestLocation,
//                LatestOrderId = x.LatestOrderId
//            });



//            if (ModelState.IsValid)
//            {
//                var profileData = new Session
//                {
//                    Id = model.UserId,
//                    FirstName = model.FirstName,
//                    LastName = model.LastName
//                };


//            this.Session["UserProfile"] = profileData;
//            }

//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    Repo.AddUser(new Library.User
//                    {
//                        FirstName = user.FirstName,
//                        LastName = user.LastName,
//                        DefaultLocation = user.DefaultLocation,
//                        LatestLocation = user.LatestLocation,
//                        LatestOrderId = user.LatestOrderId

//                    });
//                    Repo.Save();

//                    return RedirectToAction(nameof(Index));
//                }
//                return View(user);
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        public ActionResult LoggedInStatusMessage()
//        {
//            var profileData = this.Session["UserProfile"] as UserProfileSessionData;

//            /* From here you could output profileData.FullName to a view and
//            save yourself unnecessary database calls */
//        }

//    }
//}