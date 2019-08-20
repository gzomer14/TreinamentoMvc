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
    public class ProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;
        public static Guid idprov;
        public static Guid idcarrinho;

        public ProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        public ActionResult TodosProdutos(Guid? id)
        {
            if (id != null)
            {
                idcarrinho = id.Value;
            }
                
            return View(_produtoAppService.TodosProdutos());
        }

        public ActionResult EnviarDadosItensCarrinho(Guid idProd)
        {
            return RedirectToAction("AdicionarProduto", "ItensCarrinho", new
            {
                idProd = idProd,
                idCarrinho = idcarrinho
            });
        }

        public ActionResult ProdutoForn(Guid id)
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
        public ActionResult Create(ProdutoViewModel produtoViewModel,Guid? id)
        {
            id = idprov;
            if (ModelState.IsValid)
             {
                produtoViewModel = _produtoAppService.Adicionar(produtoViewModel,id.Value);

                return RedirectToAction("ProdutoForn","Produtos", new {id = idprov});
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
            return RedirectToAction("ProdutoForn", "Produtos", new { id = idprov });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _produtoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
        
        // GET: Produtos/Edit/5
        public ActionResult Edit(Guid? id)
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

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            var id = idprov;
            if (ModelState.IsValid)
            {
                _produtoAppService.Atualizar(produtoViewModel,id);

                return RedirectToAction("Index","Fornecedores");
            }

            return View(produtoViewModel);
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





    }
}
