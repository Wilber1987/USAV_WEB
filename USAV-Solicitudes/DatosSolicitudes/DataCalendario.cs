using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;

namespace USAV_Solicitudes.DatosSolicitudes
{
    public class DataCalendario:TblCalendario
    {
        public List<VistaLocalidadCalendario> InicializarCalendario(TblCalendario Calendario, DateTime SystemDate)
        { 
            DataTable dt = new DataTable();
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                DateTime Date1 = SystemDate.AddDays(-1 * ((int)SystemDate.DayOfWeek - 1));
                DateTime Date2 = SystemDate.AddDays((-1 * ((int)SystemDate.DayOfWeek - 1)) + 5);

                var Query = from C in context.VistaLocalidadCalendario
                            where C.FechaCalendario >= Date1 && C.FechaCalendario <= Date2
                            select C;                                
                return Query.ToList();
            }          

        }

        public List<VistaLocalidadCalendario> InicializarCalendario(DateTime Date1, DateTime Date2, int Id)
        {            
            BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes();    
            var Query = from C in context.VistaLocalidadCalendario
                            where C.FechaCalendario >= Date1 && C.FechaCalendario <= Date2 && C.IdLocalidad == Id
                            select C;
           return Query.ToList();
            
        }

        public List<TblCalendario> InicializarCalendario(DateTime SystemDate, int Id)
        {
            DataTable dt = new DataTable();
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                DateTime Date1 = SystemDate.AddDays(-1 * ((int)SystemDate.DayOfWeek - 1));
                DateTime Date2 = SystemDate.AddDays((-1 * ((int)SystemDate.DayOfWeek - 1)) + 5);

                var Query = from C in context.TblCalendario
                            where C.FechaCalendario >= Date1 && C.FechaCalendario <= Date2 && C.IdLocalidad == Id
                            select C;
                return Query.ToList();
            }
        }


        public List<TblCalendario> InicializarCalendarioActividades(DateTime SystemDate, int Id)
        {
            DataTable dt = new DataTable();
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                DateTime Date1 = SystemDate.AddDays(-1 * ((int)SystemDate.DayOfWeek - 1));
                DateTime Date2 = SystemDate.AddDays((-1 * ((int)SystemDate.DayOfWeek - 1)) + 5);

                var Query = from C in context.TblCalendario
                            where C.FechaCalendario >= Date1 && C.FechaCalendario <= Date2 && C.IdLocalidad == Id
                            select C;
                return Query.ToList();
            }
        }


        //public List<CategoriaEntidad> ObtenerCategoriaPorNombre(string Nombre)
        //{
        //    using (BDVideosUSAVEntities contex = new BDVideosUSAVEntities())
        //    {

        //        var encontrado = from c in contex.TblCategorias
        //                         where c.NombreCategoria.Contains(Nombre)
        //                         select new CategoriaEntidad
        //                         {
        //                             IdCategoria = c.IdCategoria,
        //                             NombreCategoria = c.NombreCategoria,
        //                             Estado = c.Estado
        //                         };
        //        return encontrado.ToList();
        //    }
        //}
    }
}
