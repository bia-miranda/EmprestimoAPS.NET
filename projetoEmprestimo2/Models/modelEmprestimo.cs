using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoEmprestimo2.Models
{
    public class modelEmprestimo
    {
        public string CodEmp { get; set; }

        public string DtEmprestimo { get; set; }

        public string DtDev { get; set; }

        public string CodUsu { get; set; }

        public List<modelItem> ItensPedido = new List<modelItem>();
    }
}