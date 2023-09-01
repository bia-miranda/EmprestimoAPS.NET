using projetoEmprestimo2.Dados;
using projetoEmprestimo2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoEmprestimo2.Controllers
{
    public class HomeController : Controller
    {

        acLivro ac = new acLivro();
        acEmprestimo acE = new acEmprestimo();
        acItem acItem = new acItem();

        public ActionResult Index()
        {
            return View(ac.SelecionaLivros());
        }

        public static string codigo;

        public ActionResult AdicionarCarrinho(int id)
        {
            modelEmprestimo carrinho = Session["Carrinho"] != null ? (modelEmprestimo)Session["Carrinho"] : new modelEmprestimo();

            var livro = ac.SelecionaConsLivros(id);

            codigo = id.ToString();

            if (livro != null)
            {
                var itemEmprestimo = new modelItem();

                itemEmprestimo.ItemPedidoID = Guid.NewGuid();
                itemEmprestimo.CodLivro = codigo;
                itemEmprestimo.NomeLivro = livro[0].NomeLivro;
                itemEmprestimo.Imagem = livro[0].ImagemLivro;

                List<modelItem> x = carrinho.ItensPedido.FindAll(l => l.NomeLivro == itemEmprestimo.NomeLivro);

                if (x.Count != 0)
                {
                    return Content("<script language='javascript' type='text/javascript'> alert('Livro já incluído no empréstimo'); location.href='Carrinho';</script>");

                }
                else
                {
                    carrinho.ItensPedido.Add(itemEmprestimo);
                }
                Session["Carrinho"] = carrinho;
            }
            return RedirectToAction("Carrinho");
        }

        public ActionResult Carrinho()
        {
            modelEmprestimo carrinho = Session["Carrinho"] != null ? (modelEmprestimo)Session["Carrinho"] : new modelEmprestimo();

            return View(carrinho);
        }

        public ActionResult ExcluirItem(Guid id)
        {
            var carrinho = Session["Carrinho"] != null ? (modelEmprestimo)Session["Carrinho"] : new modelEmprestimo();
            var itemExclusao = carrinho.ItensPedido.FirstOrDefault(i => i.ItemPedidoID == id);

            carrinho.ItensPedido.Remove(itemExclusao);

            Session["Carrinho"] = carrinho;
            return RedirectToAction("Carrinho");
        }

        DateTime data;

        public ActionResult SalvarCarrinho(modelEmprestimo x) {
            var carrinho = Session["Carrinho"] != null ? (modelEmprestimo)Session["Carrinho"] : new modelEmprestimo();

            modelEmprestimo mdE = new modelEmprestimo();
            modelItem mdI = new modelItem();

            data = DateTime.Now.ToLocalTime();

            mdE.DtEmprestimo = data.ToString("dd/mm/yyyy");
            mdE.DtDev = data.AddDays(7).ToString();
            mdE.CodUsu = "1";

            acE.InserirEmprestimo(mdE);

            acE.BuscaIDEmp(x);

            for (int i = 0; i < carrinho.ItensPedido.Count; i++)
            {
                mdI.CodEmp = x.CodEmp;
                mdI.CodLivro = carrinho.ItensPedido[1].CodLivro;

                acItem.InserirItem(mdI);
                
            }
            carrinho.ItensPedido.Clear();
            return RedirectToAction("confEmp");
        }

        public ActionResult confEmp()
        {
            return View();
        }

        

    }
}