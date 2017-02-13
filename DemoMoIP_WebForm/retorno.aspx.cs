using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoMoIP_WebForm
{
    public partial class retorno : System.Web.UI.Page
    {
        const string KEY = "35B58690-F9FA-4C30-B9DF-1C32494E5D1B";
        string sConnectionString = "Data Source=SQL5030.SmarterASP.NET;Initial Catalog=DB_A17575_DX4;User Id=DB_A17575_DX4_admin;Password=Florida#09;";

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            //Caso o processamento e atualização tenham ocorrido perfeitamente,
            //envie o código HTTP 200 como resposta.
            Response.StatusCode = 200;
            //Caso ocorra algum erro, sera chamada a função setError500(),
            //que sobrescrevera o código HTTP 200 adicionado acima.

            //Verifica se os dados vem por POST
            if (Request.HttpMethod == "POST")
            {
                try
                {
                    //Verifica se possui chave de segurança.
                    if (Request.QueryString["key"] == KEY)
                    {
                        #region Salva os dados do post no Log
                        string sFormData = string.Empty;
                        //Pega todos os dados do post
                        foreach (string name in Request.Form)
                            sFormData += name + "=" + Request.Form[name] + "&";
                        sFormData = sFormData.Trim('&');

                        //Aqui salvo os dados como uma forma de historico
                       // SaveLog(sFormData);
                        #endregion

                        const int APROVADO = 3;
                        const int CANCELADO = 5;

                        //Pegar ID de status baseado no ID de retorno do MoIP.
                        int idPedidoStatus = Convert.ToInt32(Request.Form["status_pagamento"]);

                        if (idPedidoStatus != 0)
                        {                            
                            //Salve o mudanca de status do seu pedido
                        }

                        if (idPedidoStatus ==  APROVADO)
                        {                           
                            //Liberar os produtos
                        }
                        else if (idPedidoStatus == CANCELADO)
                        {
                          
                            //pedido cancelado
                        }
                    }
                    else
                        SaveLog("Falso");
                }
                catch (Exception ex)
                {
                    //No caso de erro define o StatusCode = 500
                    SetError500();
                    SaveLog("Ocorreu o seguinte erro:" + ex.Message);
                }
            }
        }
        #endregion

        #region SetError500
        public void SetError500()
        {
            Response.StatusCode = 500;
        }
        #endregion

        #region SaveLog
        public void SaveLog(string sValue)
        {
            using (SqlConnection conn = new SqlConnection(sConnectionString))
            {
                string sql = "INSERT INTO logMoIP (logText, dataLog) VALUES (@valor, GETDATE())";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@valor", sValue);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        #endregion
    }

    public class StatusTransacao
    {
        public const int Autorizado = 1;
        public const int Iniciado = 2;
        public const int BoletoImpresso = 3;
        public const int Concluido = 4;
        public const int Cancelado = 5;
        public const int EmAnalise = 6;
    }
}