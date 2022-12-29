using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DevExtremeMvcSchoolApp.Models;

namespace DevExtremeMvcSchoolApp.Controllers
{
    public class CourseEnrollmentsController : Controller
    {
        private SchoolAppDatabaseEntities db = new SchoolAppDatabaseEntities();

        // GET: CourseEnrollments
        public ActionResult Index()
        {
            var courseEnrollment = db.CourseEnrollment.Include(c => c.Course).Include(c => c.Student);
            return View(courseEnrollment.ToList());
        }

        // GET: CourseEnrollments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseEnrollment courseEnrollment = db.CourseEnrollment.Find(id);
            if (courseEnrollment == null)
            {
                return HttpNotFound();
            }
            return View(courseEnrollment);
        }

        // GET: CourseEnrollments/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Course, "Id", "Name");
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name");
            return View();
        }

        // POST: CourseEnrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,CourseId")] CourseEnrollment courseEnrollment)
        {
            if (ModelState.IsValid)
            {
                db.CourseEnrollment.Add(courseEnrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Course, "Id", "Name", courseEnrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name", courseEnrollment.StudentId);
            return View(courseEnrollment);
        }

        // GET: CourseEnrollments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseEnrollment courseEnrollment = db.CourseEnrollment.Find(id);
            if (courseEnrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Course, "Id", "Name", courseEnrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name", courseEnrollment.StudentId);
            return View(courseEnrollment);
        }

        // POST: CourseEnrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,CourseId")] CourseEnrollment courseEnrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseEnrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Course, "Id", "Name", courseEnrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name", courseEnrollment.StudentId);
            return View(courseEnrollment);
        }

        // GET: CourseEnrollments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseEnrollment courseEnrollment = db.CourseEnrollment.Find(id);
            if (courseEnrollment == null)
            {
                return HttpNotFound();
            }
            return View(courseEnrollment);
        }

        // POST: CourseEnrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseEnrollment courseEnrollment = db.CourseEnrollment.Find(id);
            db.CourseEnrollment.Remove(courseEnrollment);
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
