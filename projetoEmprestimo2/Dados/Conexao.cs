using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoEmprestimo2.Dados
{
    public class Conexao
    {
        MySqlConnection cn = new MySqlConnection("server=localhost; user id= root; password=12345678; database=bdEmprestimo1");
        public static string msg;
        public MySqlConnection Conectar()
        {
            try
            {
                cn.Open();
            }
            catch(Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;
        }

        public MySqlConnection Desconectar()
        {
            try
            {
                cn.Close();
            }
            catch(Exception erro)
            {
                msg = "Ocorreu um erro ao desconectar" + erro.Message;
            }
            return cn;
        }
    }
}