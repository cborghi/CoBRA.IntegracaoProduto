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
    
    public partial class TB_JSON_LOG_INTEGRACAO_PROTHEUS
    {
        public System.Guid ID_JSON_LOG { get; set; }
        public string URL_JSON { get; set; }
        public int ID_USUARIO { get; set; }
        public System.DateTime DT_LOG { get; set; }
        public string PROD_EBSA { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
    }
}
