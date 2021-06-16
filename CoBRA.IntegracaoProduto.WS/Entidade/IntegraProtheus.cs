using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoBRA.IntegracaoProduto.WS.Entidade
{
    public class IntegraProtheus
    {
        public int ID_REGISTRO { get; set; }
        public int ID_PRODUTO { get; set; }
        public bool STATUS { get; set; }
        public string MENSAGEM { get; set; }
        public DateTime DATA { get; set; }
        public int ID_USUARIO { get; set; }

        public string StatusFormatado
        {
            get
            {
                return STATUS ? "Sucesso" : "Falha";
            }
        }
        public string DataFormatada
        {
            get
            {
                return DATA != null ? DATA.ToString("dd/MM/yyyy") : null;
            }
        }

        public string HoraFormatada
        {
            get
            {
                return DATA != null ? DATA.ToString("H:mm:ss") : null;
            }
        }

    }
}
