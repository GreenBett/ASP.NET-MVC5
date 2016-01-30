using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RestaurantProject.Controllers
{
    public class CuisinierController : Controller
    {
        restaurant_projectEntities db = new restaurant_projectEntities();
        // GET: Cuisinier
        public ActionResult Index()
        {
            return View(db.Commandes.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Commandes commande = db.Commandes.Find(id);
            if (commande == null)
                return HttpNotFound();
            return View(commande);
        }

        // GET: Commande/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Commandes commande = db.Commandes.Find(id);
            if (commande == null)
                return HttpNotFound();
            return View(commande);

        }

        // POST: Commande/Edit/5
        [HttpPost]
        public ActionResult Edit(Commandes commande, String etat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Commandes comm = commande;
                    comm.etat_comm = etat;
                    comm.etat_plat = etat;
                    db.Entry(comm).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(commande);
            }
            catch
            {
                return View();
            }
        }
    }
}