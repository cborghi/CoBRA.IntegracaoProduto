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
    
    public partial class TB_PERIODO_META
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_PERIODO_META()
        {
            this.TB_ORIGEM_DADOS_PAINEL_META = new HashSet<TB_ORIGEM_DADOS_PAINEL_META>();
        }
    
        public System.Guid ID_PERIODO { get; set; }
        public string DESCRICAO { get; set; }
        public System.DateTime DATA_INICIO { get; set; }
        public System.DateTime DATA_FIM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_ORIGEM_DADOS_PAINEL_META> TB_ORIGEM_DADOS_PAINEL_META { get; set; }
    }
}
