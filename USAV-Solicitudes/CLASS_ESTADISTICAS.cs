using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using USAV_Solicitudes;
using System.ComponentModel;

namespace Interface.USAVSolicitudes.Estadisticas
{
    public class CLASS_ESTADISTICAS
    {
        public List<VIEW_ESTADISTICAS_TIPORESERVACION> ReporteTipoReserva()
        {
            using (USAV_Solicitudes.BDVideosUSAVEntitiesModelSolicitudes Model = new USAV_Solicitudes.BDVideosUSAVEntitiesModelSolicitudes())
            {
                var Query = from C in Model.VIEW_ESTADISTICAS_TIPORESERVACION                            
                            select C;
                return Query.ToList();                            
            }
        }
    
        private class ViewTypeReport
        {
            public int IdReserva { get; set; }
            public string DescLocalidades { get; set; }
            public DateTime FechaSolicitud { get; set; }
            public string DescTipoReserva { get; set; }
            public string NombreSolicitante { get; set; }
            public string NombreInstitucion { get; set; }
            public string DescReserva { get; set; }
            public int DuracionMT { get; set; }
        }
        private class ViewTypeReport_Cargar_CantReservas_XFecha
        {            
            public string DescLocalidades { get; set; }            
            public int Expr1 { get; set; }
        }

