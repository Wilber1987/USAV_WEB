//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace USAV_Solicitudes
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblMatriculadosCursos
    {
        public int IdMatricula { get; set; }
        public Nullable<int> IdCurso { get; set; }
        public string Carnet { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<System.DateTime> FechaMatricula { get; set; }
        public Nullable<System.DateTime> UltimoAcceso { get; set; }
    
        public virtual TblCurso TblCurso { get; set; }
    }
}