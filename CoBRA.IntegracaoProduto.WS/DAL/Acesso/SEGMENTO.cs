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
    
    public partial class SEGMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SEGMENTO()
        {
            this.ANT_ANO_EDUCACAO = new HashSet<ANT_ANO_EDUCACAO>();
            this.PRODUTO_BKP = new HashSet<PRODUTO_BKP>();
        }
    
        public decimal SEGM_ID { get; set; }
        public string SEGM_DESCRICAO { get; set; }
        public string ABREVIACAO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANT_ANO_EDUCACAO> ANT_ANO_EDUCACAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUTO_BKP> PRODUTO_BKP { get; set; }
    }
}
