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
    
    public partial class ANT_DATA_ESPECIAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ANT_DATA_ESPECIAL()
        {
            this.ANT_PRODUTO_DATAESPECIAL = new HashSet<ANT_PRODUTO_DATAESPECIAL>();
        }
    
        public int DAES_ID { get; set; }
        public string DAES_DIA { get; set; }
        public string DAES_DESCRICAO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANT_PRODUTO_DATAESPECIAL> ANT_PRODUTO_DATAESPECIAL { get; set; }
    }
}
