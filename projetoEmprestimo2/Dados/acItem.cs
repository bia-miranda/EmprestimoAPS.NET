using MySql.Data.MySqlClient;
using projetoEmprestimo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoEmprestimo2.Dados
{
    public class acItem
    {
        Conexao con = new Conexao();

        public void InserirItem(modelItem cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into itensEmp values(default, @codEmp, @codLivro)", con.Conectar());

            cmd.Parameters.Add("@codEmp", MySqlDbType.VarChar).Value = cm.CodEmp;
            cmd.Parameters.Add("@codLivro", MySqlDbType.VarChar).Value = cm.CodLivro;

            cmd.ExecuteNonQuery();
            con.Desconectar();

        }
    }
}