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
    
    public partial class TB_USUARIO_RM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_USUARIO_RM()
        {
            this.TB_CONSULTOR_REGIAO = new HashSet<TB_CONSULTOR_REGIAO>();
            this.TB_GERENTE_SUPERVISOR = new HashSet<TB_GERENTE_SUPERVISOR>();
            this.TB_GERENTE_SUPERVISOR1 = new HashSet<TB_GERENTE_SUPERVISOR>();
            this.TB_META_ANUAL = new HashSet<TB_META_ANUAL>();
            this.TB_META_FINANCEIRA = new HashSet<TB_META_FINANCEIRA>();
            this.TB_META_REAL = new HashSet<TB_META_REAL>();
            this.TB_SUPERVISOR_CONSULTOR = new HashSet<TB_SUPERVISOR_CONSULTOR>();
            this.TB_SUPERVISOR_CONSULTOR1 = new HashSet<TB_SUPERVISOR_CONSULTOR>();
        }
    
        public System.Guid ID_USUARIO_RM { get; set; }
        public System.Guid ID_CARGO { get; set; }
        public Nullable<System.Guid> ID_FILIAL { get; set; }
        public Nullable<System.Guid> ID_REGIAO_ATUACAO { get; set; }
        public Nullable<System.DateTime> DATA_INICIO { get; set; }
        public Nullable<System.DateTime> DATA_FIM { get; set; }
        public Nullable<System.Guid> ID_SECAO { get; set; }
        public Nullable<int> CODIGO_FILIAL { get; set; }
        public string NOME { get; set; }
        public string NUMERO_CHAPA { get; set; }
        public string CPF { get; set; }
        public string CODIGO_PROTHEUS { get; set; }
        public Nullable<bool> ATIVO { get; set; }
    
        public virtual TB_CARGO TB_CARGO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_CONSULTOR_REGIAO> TB_CONSULTOR_REGIAO { get; set; }
        public virtual TB_FILIAL TB_FILIAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_GERENTE_SUPERVISOR> TB_GERENTE_SUPERVISOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_GERENTE_SUPERVISOR> TB_GERENTE_SUPERVISOR1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_META_ANUAL> TB_META_ANUAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_META_FINANCEIRA> TB_META_FINANCEIRA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_META_REAL> TB_META_REAL { get; set; }
        public virtual TB_REGIAO_ATUACAO TB_REGIAO_ATUACAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_SUPERVISOR_CONSULTOR> TB_SUPERVISOR_CONSULTOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_SUPERVISOR_CONSULTOR> TB_SUPERVISOR_CONSULTOR1 { get; set; }
    }
}
