using MoIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMoIP_ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            InstrucaoMoIP moip = new InstrucaoMoIP();

            moip.Key = "sua_key";
            moip.Token = "seu_token";
            moip.Razao = "Pagamento de testes";
            moip.Valor = 150.25M;
            MoIPResposta resposta = moip.Enviar();
            var Token = resposta.Token;
        }
    }
}
