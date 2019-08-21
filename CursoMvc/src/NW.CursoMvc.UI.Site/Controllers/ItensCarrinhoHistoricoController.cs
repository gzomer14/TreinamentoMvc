using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.UI.Site.Models;

namespace NW.CursoMvc.UI.Site.Controllers
{
    public class ItensCarrinhoHistoricoController : Controller
    {

        //// GET: ItensCarrinhoHistorico
        //public ActionResult Index()
        //{
        //    var itensCarrinhoHistoricoes = db.ItensCarrinhoHistoricoes.Include(i => i.Produto);
        //    return View(itensCarrinhoHistoricoes.ToList());
        //}

        //// GET: ItensCarrinhoHistorico/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ItensCarrinhoHistorico itensCarrinhoHistorico = db.ItensCarrinhoHistoricoes.Find(id);
        //    if (itensCarrinhoHistorico == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(itensCarrinhoHistorico);
        //}

        //// GET: ItensCarrinhoHistorico/Create
        //public ActionResult Create()
        //{
        //    ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "nomeProd");
        //    return View();
        //}

        //// POST: ItensCarrinhoHistorico/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ItensCarrinhoHistoricoId,Id,Quantidade,NomeProduto,ValorTotal,ProdutoId,HistoricoId")] ItensCarrinhoHistorico itensCarrinhoHistorico)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        itensCarrinhoHistorico.ItensCarrinhoHistoricoId = Guid.NewGuid();
        //        db.ItensCarrinhoHistoricoes.Add(itensCarrinhoHistorico);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "nomeProd", itensCarrinhoHistorico.ProdutoId);
        //    return View(itensCarrinhoHistorico);
        //}

        //// GET: ItensCarrinhoHistorico/Edit/5
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ItensCarrinhoHistorico itensCarrinhoHistorico = db.ItensCarrinhoHistoricoes.Find(id);
        //    if (itensCarrinhoHistorico == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "nomeProd", itensCarrinhoHistorico.ProdutoId);
        //    return View(itensCarrinhoHistorico);
        //}

        //// POST: ItensCarrinhoHistorico/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ItensCarrinhoHistoricoId,Id,Quantidade,NomeProduto,ValorTotal,ProdutoId,HistoricoId")] ItensCarrinhoHistorico itensCarrinhoHistorico)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(itensCarrinhoHistorico).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "nomeProd", itensCarrinhoHistorico.ProdutoId);
        //    return View(itensCarrinhoHistorico);
        //}

        //// GET: ItensCarrinhoHistorico/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ItensCarrinhoHistorico itensCarrinhoHistorico = db.ItensCarrinhoHistoricoes.Find(id);
        //    if (itensCarrinhoHistorico == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(itensCarrinhoHistorico);
        //}

        //// POST: ItensCarrinhoHistorico/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    ItensCarrinhoHistorico itensCarrinhoHistorico = db.ItensCarrinhoHistoricoes.Find(id);
        //    db.ItensCarrinhoHistoricoes.Remove(itensCarrinhoHistorico);
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
