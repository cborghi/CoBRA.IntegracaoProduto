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
    
    public partial class ANT_PRODUTO_DATAESPECIAL
    {
        public decimal PDES_ID { get; set; }
        public Nullable<int> PDES_DAES { get; set; }
        public Nullable<decimal> PDES_PROD { get; set; }
    
        public virtual ANT_DATA_ESPECIAL ANT_DATA_ESPECIAL { get; set; }
        public virtual PRODUTO_BKP PRODUTO_BKP { get; set; }
    }
}