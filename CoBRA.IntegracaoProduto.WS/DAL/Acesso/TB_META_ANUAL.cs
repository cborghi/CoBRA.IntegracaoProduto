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
    
    public partial class TB_META_ANUAL
    {
        public System.Guid ID_META_ANUAL { get; set; }
        public System.Guid ID_USUARIO_RM { get; set; }
        public System.Guid ID_LINHA_META { get; set; }
        public System.Guid ID_UNIDADE_MEDIDA_PAINEL { get; set; }
        public decimal TOTAL { get; set; }
        public decimal VALOR_MINIMO { get; set; }
        public decimal VALOR_MAXIMO { get; set; }
        public System.DateTime DATA_CRIACAO { get; set; }
        public Nullable<System.DateTime> DATA_ALTERACAO { get; set; }
        public System.Guid ID_STATUS { get; set; }
    
        public virtual TB_LINHA_PAINEL_META TB_LINHA_PAINEL_META { get; set; }
        public virtual TB_STATUS_PAINEL TB_STATUS_PAINEL { get; set; }
        public virtual TB_UNIDADE_MEDIDA_PAINEL TB_UNIDADE_MEDIDA_PAINEL { get; set; }
        public virtual TB_USUARIO_RM TB_USUARIO_RM { get; set; }
    }
}
