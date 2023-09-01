using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace projetoEmprestimo2.Models
{
    public class modelLivro
    {
        public string CodLivro { get; set; }

        [DisplayName("Livro")]
        public string NomeLivro { get; set;}

        public string ImagemLivro { get; set;}
    }
}