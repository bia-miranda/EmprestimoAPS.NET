using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoEmprestimo2.Models
{
    public class modelItem
    {
        public Guid ItemPedidoID { get; set; }

        public string CodEmp { get; set;}
        public string CodLivro { get; set;}
        public string NomeLivro { get; set;}
        public string Imagem { get; set;}
    }
}