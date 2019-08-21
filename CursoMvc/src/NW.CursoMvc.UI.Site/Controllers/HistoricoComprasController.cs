using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NW.CursoMvc.Application.Interfaces;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.UI.Site.Models;

namespace NW.CursoMvc.UI.Site.Controllers
{
    public class HistoricoComprasController : Controller
    {
        private readonly IHistoricoComprasAppService _historicoComprasAppService;

        public HistoricoComprasController(IHistoricoComprasAppService historicoComprasAppService)
        {
            _historicoComprasAppService = historicoComprasAppService;
        }

        public ActionResult VerHistoricoPorCliente(Guid? idCliente)
        {
            var itensCarrinhoHistorico = _historicoComprasAppService.VerHistoricoPorCliente(idCliente.Value);

            if (itensCarrinhoHistorico.Count == 0)
            {
                return View("SemHistorico");
            }

            return View(itensCarrinhoHistorico);
        }


        //    // GET: HistoricoCompras
        //    public ActionResult Index()
        //    {
        //        var historicoCompras = db.HistoricoCompras.Include(h => h.Cliente).Include(h => h.Produto);
        //        return View(historicoCompras.ToList());
        //    }

        //    // GET: HistoricoCompras/Details/5
        //    public ActionResult Details(Guid? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        HistoricoCompras historicoCompras = db.HistoricoCompras.Find(id);
        //        if (historicoCompras == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(historicoCompras);
        //    }

        //    // GET: HistoricoCompras/Create
        //    public ActionResult Create()
        //    {
        //        ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome");
        //        ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "nomeProd");
        //        return View();
        //    }

        //    // POST: HistoricoCompras/Create
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create([Bind(Include = "HistoricoComprasId,ProdutoId,ClienteId,NomeProd,ValorProd,TotalGasto,QuantidadeProd")] HistoricoCompras historicoCompras)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            historicoCompras.HistoricoComprasId = Guid.NewGuid();
        //            db.HistoricoCompras.Add(historicoCompras);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", historicoCompras.ClienteId);
        //        ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "nomeProd", historicoCompras.ProdutoId);
        //        return View(historicoCompras);
        //    }

        //    // GET: HistoricoCompras/Edit/5
        //    public ActionResult Edit(Guid? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        HistoricoCompras historicoCompras = db.HistoricoCompras.Find(id);
        //        if (historicoCompras == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", historicoCompras.ClienteId);
        //        ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "nomeProd", historicoCompras.ProdutoId);
        //        return View(historicoCompras);
        //    }

        //    // POST: HistoricoCompras/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "HistoricoComprasId,ProdutoId,ClienteId,NomeProd,ValorProd,TotalGasto,QuantidadeProd")] HistoricoCompras historicoCompras)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(historicoCompras).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", historicoCompras.ClienteId);
        //        ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "nomeProd", historicoCompras.ProdutoId);
        //        return View(historicoCompras);
        //    }

        //    // GET: HistoricoCompras/Delete/5
        //    public ActionResult Delete(Guid? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        HistoricoCompras historicoCompras = db.HistoricoCompras.Find(id);
        //        if (historicoCompras == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(historicoCompras);
        //    }

        //    // POST: HistoricoCompras/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(Guid id)
        //    {
        //        HistoricoCompras historicoCompras = db.HistoricoCompras.Find(id);
        //        db.HistoricoCompras.Remove(historicoCompras);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
        //}
    }
}
    