using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoBRA.IntegracaoProduto.WS.Entidade
{
    public class ProdutoJsonLog
    {
        public Guid IdJsonLog { get; set; }
        public string UrlJson { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataLog { get; set; }
        public string ProdEbsa { get; set; }
    }
}
