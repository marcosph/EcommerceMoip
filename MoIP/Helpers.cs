using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MoIP
{
    public  class Helpers
    {
        public static string GetXMLFromObject(object o)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
            }
            catch (Exception ex)
            {
                //Handle Exception Code
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            return sw.ToString();
        }

        public static ConsultarInstrucao ConsultarStatusPagamento(string token_)
        {
            string Key = "RNYNTJC6NDBBMY4W3SKZ6V2MRFWOTDFBE3W0KDBO";
            string Token = "II5MMMP9FXOPV0UYCHI8DDZU08LNR72P";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            WebClient client = new WebClient();
            // string URI = "https://desenvolvedor.moip.com.br/sandbox/ws/alpha/ConsultarInstrucao/" + token_;
            string URI = "https://desenvolvedor.moip.com.br/sandbox/ws/alpha/ConsultarInstrucao/" + token_;
            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(Token + ":" + Key));
            client.Headers.Add("Authorization: Basic " + auth);
            client.Headers.Add("User-Agent: Mozilla/4.0");
            byte[] ResponseArray = client.DownloadData(URI);
            string Response = Encoding.UTF8.GetString(ResponseArray);
            return GetMoIPRespostaFromXML(Response);
        }
        public static ConsultarInstrucao GetMoIPRespostaFromXML(string Response)
        {
            XmlDocument XmlResposta = new XmlDocument();
            XmlResposta.LoadXml(Response);

            var resposta = new ConsultarInstrucao();
            resposta.RespostaConsultarID = XmlResposta.DocumentElement.SelectSingleNode("//RespostaConsultar//ID").InnerText;
            resposta.RespostaConsultarStatus = XmlResposta.DocumentElement.SelectSingleNode("//RespostaConsultar//Status").InnerText;
          //  resposta.RespostaConsultarErro = XmlResposta.DocumentElement.SelectSingleNode("//RespostaConsultar//Erro").InnerText;
            resposta.RespostaConsultarStatusSuccess = resposta.RespostaConsultarStatus.Equals("Success") ? true : false;

            if (!resposta.RespostaConsultarStatus.Equals("Sucesso"))
            {
                return resposta;
            }           
            resposta.PagamentoStatus = XmlResposta.DocumentElement.SelectSingleNode("//Pagamento//Status").InnerText;

            return resposta;
        }
    }
    
    public class ConsultarInstrucao
    {
        public string PagamentoStatus { get; set; }
        public string RespostaConsultarID { get; set; }
        public string RespostaConsultarStatus { get; set; }
        public string RespostaConsultarErro { get; set; }
        public bool RespostaConsultarStatusSuccess { get; set; }
    }
}
