using MoIP;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web.UI;

namespace DemoMoIP_WebForm
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

           

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            InstrucaoMoIP moip = new InstrucaoMoIP();

            moip.Key = "RNYNTJC6NDBBMY4W3SKZ6V2MRFWOTDFBE3W0KDBO";
            moip.Token = "II5MMMP9FXOPV0UYCHI8DDZU08LNR72P";
            moip.Razao = "Pagamento de testes";
            moip.Valor = 150.25M;
            MoIPResposta resposta = moip.Enviar();
            var  Token = resposta.Token;
            string r = "https://desenvolvedor.moip.com.br/Intrucao.do?token=" + Token;
            Response.Redirect(r);

            
        }
    }
}