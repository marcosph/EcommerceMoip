using MoIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoMoIP_WebForm
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            InstrucaoMoIP moip = new InstrucaoMoIP();

            moip.Key = "RNYNTJC6NDBBMY4W3SKZ6V2MRFWOTDFBE3W0KDBO";
            moip.Token = "II5MMMP9FXOPV0UYCHI8DDZU08LNR72P";
            moip.Razao = "Pagamento de testes";
            moip.Valor = 150.25M;
            MoIPResposta resposta = moip.Enviar();
            var Token = resposta.Token;

            
        }
    }
}