        public DataTable ReporteTipoReservaDT()
        {
            using (USAV_Solicitudes.BDVideosUSAVEntitiesModelSolicitudes Model = new USAV_Solicitudes.BDVideosUSAVEntitiesModelSolicitudes())
            {
                var Query = from C in Model.VIEW_ESTADISTICAS_TIPORESERVACION
                            select C;
                DataTable dt = new DataTable();
                PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(ViewTypeReport));
                
                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    dt.Columns.Add(prop.Name, prop.PropertyType);
                }               
                foreach(VIEW_ESTADISTICAS_TIPORESERVACION EST in Query)
                {
                    DataRow row = dt.NewRow();
                    row["IdReserva"] = EST.IdReserva;
                    row["DescLocalidades"] = EST.DescLocalidades;
                    row["FechaSolicitud"] = EST.FechaSolicitud;
                    row["DescTipoReserva"] = EST.DescTipoReserva;
                    row["NombreSolicitante"] = EST.NombreSolicitante;
                    row["NombreInstitucion"] = EST.NombreInstitucion;
                    row["DescReserva"] = EST.DescReserva;
                    row["DuracionMT"] = EST.DuracionMT;                    
                    dt.Rows.Add(row);
                }
                return dt;
            }
        }

        
        //public DataTable ReporteTipoReservaDTXFecha(string Fecha,string Fecha2)
        //{
        //    using (USAV_Solicitudes.BDVideosUSAVEntitiesModelSolicitudes Model = new USAV_Solicitudes.BDVideosUSAVEntitiesModelSolicitudes())
        //    {
        //        bool? Confir = true;
        //        DateTime Fech = Convert.ToDateTime(Fecha);
        //        DateTime Fech2 = Convert.ToDateTime(Fecha2).AddDays(1);
        //        //Fech2.AddDays(1);
        //        var Query = from C in Model.VIEW_ESTADISTICAS_TIPORESERVACION
        //                    where C.FechaSolicitud >= Fech
        //                           && C.FechaSolicitud < Fech2
        //                           //&& C.Confirmacion == Confir
        //                    select C;
        //        DataTable dt = new DataTable();
        //        PropertyDescriptorCollection props =
        //        TypeDescriptor.GetProperties(typeof(ViewTypeReport));

        //        for (int i = 0; i < props.Count; i++)
        //        {
        //            PropertyDescriptor prop = props[i];
        //            dt.Columns.Add(prop.Name, prop.PropertyType);
        //        }
        //        foreach (VIEW_ESTADISTICAS_TIPORESERVACION EST in Query)
        //        {
        //            DataRow row = dt.NewRow();
        //            row["IdReserva"] = EST.IdReserva;
        //            row["DescLocalidades"] = EST.DescLocalidades;
        //            row["FechaSolicitud"] = EST.FechaSolicitud;
        //            row["DescTipoReserva"] = EST.DescTipoReserva;
        //            row["NombreSolicitante"] = EST.NombreSolicitante;
        //            row["NombreInstitucion"] = EST.NombreInstitucion;
        //            row["DescReserva"] = EST.DescReserva;
        //            row["DuracionMT"] = EST.DuracionMT;
        //            dt.Rows.Add(row);
        //        }
        //        return dt;
        //    }
        //}
        public DataTable ReporteTipoReservaDTXFecha(string Fecha, string Fecha2, string Localidad)
        {
            using (USAV_Solicitudes.BDVideosUSAVEntitiesModelSolicitudes Model = new USAV_Solicitudes.BDVideosUSAVEntitiesModelSolicitudes())
            {
                bool? Confir = true;
                DateTime Fech = Convert.ToDateTime(Fecha);
                DateTime Fech2 = Convert.ToDateTime(Fecha2).AddDays(1);
                //Fech2.AddDays(1);
                var Query = from C in Model.VIEW_ESTADISTICAS_TIPORESERVACION
                            where C.FechaSolicitud >= Fech
                                   && C.FechaSolicitud < Fech2
                                   //&& C.Confirmacion == Confir
                                   && C.DescLocalidades == Localidad
                            select C;
                DataTable dt = new DataTable();
                PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(ViewTypeReport));

                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    dt.Columns.Add(prop.Name, prop.PropertyType);
                }
                foreach (VIEW_ESTADISTICAS_TIPORESERVACION EST in Query)
                {
                    DataRow row = dt.NewRow();
                    row["IdReserva"] = EST.IdReserva;
                    row["DescLocalidades"] = EST.DescLocalidades;
                    row["FechaSolicitud"] = EST.FechaSolicitud;
                    row["DescTipoReserva"] = EST.DescTipoReserva;
                    row["NombreSolicitante"] = EST.NombreSolicitante;
                    row["NombreInstitucion"] = EST.NombreInstitucion;
                    row["DescReserva"] = EST.DescReserva;
                    row["DuracionMT"] = EST.DuracionMT;
                    dt.Rows.Add(row);
                }
                return dt;
            }
        }


        public DataTable VerCANTRESERVASXFECHA(DateTime FECHA1, DateTime FECHA2)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                var Query = context.CARGAR_CANTRESERVAS_XFECHA(FECHA1, FECHA2);
                DataTable dt = new DataTable();
                PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(ViewTypeReport_Cargar_CantReservas_XFecha));

                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    dt.Columns.Add(prop.Name, prop.PropertyType);
                }
                foreach (CARGAR_CANTRESERVAS_XFECHA_Result EST in Query)
                {
                    DataRow row = dt.NewRow();
                    row["DescLocalidades"] = EST.DescLocalidades;
                    row["Expr1"] = EST.Expr1;                    
                    dt.Rows.Add(row);
                }
                return dt;                
            }
        }

        public DataTable VerCANTRESERVASXFECHA(DateTime FECHA1, DateTime FECHA2, string Localidad)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                var Query = context.CARGAR_CANTRESERVAS_XFECHA(FECHA1, FECHA2);
                DataTable dt = new DataTable();
                PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(ViewTypeReport_Cargar_CantReservas_XFecha));

                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    dt.Columns.Add(prop.Name, prop.PropertyType);
                }
                foreach (CARGAR_CANTRESERVAS_XFECHA_Result EST in Query)
                {
                    if (EST.DescLocalidades == Localidad)
                    {
                        DataRow row = dt.NewRow();
                        row["DescLocalidades"] = EST.DescLocalidades;
                        row["Expr1"] = EST.Expr1;
                        dt.Rows.Add(row);
                    }
                }
                return dt;
            }
        }


        //public List<VIEW_ACTIVIDADES> VerActividadesCalendar(string Fecha)
        //{
        //    using (USAV_Solicitudes.BDVideosUSAVEntitiesModelSolicitudes Model = new USAV_Solicitudes.BDVideosUSAVEntitiesModelSolicitudes())
        //    {
        //        DateTime Fech = Convert.ToDateTime(Fecha);
        //        DateTime Fech2 = Fech.AddDays(1);
        //        var Query = from C in Model.VIEW_ACTIVIDADES
        //                    where C.FechaCalendario >= Fech
        //                            && C.FechaCalendario < Fech2                         
        //                    select C;
        //        return Query.ToList();
              
        //    }
        //}

    }
}