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
    public class ProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        // GET: Produtos
        public ActionResult Index()
        {
            return View(_produtoAppService.ObterTodos());
        }

        //// GET: Produtos/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Produto produto = db.Produtos.Find(id);
        //    if (produto == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(produto);
        //}

        //// GET: Produtos/Create
        //public ActionResult Create()
        //{
        //    ViewBag.FornecedorId = new SelectList(db.Fornecedors, "FornecedorId", "nome");
        //    return View();
        //}

        //// POST: Produtos/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ProdutoId,nomeProd,descricao,valor,peso,FornecedorId")] Produto produto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        produto.ProdutoId = Guid.NewGuid();
        //        db.Produtos.Add(produto);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.FornecedorId = new SelectList(db.Fornecedors, "FornecedorId", "nome", produto.FornecedorId);
        //    return View(produto);
        //}

        //// GET: Produtos/Edit/5
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Produto produto = db.Produtos.Find(id);
        //    if (produto == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.FornecedorId = new SelectList(db.Fornecedors, "FornecedorId", "nome", produto.FornecedorId);
        //    return View(produto);
        //}

        //// POST: Produtos/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ProdutoId,nomeProd,descricao,valor,peso,FornecedorId")] Produto produto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(produto).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.FornecedorId = new SelectList(db.Fornecedors, "FornecedorId", "nome", produto.FornecedorId);
        //    return View(produto);
        //}

        //// GET: Produtos/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Produto produto = db.Produtos.Find(id);
        //    if (produto == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(produto);
        //}

        //// POST: Produtos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    Produto produto = db.Produtos.Find(id);
        //    db.Produtos.Remove(produto);
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
