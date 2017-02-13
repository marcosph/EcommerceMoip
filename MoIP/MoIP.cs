using MoIP.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MoIP
{
    public class InstrucaoMoIP
    {
        //https://labs.moip.com.br/parametro/InstrucaoUnica/
        public string Token{get;set;}
        public string Key{get;set;}
        public string Razao{get;set;}
        public decimal Valor{get;set;}
        public string IdProprio { get; set; }
        public DateTime DataVencimento { get; set; }

        private string GetXML()
        {
            XmlDocument document = new XmlDocument();
            XmlElement RazaoNode = document.CreateElement("Razao");
            RazaoNode.InnerText = Razao;

            XmlElement ValoresNode = document.CreateElement("Valores");
            XmlElement ValorNode = document.CreateElement("Valor");
            XmlAttribute moeda = document.CreateAttribute("moeda");
            moeda.Value = "BRL";
            ValorNode.Attributes.Append(moeda);
            ValorNode.InnerText = String.Format("{0:0.00}", Valor).Replace(',', '.');
            ValoresNode.AppendChild(ValorNode);


            XmlElement IdProprioNode = document.CreateElement("IdProprio");
            IdProprioNode.InnerText = IdProprio;

            XmlElement DataVencimentoNode = document.CreateElement("DataVencimento");
            DataVencimentoNode.InnerText = DataVencimento.ToString();

            XmlElement Pagador = document.CreateElement("Pagador");
            XmlElement NomeNode = document.CreateElement("Nome");
            NomeNode.InnerText = "Luiz Inácio Lula da Silva";
            XmlElement LoginMoIPNode = document.CreateElement("LoginMoIP");
            LoginMoIPNode.InnerText = "lula";
            XmlElement EmailNode = document.CreateElement("Email");
            EmailNode.InnerText = "lula@gmail.com";
            XmlElement TelefoneCelularNode = document.CreateElement("TelefoneCelular");
            TelefoneCelularNode.InnerText = "(11)9999-9999";
            XmlElement ApelidoNode = document.CreateElement("Apelido");
            ApelidoNode.InnerText = "Ladrão";
            XmlElement IdentidadeNode = document.CreateElement("Identidade");
            IdentidadeNode.InnerText = "111.111.111-11";

            XmlNode EnviarInstrucao = document.CreateElement("EnviarInstrucao");
            XmlNode InstrucaoUnica = EnviarInstrucao.AppendChild(document.CreateNode(XmlNodeType.Element, "InstrucaoUnica", ""));

            InstrucaoUnica.AppendChild(RazaoNode);
            InstrucaoUnica.AppendChild(ValoresNode);
            InstrucaoUnica.AppendChild(IdProprioNode);
            InstrucaoUnica.AppendChild(DataVencimentoNode);
            string path = HttpContext.Current.Server.MapPath("~/App_Data/data.xml");
            XDocument doc = XDocument.Load(path);
            var stringXml = doc.ToXmlDocument();
            return stringXml.OuterXml;
           // return EnviarInstrucao.OuterXml;
        }

        private MoIPResposta GetMoIPRespostaFromXML(string Response)
        {
            XmlDocument XmlResposta = new XmlDocument();
            XmlResposta.LoadXml(Response);

            MoIPResposta resposta = new MoIPResposta();
            resposta.ID = XmlResposta.DocumentElement.SelectSingleNode("//Resposta//ID").InnerText;
            resposta.Token = XmlResposta.DocumentElement.SelectSingleNode("//Resposta//Token").InnerText;
            resposta.Sucesso = XmlResposta.DocumentElement.SelectSingleNode("//Resposta/Status").InnerText.Equals("Sucesso");

            return resposta;
        }

        public MoIPResposta Enviar()
        {
            if (String.IsNullOrEmpty(Token) || String.IsNullOrEmpty(Key))
                throw new InvalidOperationException("Você deve informar seu token e sua key de forma correta antes de enviar uma instrução.");

            if (String.IsNullOrEmpty(Razao) || Valor.Equals(null))
                throw new InvalidOperationException("Você deve informar a razão e o valor do pagamento");


            string XMLInstrucao = GetXML();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            WebClient client = new WebClient();

            string URI = "https://desenvolvedor.moip.com.br/sandbox/ws/alpha/EnviarInstrucao/Unica";
            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(Token + ":" + Key));
            client.Headers.Add("Authorization: Basic " + auth);
            client.Headers.Add("User-Agent: Mozilla/4.0");
            byte[] ResponseArray = client.UploadData(URI, "POST", Encoding.UTF8.GetBytes(XMLInstrucao));
            string Response = Encoding.UTF8.GetString(ResponseArray);

            return GetMoIPRespostaFromXML(Response);
        }    
    }

    public class MoIPResposta
    {
        public string ID { get; set; }
        public string Token { get; set; }
        public bool Sucesso { get; set; }
    }
    public class Pagador
    {
        public string Nome { get; set; }
        public string LoginMoIP { get; set; }
        public string Email { get; set; }
        public string TelefoneCelular { get; set; }
        public string Apelido { get; set; }
        public string Identidade { get; set; }
        public EnderecoCobranca EnderecoCobranca { get; set; }

    }

    public class EnderecoCobranca
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CEP { get; set; }
        public string TelefoneFixo { get; set; }

    }


    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
