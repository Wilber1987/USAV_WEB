//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace USAV_Solicitudes
{
    using System;
    using System.Collections.Generic;
    
    public partial class ViewReservasLoc
    {
        public int IdReserva { get; set; }
        public string NombreInstitucion { get; set; }
        public string NombreSolicitante { get; set; }
        public string Telefono { get; set; }
        public string Cargo { get; set; }
        public string e_mail { get; set; }
        public Nullable<int> IdTipoReserva { get; set; }
        public string DescReserva { get; set; }
        public Nullable<System.DateTime> FechaSolicitud { get; set; }
        public Nullable<int> HoraSolicitud { get; set; }
        public Nullable<int> Duracion { get; set; }
        public Nullable<bool> Confirmacion { get; set; }
        public Nullable<int> NumeroIndividuos { get; set; }
        public Nullable<int> NumeroIndFemeninos { get; set; }
        public string DescLocalidades { get; set; }
        public string DescEdificios { get; set; }
        public string ConfirmacionText { get; set; }
        public Nullable<int> IdCreadorVideo { get; set; }
    }
}
