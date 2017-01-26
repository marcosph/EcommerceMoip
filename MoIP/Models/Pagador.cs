using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoIP.Models
{
    public class Pagador
    {
        public Pagador()
        {
            EnderecoCobranca = new EnderecoCobranca();
        }

        public string Nome { get; set; }
        public string LoginMoIP { get; set; }
        public string TelefoneCelular { get; set; }
        public string Apelido { get; set; }
        public string Identidade { get; set; }
        public EnderecoCobranca EnderecoCobranca { get; set; }

       
    }
}
