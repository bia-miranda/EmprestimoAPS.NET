using projetoEmprestimo2.Dados;
using projetoEmprestimo2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoEmprestimo2.Controllers
{
    public class LivrosController : Controller
    {
        // GET: Livros
        public ActionResult Index()
        {
            return View();
        }

        acLivro ac = new acLivro();
        [HttpPost]

        public ActionResult Index(modelLivro md, HttpPostedFileBase file)
        {
            //imagem
            string arquivo = Path.GetFileName(file.FileName);
            string file2 = "/Imagens/" + arquivo;
            string _path = Path.Combine(Server.MapPath("~/Imagens"), arquivo);
            file.SaveAs(_path);

            //salvar contato
            md.ImagemLivro = file2;
            ac.InserirLivro(md);
            ViewBag.msg = "Cadastro realizado";
            return View();
        }
    }
}