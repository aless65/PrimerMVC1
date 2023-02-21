using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrimerMVC.Models;

namespace PrimerMVC.Controllers
{
    public class UsuariosController : Controller
    {
        private CarreterasEntities db = new CarreterasEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var tbUsuarios = db.tbUsuarios.Include(t => t.tbUsuarios2).Include(t => t.tbUsuarios3);
            return View(tbUsuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
            if (tbUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tbUsuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.usu_UsuCreacion = new SelectList(db.tbUsuarios, "usu_id", "usu_NombreUsuario");
            ViewBag.usu_UsuModificacion = new SelectList(db.tbUsuarios, "usu_id", "usu_NombreUsuario");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usu_id,usu_NombreUsuario,usu_Nombres,usu_Apellidos,usu_Contrasena,usu_UsuCreacion,usu_FechaCreacion,usu_UsuModificacion,usu_FechaModificacion,usu_EsAdmin,usu_Estado")] tbUsuarios tbUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.tbUsuarios.Add(tbUsuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.usu_UsuCreacion = new SelectList(db.tbUsuarios, "usu_id", "usu_NombreUsuario", tbUsuarios.usu_UsuCreacion);
            ViewBag.usu_UsuModificacion = new SelectList(db.tbUsuarios, "usu_id", "usu_NombreUsuario", tbUsuarios.usu_UsuModificacion);
            return View(tbUsuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
            if (tbUsuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.usu_UsuCreacion = new SelectList(db.tbUsuarios, "usu_id", "usu_NombreUsuario", tbUsuarios.usu_UsuCreacion);
            ViewBag.usu_UsuModificacion = new SelectList(db.tbUsuarios, "usu_id", "usu_NombreUsuario", tbUsuarios.usu_UsuModificacion);
            return View(tbUsuarios);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usu_id,usu_NombreUsuario,usu_Nombres,usu_Apellidos,usu_Contrasena,usu_UsuCreacion,usu_FechaCreacion,usu_UsuModificacion,usu_FechaModificacion,usu_EsAdmin,usu_Estado")] tbUsuarios tbUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbUsuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usu_UsuCreacion = new SelectList(db.tbUsuarios, "usu_id", "usu_NombreUsuario", tbUsuarios.usu_UsuCreacion);
            ViewBag.usu_UsuModificacion = new SelectList(db.tbUsuarios, "usu_id", "usu_NombreUsuario", tbUsuarios.usu_UsuModificacion);
            return View(tbUsuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
            if (tbUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tbUsuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
            db.tbUsuarios.Remove(tbUsuarios);
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
