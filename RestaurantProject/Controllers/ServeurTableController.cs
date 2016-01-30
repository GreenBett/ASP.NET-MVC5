using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantProject.Controllers
{
    public class ServeurTableController : Controller
    {
        // GET: ServeurTable
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginServeur()
        {


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginServeur(Serveur u)
        {
            //this action is for handling post(login)
            if (ModelState.IsValid)// this cheks validity
            {
                using (restaurant_projectEntities dc = new restaurant_projectEntities())
                {


                    var v = dc.Serveur.Where(a => a.login.Equals(u.login) && a.password.Equals(u.password)).FirstOrDefault();
                    if (v != null)
                    {

                        Session["LogedUserID"] = v.id_serveur.ToString();
                        Session["LogedUserName"] = v.login.ToString();
                        return RedirectToAction("AfterLoginTables");
                    }
                }
            }

            return View(u);
        }

        public ActionResult AfterLoginTables()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginServeur");
            }


        }
    }
}