using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;


namespace USAV_Solicitudes.DatosSolicitudes
{
     public class  DataCatTipoBloques:CatTipoBloques
    {


         public bool GuardarTipoBloque(CatTipoBloques Obj)
         {
             try
             {
                BDVideosUSAVEntitiesModelSolicitudes Model = new BDVideosUSAVEntitiesModelSolicitudes();
                     var querybusca = from c in Model.CatTipoBloques
                                      where c.Descripcion == Obj.Descripcion
                                      select c;

                     if (querybusca.ToList().Count == 0)
                     {
                         Model.CatTipoBloques.Add(Obj);
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

         public bool ActualizaTipoBloques(CatTipoBloques Obj)
         {
             try
             {
                BDVideosUSAVEntitiesModelSolicitudes Model = new BDVideosUSAVEntitiesModelSolicitudes();
                     var querybusca = from c in Model.CatTipoBloques
                                      where c.Descripcion == Obj.Descripcion && c.IdTipoBloque != Obj.IdTipoBloque
                                      select c;
                     if (querybusca.ToList().Count == 0)
                     {
                         var objeto = Model.CatTipoBloques.FirstOrDefault(c => c.IdTipoBloque == Obj.IdTipoBloque);
                         objeto.IdTipoBloque = Obj.IdTipoBloque;
                         objeto.Descripcion = Obj.Descripcion;
                         objeto.DuracionM = Obj.DuracionM;

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


         public Object InicializarTiposBloques()
         {
            BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes();
            var Query = from L in context.CatTipoBloques
                        select new { L.IdTipoBloque, L.Descripcion, L.DuracionM };
                 return Query.ToList();
         }

         public List<CatTipoBloques> VerTipoBloques(int ID)
         {
             using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())             {
                 var Query = from C in context.CatTipoBloques
                             where C.IdTipoBloque == ID
                             select C;
                 return Query.ToList();
             }
         }


         public List<CatTipoBloques> VerTipoBloques(string nombre)
         {
             using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
             {
                 var Query = from C in context.CatTipoBloques
                             where C.Descripcion.Contains(nombre)
                             select C;
                 return Query.ToList();
             }
         }
     
     }
}
