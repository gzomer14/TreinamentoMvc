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
    public class ItensCarrinhoController : Controller
    {
        private readonly IItensCarrinhoAppService _itensCarrinhoAppService;

        public ItensCarrinhoController(IItensCarrinhoAppService itensCarrinhoAppService)
        {
            _itensCarrinhoAppService = itensCarrinhoAppService;
        }

        [HttpGet]
        public ActionResult AdicionarProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarProduto(ItensCarrinhoViewModel itensCarrinhoViewModel,Guid idCarrinho, Guid idProd)
        {
            var itensCarrinho = _itensCarrinhoAppService.AdicionarProduto(itensCarrinhoViewModel, idCarrinho, idProd);

            return RedirectToAction("TodosProdutos","Produtos");

        }

        public ActionResult RemoverProduto(Guid? idItem, Guid idCliente)
        {
            _itensCarrinhoAppService.RemoverProduto(idItem.Value);

            return RedirectToAction("VerCarrinho", "CarrinhoCompras", new {idCliente = idCliente});
        }

        public ActionResult RemoverItens(Guid? idCarrinho)
        {
            _itensCarrinhoAppService.RemoverItens(idCarrinho.Value);

            return RedirectToAction("FinalizarCompra","CarrinhoCompras", new{id = idCarrinho.Value });
        }

        //// GET: ItensCarrinho/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ItensCarrinho itensCarrinho = db.ItensCarrinhoes.Find(id);
        //    if (itensCarrinho == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(itensCarrinho);
        //}

        //// GET: ItensCarrinho/Create
        //public ActionResult Create()
        //{
        //    ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "nomeProd");
        //    return View();
        //}

        //// POST: ItensCarrinho/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ItensCarrinhoId,Id,Quantidade,ProdutoId,CarrinhoComprasId")] ItensCarrinho itensCarrinho)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        itensCarrinho.ItensCarrinhoId = Guid.NewGuid();
        //        db.ItensCarrinhoes.Add(itensCarrinho);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "nomeProd", itensCarrinho.ProdutoId);
        //    return View(itensCarrinho);
        //}

        //// GET: ItensCarrinho/Edit/5
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ItensCarrinho itensCarrinho = db.ItensCarrinhoes.Find(id);
        //    if (itensCarrinho == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "nomeProd", itensCarrinho.ProdutoId);
        //    return View(itensCarrinho);
        //}

        //// POST: ItensCarrinho/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ItensCarrinhoId,Id,Quantidade,ProdutoId,CarrinhoComprasId")] ItensCarrinho itensCarrinho)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(itensCarrinho).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "nomeProd", itensCarrinho.ProdutoId);
        //    return View(itensCarrinho);
        //}

        //// GET: ItensCarrinho/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ItensCarrinho itensCarrinho = db.ItensCarrinhoes.Find(id);
        //    if (itensCarrinho == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(itensCarrinho);
        //}

        //// POST: ItensCarrinho/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    ItensCarrinho itensCarrinho = db.ItensCarrinhoes.Find(id);
        //    db.ItensCarrinhoes.Remove(itensCarrinho);
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
