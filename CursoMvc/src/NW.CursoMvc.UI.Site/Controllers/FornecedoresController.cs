using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NW.CursoMvc.Application.ViewModels;
using NW.CursoMvc.UI.Site.Models;

namespace NW.CursoMvc.UI.Site.Controllers
{
    public class FornecedoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Fornecedores
        public ActionResult Index()
        {
            return View(db.FornecedorViewModels.ToList());
        }

        // GET: Fornecedores/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorViewModel fornecedorViewModel = db.FornecedorViewModels.Find(id);
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorViewModel);
        }

        // GET: Fornecedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FornecedorId,nome,cpf,email,dataNascimento,dataCadastro,ativo")] FornecedorViewModel fornecedorViewModel)
        {
            if (ModelState.IsValid)
            {
                fornecedorViewModel.FornecedorId = Guid.NewGuid();
                db.FornecedorViewModels.Add(fornecedorViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fornecedorViewModel);
        }

        // GET: Fornecedores/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorViewModel fornecedorViewModel = db.FornecedorViewModels.Find(id);
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorViewModel);
        }

        // POST: Fornecedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FornecedorId,nome,cpf,email,dataNascimento,dataCadastro,ativo")] FornecedorViewModel fornecedorViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedorViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fornecedorViewModel);
        }

        // GET: Fornecedores/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorViewModel fornecedorViewModel = db.FornecedorViewModels.Find(id);
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorViewModel);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FornecedorViewModel fornecedorViewModel = db.FornecedorViewModels.Find(id);
            db.FornecedorViewModels.Remove(fornecedorViewModel);
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
