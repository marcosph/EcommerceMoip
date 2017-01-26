using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoIP.Models
{
    public class InstrucaoUnica
    {
        public InstrucaoUnica()
        {
            Razao = "Pagamento de exemplo com dados do pagador";
            Valores = new Valores() { Valor = "159.35" };
            IdProprio = "Pag2";
            DataVencimento = "2008-04-06T12:01:48.703-02:00";

            Pagador = new Pagador() {
                Nome= "Luiz Inácio Lula da Silva",
                Apelido = "Lula",
                EnderecoCobranca = new EnderecoCobranca()
                {
                    Bairro = "rua 1",
                    CEP= "70100-000",
                    Cidade = "Brasília",
                    Complemento= "Casa",
                    Estado = "DF",
                    Logradouro= "Praça dos Três Poderes",
                    Numero = "",
                    Pais= "BRA",
                    TelefoneFixo = "(61)3211-1221"
                }
            };
        }
       
        public string Razao { get; set; }
        public Valores Valores { get; set; }
        public string IdProprio { get; set; }
        public string DataVencimento { get; set; }
        public Pagador Pagador { get; set; }

       
    }
}
