using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NW.CursoMvc.Application.Interfaces;
using NW.CursoMvc.Application.ViewModels;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.UI.Site.Models;

namespace NW.CursoMvc.UI.Site.Controllers
{
    public class CarrinhoComprasController : Controller
    {
        private readonly ICarrinhoComprasAppService _carrinhoComprasAppService;

        public CarrinhoComprasController(ICarrinhoComprasAppService carrinhoComprasAppService)
        {
            _carrinhoComprasAppService = carrinhoComprasAppService;
        }

        public ActionResult AbrirCarrinho(CarrinhoComprasViewModel carrinhoComprasViewModel, Guid id)
        {
            bool existencia = _carrinhoComprasAppService.VerificarExistencia(id);

            if (existencia)
            {
                return View("Existencia");
            }
            var carrinhoCompras = _carrinhoComprasAppService.AbrirCarrinho(carrinhoComprasViewModel, id);

            return RedirectToAction("TodosProdutos", "Produtos", new { id = carrinhoCompras.CarrinhoCompraId });
        }

        public ActionResult VerCarrinho(Guid idCliente)
        {
            var carrinhoCompras = new CarrinhoComprasViewModel();
            carrinhoCompras = _carrinhoComprasAppService.VerCarrinho(idCliente);

            if (carrinhoCompras == null)
            {
                return View("SemCarrinho");
            }

            return View(carrinhoCompras);
        }

        public ActionResult FinalizarCompra(Guid id)
        {
            _carrinhoComprasAppService.Remover(id);

            return View("FinalizarCompra");
        }


        //// GET: CarrinhoCompras
        //public ActionResult Index()
        //{
        //    var carrinhoCompras = db.CarrinhoCompras.Include(c => c.Cliente);
        //    return View(carrinhoCompras.ToList());
        //}

        //// GET: CarrinhoCompras/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CarrinhoCompras carrinhoCompras = db.CarrinhoCompras.Find(id);
        //    if (carrinhoCompras == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(carrinhoCompras);
        //}

        //// GET: CarrinhoCompras/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: CarrinhoCompras/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CarrinhoCompraId,ClienteId")] CarrinhoCompras carrinhoCompras)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        carrinhoCompras.CarrinhoCompraId = Guid.NewGuid();
        //        db.CarrinhoCompras.Add(carrinhoCompras);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", carrinhoCompras.ClienteId);
        //    return View(carrinhoCompras);
        //}

        //// GET: CarrinhoCompras/Edit/5
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CarrinhoCompras carrinhoCompras = db.CarrinhoCompras.Find(id);
        //    if (carrinhoCompras == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", carrinhoCompras.ClienteId);
        //    return View(carrinhoCompras);
        //}

        //// POST: CarrinhoCompras/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CarrinhoCompraId,ClienteId")] CarrinhoCompras carrinhoCompras)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(carrinhoCompras).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", carrinhoCompras.ClienteId);
        //    return View(carrinhoCompras);
        //}

        //// GET: CarrinhoCompras/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CarrinhoCompras carrinhoCompras = db.CarrinhoCompras.Find(id);
        //    if (carrinhoCompras == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(carrinhoCompras);
        //}

        //// POST: CarrinhoCompras/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    CarrinhoCompras carrinhoCompras = db.CarrinhoCompras.Find(id);
        //    db.CarrinhoCompras.Remove(carrinhoCompras);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
