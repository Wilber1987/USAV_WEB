using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;


namespace USAV_Solicitudes.DatosSolicitudes
{
    public class DataConfiguracionLaboral:TblConfiguracionLaboral
    {

        public bool GuardarConfiguracionLaboral(TblConfiguracionLaboral Obj)
        {
            try
            {
                using (BDVideosUSAVEntitiesModelSolicitudes Model = new BDVideosUSAVEntitiesModelSolicitudes())
                {                
                Model.TblConfiguracionLaboral.Add(Obj);
                Model.SaveChanges();
                return true;
                }
            }
            catch
            {
                return false;
            }
        }


        public bool ActualizaConfiguracionLaboral(TblConfiguracionLaboral obj)
        {
            try
            {
                using (BDVideosUSAVEntitiesModelSolicitudes Model = new BDVideosUSAVEntitiesModelSolicitudes())
                {
                var objeto = Model.TblConfiguracionLaboral.FirstOrDefault(c => c.IdConfigLababoral == obj.IdConfigLababoral);
                objeto.IdConfigLababoral = obj.IdConfigLababoral;
                objeto.HorasLaborales = obj.HorasLaborales;
                objeto.DiaInicial= obj.DiaInicial;
                objeto.DiaFinal = obj.DiaFinal;
                objeto.DiasLaborales= obj.DiasLaborales;
                objeto.HorasAlmuerzo= obj.HorasAlmuerzo;
                objeto.HoraInicialLaboral= obj.HoraInicialLaboral;
                objeto.HoraFinalLaboral= obj.HoraFinalLaboral;
                Model.SaveChanges();
                return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<TblConfiguracionLaboral> InicializarConfiguracionLaboral()
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                var Query = from L in context.TblConfiguracionLaboral
                            select L;
                return Query.ToList();
            }

        }


        public List<TblConfiguracionLaboral> VerConfiguracionLaboral(int ID)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                var Query = from C in context.TblConfiguracionLaboral
                            where C.IdConfigLababoral == ID
                            select C;
                return Query.ToList();
            }
        }



    }
}
