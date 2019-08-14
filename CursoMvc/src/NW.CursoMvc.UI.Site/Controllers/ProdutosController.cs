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
    [RoutePrefix("Fornecedores")]
    public class ProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;
        public static Guid idprov;

        public ProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }
        [Route("{id=guid}/Produtos")]
        public ActionResult Produtos(Guid id)
        {
            idprov = id;
            return View(_produtoAppService.ObterPorFornecedor(id));
        }

                // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produtoViewModel)
        {
             if (ModelState.IsValid)
             {
                produtoViewModel = _produtoAppService.AdicionarProdForn(produtoViewModel, idprov);

                return RedirectToAction("Index","Fornecedores");
             }

             return View(produtoViewModel);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var produtoViewModel = _produtoAppService.ObterPorId(id.Value);
            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
           _produtoAppService.RemoverProduto(id);
            return RedirectToAction("Produtos");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _produtoAppService.Dispose();
            }
            base.Dispose(disposing);
        }


        //// GET: Produtos
        //public ActionResult Index(Guid id)
        //{
        //    return View(_produtoAppService.ObterPorFornecedor(id));
        //}


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


    }
}
