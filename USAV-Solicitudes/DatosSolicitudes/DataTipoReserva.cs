using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAV_Solicitudes.DatosSolicitudes
{
    public class DataTipoReserva:CatTipoReserva
    {
        public Object InicializarTipoR()
        {
            //DataTable dt = new DataTable();
            BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes();
            
                var Query = from L in context.CatTipoReserva
                            select new { L.IdTipoReserva, L.DescTipoReserva };
                return Query.ToList();
            

        }

        public bool GuardarTipoReserva(CatTipoReserva Obj)
        {
            try
            {
                BDVideosUSAVEntitiesModelSolicitudes Model = new BDVideosUSAVEntitiesModelSolicitudes();
                

                    var querybusca = from c in Model.CatTipoBloques
                                     where c.Descripcion == Obj.DescTipoReserva
                                     select c;

                    if (querybusca.ToList().Count == 0)
                    {
                        Model.CatTipoReserva.Add(Obj);
                        Model.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                
            }
            catch
            {
                return false;
            }
        }



        public bool ActualizaTipoReserva(CatTipoReserva Obj)
        {
            try
            {
                BDVideosUSAVEntitiesModelSolicitudes Model = new BDVideosUSAVEntitiesModelSolicitudes();
                


                    var querybusca = from c in Model.CatTipoReserva
                                     where c.DescTipoReserva == Obj.DescTipoReserva && c.IdTipoReserva != Obj.IdTipoReserva 
                                     select c;
                    if (querybusca.ToList().Count == 0)
                    {
                        var objeto = Model.CatTipoReserva.FirstOrDefault(c => c.IdTipoReserva == Obj.IdTipoReserva);
                        objeto.IdTipoReserva = Obj.IdTipoReserva;
                        objeto.DescTipoReserva = Obj.DescTipoReserva;
                        Model.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                
            }
            catch (Exception)
            {
                return false;
            }
        }     

        public List<CatTipoReserva> VerTipoReserva(int ID)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                var Query = from C in context.CatTipoReserva
                            where C.IdTipoReserva == ID
                            select C;
                return Query.ToList();
            }
        }


        public List<CatTipoReserva> VerTipoReserva(string nombre)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                var Query = from C in context.CatTipoReserva
                            where C.DescTipoReserva.Contains(nombre)
                            select C;
                return Query.ToList();
            }
        }
     
    
    
    
    }
}
