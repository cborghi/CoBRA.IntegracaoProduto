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
    
    public partial class TB_PERMISSAO_REQUISICAO
    {
        public System.Guid ID_PERMISSAO_USUARIO { get; set; }
        public int ID_USUARIO { get; set; }
        public Nullable<bool> APROVA_REQUISICAO_SUPERVISOR { get; set; }
        public Nullable<bool> REPROVA_REQUISICAO_SUPERVISOR { get; set; }
        public Nullable<bool> CANCELA_REQUISICAO_SUPERVISOR { get; set; }
        public Nullable<bool> APROVA_REQUISICAO_GERENTE { get; set; }
        public Nullable<bool> REPROVA_REQUISICAO_GERENTE { get; set; }
        public Nullable<bool> CANCELA_REQUISICAO_GERENTE { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
    }
}
