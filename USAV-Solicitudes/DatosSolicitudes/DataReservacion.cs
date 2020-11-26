using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAV_Solicitudes.DatosSolicitudes
{
    public class DataReservacion: TblReservas
    {
        #region ComandosBasicos
        public bool GuardarReservacion(TblReservas ObjReserva,List<TblCalendario> ObjCalendario)
        {
            try
            {
                BDVideosUSAVEntitiesModelSolicitudes Model = new BDVideosUSAVEntitiesModelSolicitudes();
                
                    Model.TblReservas.Add(ObjReserva);
                    foreach (TblCalendario Calendar in ObjCalendario)
                    {
                        var ResLoc = new TblReservaLocalidad 
                                    { IdCalendario=Calendar.IdCalendario, TblReservas=ObjReserva };
                        Model.TblReservaLocalidad.Add(ResLoc);
                    }
                    Model.SaveChanges();
                    return true;
                
            }
            catch
            {
                return false;
            }
        }

        public bool ActualizaReservas(TblReservas obj)
        {
            try
            {
                BDVideosUSAVEntitiesModelSolicitudes Model = new BDVideosUSAVEntitiesModelSolicitudes();
                
                    var objeto = Model.TblReservas.FirstOrDefault(c => c.IdReserva == obj.IdReserva);
                    objeto.IdReserva = obj.IdReserva;
                    objeto.Confirmacion = obj.Confirmacion;
                    Model.SaveChanges();
                    return true;                
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region vistaReservaciones
        public List<TblReservas> VerReservaciones()
        {
            BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes();
            
                var Query = (from C in context.TblReservas
                             select C).Take(30);
                return Query.ToList();
            
        }


        public List<TblReservas> VerReservaciones(string Valor)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                
                bool? Confir=null;
                if (Valor != "null")
                {
                    Confir = Convert.ToBoolean(Valor);
                    var Query = (from C in context.TblReservas
                                where C.Confirmacion == Confir
                                select C).Take(30);
                    return Query.ToList();
                }
                else
                {
                   // var Query = context.TblReservas.Where(v => v.Confirmacion == null);                   
                    var Query = (from C in context.TblReservas
                                where C.Confirmacion == null
                                select C).Take(30);
                    return Query.ToList();
                }
            }
        }
        public List<TblReservas> VerReservaciones(int ID)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                var Query = from C in context.TblReservas
                            where C.IdReserva == ID
                            select C;
                return Query.ToList();
            }
        }

        #endregion
              
        #region ReservacionesXLocalidad

        public List<ViewReservasLoc> VerReservacionesL(string Valor, string Localidad)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {

                bool? Confir = null;
                if (Valor != "null")
                {
                    Confir = Convert.ToBoolean(Valor);
                    var Query = (from C in context.ViewReservasLoc
                                 where C.Confirmacion == Confir && C.DescLocalidades == Localidad
                                 select C).Take(30);
                    return Query.ToList();
                }
                else
                {
                    // var Query = context.TblReservas.Where(v => v.Confirmacion == null);                   
                    var Query = (from C in context.ViewReservasLoc
                                 where C.Confirmacion == null && C.DescLocalidades == Localidad
                                 select C).Take(30);
                    return Query.ToList();
                }
            }
        }

        public List<ViewReservasLoc> VerReservacionesTodasXL(string Localidad)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {                

                var Query = (from C in context.ViewReservasLoc
                             where  C.DescLocalidades == Localidad
                             select C).Take(30);
                return Query.ToList();
            }
        }

        #endregion


        public List<ViewReservasLoc> VerReservacionesL()
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                #region EjemploJoin
                //var query =
                //from R in context.TblReservas
                //join L in context.CatLocalidades
                //on R.id equals
                //    detail.Field<int>("SalesOrderID")
                //where order.Field<bool>("OnlineOrderFlag") == true
                //&& order.Field<DateTime>("OrderDate").Month == 8
                //select new
                //{
                //    SalesOrderID =
                //        order.Field<int>("SalesOrderID"),
                //    SalesOrderDetailID =
                //        detail.Field<int>("SalesOrderDetailID"),
                //    OrderDate =
                //        order.Field<DateTime>("OrderDate"),
                //    ProductID =
                //        detail.Field<int>("ProductID")
                //};
                #endregion
                
                var Query = (from C in context.ViewReservasLoc
                             select C).Take(30);
                return Query.ToList();
            }
        }
        public List<ViewReservasLoc> VerReservacionesL(string Valor)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {

                bool? Confir = null;
                if (Valor != "null")
                {
                    Confir = Convert.ToBoolean(Valor);
                    var Query = (from C in context.ViewReservasLoc
                                 where C.Confirmacion == Confir
                                 select C).Take(30);
                    return Query.ToList();
                }
                else
                {
                    // var Query = context.TblReservas.Where(v => v.Confirmacion == null);                   
                    var Query = (from C in context.ViewReservasLoc
                                 where C.Confirmacion == null
                                 select C).Take(30);
                    return Query.ToList();
                }
            }
        }     

        public List<ViewReservasLoc> VerReservacionesL(int ID)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                var Query = from C in context.ViewReservasLoc
                            where C.IdReserva == ID
                            select C;
                return Query.ToList();
            }
        }

        public List<USP_DetalleS_Result> VerDetalleSolicitud(int ID)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                var Query = context.USP_DetalleS(ID);
                return Query.ToList();
            }
        }

        public List<ViewReservasLoc> VerReservacionesXfecha(DateTime f1, DateTime f2)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                var Query = from C in context.ViewReservasLoc
                            where  (C.FechaSolicitud >= f1 && C.FechaSolicitud <= f2)
                            select C;
                return Query.ToList();
            }
        }

        public List<ViewReservasLoc> VerReservacionesXfecha(string Valor, DateTime f1, DateTime f2)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {

                bool? Confir = null;
                if (Valor != "null")
                {
                    Confir = Convert.ToBoolean(Valor);
                    var Query = (from C in context.ViewReservasLoc
                                 where C.Confirmacion == Confir 
                                 && (C.FechaSolicitud >= f1 && C.FechaSolicitud <= f2)
                                 select C).Take(30);
                    return Query.ToList();
                }
                else
                {
                    // var Query = context.TblReservas.Where(v => v.Confirmacion == null);                   
                    var Query = (from C in context.ViewReservasLoc
                                 where C.Confirmacion == null
                                  && (C.FechaSolicitud >= f1 && C.FechaSolicitud <= f2)
                                 select C).Take(30);
                    return Query.ToList();
                }
            }
        }


        #region ReservacionesXDocente

        public List<ViewReservasLoc> VerReservacionesXDocente(int ID)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                var Query = from C in context.ViewReservasLoc
                            where  C.IdCreadorVideo == ID
                            select C;
                return Query.ToList();
            }
        }

        public List<ViewReservasLoc> VerReservacionesXDocente(string Valor, int IdDocente)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {

                bool? Confir = null;
                if (Valor != "null")
                {
                    Confir = Convert.ToBoolean(Valor);
                    var Query = (from C in context.ViewReservasLoc
                                 where C.Confirmacion == Confir && C.IdCreadorVideo == IdDocente
                                 select C).Take(30);
                    return Query.ToList();
                }
                else
                {
                    // var Query = context.TblReservas.Where(v => v.Confirmacion == null);                   
                    var Query = (from C in context.ViewReservasLoc
                                 where C.Confirmacion == null && C.IdCreadorVideo == IdDocente
                                 select C).Take(30);
                    return Query.ToList();
                }
            }
        }
        public List<ViewReservasLoc> VerReservacionesXDocente(DateTime f1, DateTime f2, int ID)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                var Query = from C in context.ViewReservasLoc
                            where C.IdCreadorVideo == ID
                            && (C.FechaSolicitud >= f1 && C.FechaSolicitud <= f2)
                            select C;
                return Query.ToList();
            }
        }
      

        public List<ViewReservasLoc> VerReservacionesXDocente(string Valor, DateTime f1, DateTime f2, int IdDocente)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {

                bool? Confir = null;
                if (Valor != "null")
                {
                    Confir = Convert.ToBoolean(Valor);
                    var Query = (from C in context.ViewReservasLoc
                                 where C.Confirmacion == Confir && C.IdCreadorVideo == IdDocente
                                 && (C.FechaSolicitud>= f1 && C.FechaSolicitud<=f2)
                                 select C).Take(30);
                    return Query.ToList();
                }
                else
                {
                    // var Query = context.TblReservas.Where(v => v.Confirmacion == null);                   
                    var Query = (from C in context.ViewReservasLoc
                                 where C.Confirmacion == null && C.IdCreadorVideo == IdDocente
                                  && (C.FechaSolicitud >= f1 && C.FechaSolicitud <= f2)
                                 select C).Take(30);
                    return Query.ToList();
                }
            }
        }

       
        #endregion

    }
}
