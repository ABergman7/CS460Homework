﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Art.Models;

namespace Art.Controllers
{
    public class ArtistsController : Controller
    {
        private ArtContext db = new ArtContext();

        // GET: Artists
        public ActionResult Index()
        {
            return View(db.Artists.ToList());
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ARTISTID,ARTISTNAME,ARTISTDOB,BIRTHCITY")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        // GET: Artists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ARTISTID,ARTISTNAME,ARTISTDOB,BIRTHCITY")] Artist artist)
        {
            if (artist.ARTISTNAME.Length > 50)
            {
                TempData["testmsg"] = "<script>alert('The name cannot be more than 50 characters!');</script>";
                return RedirectToAction("Edit");
            }

            string[] dob = artist.ARTISTDOB.Split('/');

            int month = Int32.Parse(dob[0]);
            int day = Int32.Parse(dob[1]);
            int year = Int32.Parse(dob[2]);


            int mm = DateTime.Now.Month;
            int dd = DateTime.Now.Day;
            int yyyy = DateTime.Now.Year;


            if (year > yyyy)
            {
                TempData["testmsg"] = "<script>alert('Incorrect Birthday');</script>";
                return RedirectToAction("Edit");
            }
            else if (year == yyyy && month > mm)
            {
                TempData["testmsg"] = "<script>alert('Incorrect Birthday');</script>";
                return RedirectToAction("Edit");
            }
            else if (year == yyyy && month == mm && day > dd)
            {
                TempData["testmsg"] = "<script>alert('Incorrect Birthday');</script>";
                return RedirectToAction("Edit");
            }

            else if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
