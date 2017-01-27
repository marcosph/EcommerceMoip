using MoIP.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace MoIP
{
    public interface IMoipService
    {
        string BuscarXml();
    }
    public class MoipService: IMoipService
    {
        
        public string BuscarXml()
        {
            string path = HttpContext.Current.Server.MapPath("~/App_Data/data.xml");
            XDocument doc = XDocument.Load(path);
            var stringXml = doc.ToXmlDocument();
            return stringXml.OuterXml;
        }
    }
}
