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
    
    public partial class TB_CONSULTOR_REGIAO
    {
        public System.Guid ID_CONSULTOR_REGIAO { get; set; }
        public System.Guid ID_CONSULTOR { get; set; }
        public System.Guid ID_REGIAO { get; set; }
        public System.DateTime DT_CADASTRO { get; set; }
    
        public virtual TB_USUARIO_RM TB_USUARIO_RM { get; set; }
        public virtual TB_REGIAO TB_REGIAO { get; set; }
    }
}
