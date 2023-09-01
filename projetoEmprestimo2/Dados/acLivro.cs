using MySql.Data.MySqlClient;
using projetoEmprestimo2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace projetoEmprestimo2.Dados
{
    public class acLivro
    {
        Conexao con = new Conexao();

        public void InserirLivro(modelLivro cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbLivro values(default, @nomeLivro, @imagemLivro)", con.Conectar());

            cmd.Parameters.Add("@NomeLivro", MySqlDbType.VarChar).Value = cm.NomeLivro;
            cmd.Parameters.Add("@ImagemLivro", MySqlDbType.VarChar).Value = cm.ImagemLivro;

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public List<modelLivro> SelecionaLivros()
        {
            List<modelLivro> livrosList = new List<modelLivro>();

            MySqlCommand cmd = new MySqlCommand("select * from tbLivro", con.Conectar());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.Desconectar();

            foreach(DataRow dr in dt.Rows)
            {
                livrosList.Add(
                    new modelLivro
                    {
                        CodLivro = Convert.ToString(dr["codLivro"]),
                        NomeLivro = Convert.ToString(dr["nomeLivro"]),
                        ImagemLivro = Convert.ToString(dr["imagemLivro"]),
                    });
            }
            return livrosList;
        }

        public List<modelLivro> SelecionaConsLivros(int id)
        {
            List<modelLivro> livrosList = new List<modelLivro>();

            MySqlCommand cmd = new MySqlCommand("select * from tbLivro where codLivro=@cod" , con.Conectar());

            cmd.Parameters.Add("@cod", MySqlDbType.VarChar).Value = id;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            con.Desconectar();
            foreach (DataRow dr in dt.Rows)
            {
                livrosList.Add(
                    new modelLivro
                    {
                        CodLivro = Convert.ToString(dr["codLivro"]),
                        NomeLivro = Convert.ToString(dr["nomeLivro"]),
                        ImagemLivro = Convert.ToString(dr["imagemLivro"]),
                    });
            }
            return livrosList;

        }
    }
}