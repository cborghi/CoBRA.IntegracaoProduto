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
    
    public partial class TB_REGIAO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_REGIAO()
        {
            this.TB_CONSULTOR_REGIAO = new HashSet<TB_CONSULTOR_REGIAO>();
        }
    
        public System.Guid ID_REGIAO { get; set; }
        public string DESCRICAO { get; set; }
        public string UF { get; set; }
        public System.DateTime DT_CADASTRO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_CONSULTOR_REGIAO> TB_CONSULTOR_REGIAO { get; set; }
    }
}
