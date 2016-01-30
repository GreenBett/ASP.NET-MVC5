using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RestaurantProject.Controllers
{
    public class CommandeController : Controller
    {   //Declaration de la base de données
        restaurant_projectEntities db = new restaurant_projectEntities();
        // GET: Commande
        public ActionResult Index()
        {
            if (Session["Num_table"] != null)
            {
                return View(db.Commandes.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        //Login with table name
        public ActionResult Login()
        {


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Tables t)
        {
            //this action is for handling post(login)
            if (ModelState.IsValid)// this cheks validity
            {
                var v = db.Tables.Where(a => a.Id_table.Equals(t.Id_table)).FirstOrDefault();
                if (v != null)
                {
                    Session["Num_table"] = v.Id_table;
                    //Update table from vide to pleine 
                    Tables table= db.Tables.Find(v.Id_table);
                    table.Etat_table = "pleine";
                    db.Entry(table).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ///////////////////////////////////////
                    return RedirectToAction("Create");
                }

            }

            return View(t);
        }


        // GET: Commande/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Commandes commande = db.Commandes.Find(id);
            if (commande == null)
                return HttpNotFound();
            return View(commande);
        }

        // GET: Commande/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Commande/Create
        [HttpPost]
        public ActionResult Create(Commandes commande)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    Commandes comm = commande;
                    comm.Id_table = (int?)Session["Num_table"];
                    comm.etat_comm = "nouvelle";
                    comm.etat_plat = "nouvelle";
                    db.Commandes.Add(comm);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Commande/Edit/5
        public ActionResult Increase(int? id)
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
        public ActionResult Increase(Commandes commande)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Commandes comm = commande;
                    comm.Id_table = (int?)Session["Num_table"];
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
        public ActionResult Edit(Commandes commande)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Commandes comm = commande;
                    comm.Id_table = (int?)Session["Num_table"];
                    comm.etat_comm = "nouvelle";
                    comm.etat_plat = "nouvelle";
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

        // GET: Commande/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Commandes commande = db.Commandes.Find(id);
            if (commande == null)
                return HttpNotFound();
            return View(commande);
        }

        // POST: Commande/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Commandes comma)
        {
            try
            {
                Commandes commande = new Commandes();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    commande = db.Commandes.Find(id);
                    if (commande == null)
                        return HttpNotFound();
                    db.Commandes.Remove(commande);
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
        public ActionResult PayerCommande()
        {
            //Calcule de prix total de la commande de la table de numero Session["Num_table"]
            int? prix_total = 0;
            using (restaurant_projectEntities dc = new restaurant_projectEntities())
            {


                var v = dc.Commandes.AsEnumerable();
                if (v != null)
                {
                    foreach (var i in v)
                    {
                        if (i.Id_table.Equals(Session["Num_table"]))
                        {
                            var v1 = dc.Plats.AsEnumerable();
                            if (v1 != null)
                            {
                                foreach (var j in v1)
                                {
                                    if (j.Idplat == i.Idplat)
                                        prix_total += j.Prix * i.QTT;
                                }
                            }
                        }
                    }
                }

            }
            Session["Total_Prix"] = prix_total;
            return View();
        }
        [HttpPost]
        public ActionResult PayementAndTips(float? tips)
        {
            int? prise = (int?)Session["Total_Prix"];
            String prix = Session["Total_Prix"].ToString();
            float? tip = (float?)prise * tips / 100;
            string Total = ((int?)Session["Total_Prix"] + tip).ToString();
            String Chaine = "Le prix est : " + prix + " DH Vous avez données comme pourboire : " + tip + " DH Donc votre total est:" + Total + " DH ";
            //Insertion dans TotalCommande

            //Calcule de prix total de la commande de la table de numero Session["Num_table"]
            int? prix_total = (int?)Session["Total_Prix"], number_commandes = 0;
            int? id_serveur = null;
            List<Commandes> liste_commande = new List<Commandes>();
            using (restaurant_projectEntities dc = new restaurant_projectEntities())
            {


                var v = dc.Commandes.AsEnumerable();
                if (v != null)
                {
                    foreach (var i in v)
                    {
                        if (i.Id_table.Equals(Session["Num_table"]))
                        {
                            number_commandes++;
                            liste_commande.Add(i);

                        }
                    }
                }
                //Recuperation de id_serveur
                int? num_table = (int?)Session["Num_table"];
                var v2 = dc.Tables.Where(a => a.Id_table.ToString().Equals(num_table.ToString())).FirstOrDefault();
                id_serveur = v2.id_serveur;
                //Inserssion de prix total dans la table TolalCommandes
                TotalCommandes total = new TotalCommandes();
                //  total.Id = 2;
                total.Num_commande = number_commandes;
                total.Num_table = (int?)Session["Num_table"];
                total.Jours = DateTime.Today;
                total.Prix = prix_total;
                total.id_serveur = id_serveur;
                total.gain_serveur = (decimal)tip;

                if (ModelState.IsValid)
                {
                    db.TotalCommandes.Add(total);
                    //Enregistrer les modifiacation
                    db.SaveChanges();
                }
            }
            Commandes commande;
            foreach (var i in liste_commande)
            {
                //Supression des commandes de la table de numero Session["Num_table"] pour laisser l'espace pour d'autre commandes à l'avenir
                commande = db.Commandes.Find(i.id_commande);
                db.Commandes.Remove(commande);
                db.SaveChanges();
                //Update table from pleine to vide and etat commande from servie to ---
                Tables table = db.Tables.Find((int?)Session["Num_table"]);
                table.Etat_table = "vide";
                table.Etat_commande = "---";
                db.Entry(table).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ///////////////////////////////////////
            }
            Session["Chaine"] = Chaine;
            return View();
        }
    }
}