//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;

//namespace PizzaApp.WebApp.Controllers
//{
//    public class SessionController : Controller
//    {
//        [HttpPost]
//        public ActionResult Login(LoginModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var profileData = new UserProfileSessionData
//                {
//                    UserId = model.UserId,
//                    EmailAddress = model.EmailAddress,
//                    FullName = model.FullName
//                }


//            this.Session["UserProfile"] = profileData;
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