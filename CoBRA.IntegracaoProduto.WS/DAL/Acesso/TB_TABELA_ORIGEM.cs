//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoBRA.IntegracaoProduto.WS.DAL.Acesso
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_TABELA_ORIGEM
    {
        public System.Guid ID_TABELA { get; set; }
        public string NOME_TABELA { get; set; }
        public System.DateTime DT_CADASTRO { get; set; }
        public System.Guid ID_SISTEMA { get; set; }
        public bool ATIVO { get; set; }
        public string DESCRICAO { get; set; }
    
        public virtual TB_SISTEMA_ORIGEM TB_SISTEMA_ORIGEM { get; set; }
        public virtual TB_TABELA_ORIGEM TB_TABELA_ORIGEM1 { get; set; }
        public virtual TB_TABELA_ORIGEM TB_TABELA_ORIGEM2 { get; set; }
    }
}
