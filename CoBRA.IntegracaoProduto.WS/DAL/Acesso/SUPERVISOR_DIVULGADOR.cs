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
    
    public partial class SUPERVISOR_DIVULGADOR
    {
        public int ID_SUPERVISOR_DIVULGADOR { get; set; }
        public int ID_ESTADO { get; set; }
        public int ID_USUARIO_SUPERVISOR { get; set; }
        public int ID_USUARIO_DIVULGADOR { get; set; }
    
        public virtual ESTADO ESTADO { get; set; }
        public virtual USUARIO USUARIO { get; set; }
        public virtual USUARIO USUARIO1 { get; set; }
    }
}