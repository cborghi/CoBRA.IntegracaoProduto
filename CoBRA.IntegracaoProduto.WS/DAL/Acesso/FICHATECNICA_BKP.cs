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
    
    public partial class FICHATECNICA_BKP
    {
        public int ID { get; set; }
        public Nullable<decimal> Prod_id { get; set; }
        public Nullable<decimal> Paginas { get; set; }
        public Nullable<decimal> FormatoAlura { get; set; }
        public Nullable<decimal> FormatoLargura { get; set; }
        public Nullable<decimal> Peso { get; set; }
        public string MioloCores { get; set; }
        public string MioloTipoPapel { get; set; }
        public string MioloGramatura { get; set; }
        public string MioloObservacoes { get; set; }
        public string CapaCores { get; set; }
        public string CapaTipoPapel { get; set; }
        public string CapaGramatura { get; set; }
        public string CapaOrelha { get; set; }
        public string CapaAcabamento { get; set; }
        public string CapaObservacoes { get; set; }
        public string CapaAcabamentoDaLombada { get; set; }
        public Nullable<decimal> CadernoPaginas { get; set; }
        public Nullable<decimal> CadernoAltura { get; set; }
        public Nullable<decimal> CadernoLargura { get; set; }
        public Nullable<int> CadernoTipo { get; set; }
        public string CadernoTipoOutros { get; set; }
        public Nullable<decimal> CadernoPeso { get; set; }
        public string CadernoMioloCores { get; set; }
        public string CadernoMioloTipoPapel { get; set; }
        public string CadernoMioloGramatura { get; set; }
        public string CadernoMioloObservacoes { get; set; }
        public string CadernoCapaCores { get; set; }
        public string CadernoCapaTipoPapel { get; set; }
        public string CadernoCapaGramatura { get; set; }
        public string CadernoCapaOrelha { get; set; }
        public string CadernoCapaAcabamento { get; set; }
        public string CadernoCapaObservacoes { get; set; }
        public string CadernoCapaAcabamentoDaLombada { get; set; }
        public Nullable<int> EncarteTipo { get; set; }
        public string EncarteAcabamento { get; set; }
        public string EncartePapel { get; set; }
        public Nullable<int> CaixaFormato { get; set; }
        public string CaixaAcabamento { get; set; }
        public string CaixaPapel { get; set; }
        public Nullable<int> Midia { get; set; }
        public string ObservacoesGerais { get; set; }
        public string Foto { get; set; }
        public string FotoCaminhoAbsoluto { get; set; }
    
        public virtual PRODUTO_BKP PRODUTO_BKP { get; set; }
    }
}
