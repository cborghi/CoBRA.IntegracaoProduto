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
    
    public partial class TB_META_FINANCEIRA
    {
        public System.Guid ID_META_FINANCEIRA { get; set; }
        public System.Guid ID_USUARIO_RM { get; set; }
        public Nullable<System.Guid> ID_LINHA_META { get; set; }
        public Nullable<decimal> META_RECEITA_LIQUIDA { get; set; }
        public Nullable<decimal> VALOR_RECEBIMENTO { get; set; }
        public string OBSERVACAO { get; set; }
        public System.DateTime DATA_CRIACAO { get; set; }
        public Nullable<System.DateTime> DATA_ALTERACAO { get; set; }
        public System.Guid ID_STATUS { get; set; }
        public Nullable<decimal> ADD_META_RECEITA_LIQUIDA_CALC { get; set; }
        public Nullable<decimal> META_RECEITA_LIQUIDA_CALC { get; set; }
        public Nullable<System.Guid> ID_PERIODO { get; set; }
    
        public virtual TB_LINHA_PAINEL_META TB_LINHA_PAINEL_META { get; set; }
        public virtual TB_STATUS_PAINEL TB_STATUS_PAINEL { get; set; }
        public virtual TB_USUARIO_RM TB_USUARIO_RM { get; set; }
    }
}
