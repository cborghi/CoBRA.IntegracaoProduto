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
    
    public partial class LOG
    {
        public int ID { get; set; }
        public int ID_TIPO_LOG { get; set; }
        public Nullable<int> USUARIO { get; set; }
        public Nullable<System.DateTime> DATA_LOG { get; set; }
        public string DESCRICAO { get; set; }
        public string IpAdress { get; set; }
        public Nullable<int> ID_TIPO_SISTEMA { get; set; }
    }
}
