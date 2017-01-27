using MoIP;
using System;
using System.Net;
using System.Web.Services;
using System.Web.UI;
using System.Xml;
using System.Xml.Linq;

namespace DemoMoIP_WebForm
{
    public static class DocumentExtensions
    {
        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }
    }
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            
        }
       
       
        protected void GerarToken_Click(object sender, EventArgs e)
        {

            
            
            // https://desenvolvedor.moip.com.br/sandbox/AdmAPI.do?method=manual
            //http://marcosdx3-001-site1.ctempurl.com/
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            InstrucaoMoIP moip = new InstrucaoMoIP();
           

            moip.Key = "RNYNTJC6NDBBMY4W3SKZ6V2MRFWOTDFBE3W0KDBO";
            moip.Token = "II5MMMP9FXOPV0UYCHI8DDZU08LNR72P";
            moip.Razao = "Pagamento de testes";
            moip.Valor = 25.25M;
            MoIPResposta resposta = moip.Enviar();
            var success = resposta.Sucesso;
            token.Text = resposta.Token;
            string Token = resposta.Token;
           // var resul = moip.GetStatus(Token);

            //var t = "https://desenvolvedor.moip.com.br/sandbox/ws/alpha/ConsultarInstrucao/" + Token;
           // string r = "https://desenvolvedor.moip.com.br/sandbox/Intrucao.do?token=" + Token;
           // Response.Redirect(r);


        }


    }
}