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
    
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            this.BKP_TB_PERMISSAO_REQUISICAO = new HashSet<BKP_TB_PERMISSAO_REQUISICAO>();
            this.GERENTE_SUPERVISOR_REGIAO = new HashSet<GERENTE_SUPERVISOR_REGIAO>();
            this.GERENTE_SUPERVISOR_REGIAO1 = new HashSet<GERENTE_SUPERVISOR_REGIAO>();
            this.SUPERVISOR_DIVULGADOR = new HashSet<SUPERVISOR_DIVULGADOR>();
            this.SUPERVISOR_DIVULGADOR1 = new HashSet<SUPERVISOR_DIVULGADOR>();
            this.TB_JSON_LOG_INTEGRACAO_PROTHEUS = new HashSet<TB_JSON_LOG_INTEGRACAO_PROTHEUS>();
            this.TB_PERMISSAO_REQUISICAO = new HashSet<TB_PERMISSAO_REQUISICAO>();
            this.TB_REGRA_ACESSO_ABA_CADASTRO_PRODUTO = new HashSet<TB_REGRA_ACESSO_ABA_CADASTRO_PRODUTO>();
            this.TB_REGRA_ACESSO_MENU_CADASTRO_PRODUTO = new HashSet<TB_REGRA_ACESSO_MENU_CADASTRO_PRODUTO>();
        }
    
        public int ID_USUARIO { get; set; }
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public string CONTA_AD { get; set; }
        public int ID_GRUPO { get; set; }
        public int ID_FILIAL { get; set; }
        public string RAMAL { get; set; }
        public string TELEFONE { get; set; }
        public bool ATIVO { get; set; }
        public string COD_USUARIO { get; set; }
        public Nullable<int> ID_NIVEL { get; set; }
        public Nullable<int> ID_CARGO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BKP_TB_PERMISSAO_REQUISICAO> BKP_TB_PERMISSAO_REQUISICAO { get; set; }
        public virtual CARGO CARGO { get; set; }
        public virtual FILIAL FILIAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GERENTE_SUPERVISOR_REGIAO> GERENTE_SUPERVISOR_REGIAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GERENTE_SUPERVISOR_REGIAO> GERENTE_SUPERVISOR_REGIAO1 { get; set; }
        public virtual NIVEL NIVEL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUPERVISOR_DIVULGADOR> SUPERVISOR_DIVULGADOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUPERVISOR_DIVULGADOR> SUPERVISOR_DIVULGADOR1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_JSON_LOG_INTEGRACAO_PROTHEUS> TB_JSON_LOG_INTEGRACAO_PROTHEUS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_PERMISSAO_REQUISICAO> TB_PERMISSAO_REQUISICAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_REGRA_ACESSO_ABA_CADASTRO_PRODUTO> TB_REGRA_ACESSO_ABA_CADASTRO_PRODUTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_REGRA_ACESSO_MENU_CADASTRO_PRODUTO> TB_REGRA_ACESSO_MENU_CADASTRO_PRODUTO { get; set; }
    }
}
