using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace MoIP.Extensions
{
    public static class DocumentExtensions
    {
        public  static string BuscarXml()
        {
            string path = HttpContext.Current.Server.MapPath("~/App_Data/data.xml");
            XDocument doc = XDocument.Load(path);
            var stringXml = doc.ToXmlDocument();
            return stringXml.OuterXml;
        }
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
}
