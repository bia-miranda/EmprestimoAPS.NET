using MySql.Data.MySqlClient;
using projetoEmprestimo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace projetoEmprestimo2.Dados
{
    public class acEmprestimo
    {
        Conexao con = new Conexao();

        public void InserirEmprestimo(modelEmprestimo cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbEmprestimo values(default, @dtEmpre, @dtDev, @codUsu)", con.Conectar());

            cmd.Parameters.Add("@dtEmpre", MySqlDbType.VarChar).Value = cm.DtEmprestimo;
            cmd.Parameters.Add("@dtDev", MySqlDbType.VarChar).Value = cm.DtDev;
            cmd.Parameters.Add("@codUsu", MySqlDbType.VarChar).Value = cm.CodUsu;

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        MySqlDataReader dr;

        public void BuscaIDEmp(modelEmprestimo vend)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT codEmp FROM tbEmprestimo ORDER BY codEmp DESC limit 1", con.Conectar());
            
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                vend.CodEmp = dr[0].ToString();
            }
            con.Desconectar();
        }

    }

}