using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using USAV_Solicitudes;
using USAV_Solicitudes.DatosSolicitudes;

namespace UI_USAV.Controllers
{
    public class AdminCatalogController : ApiController
    {
        #region Catalogos*************************************************************
        //LOCALIDADES
        public  Object PostTakeLocalidades()
        {
            List<Object> LocList = new List<Object>();
            var Localidad = new DataTblVideos();
            return Localidad.InicializarLocalidad();
        }
        public Object PostTakeLocalidad(object data)
        {
            CatLocalidades Jloc = JsonConvert.DeserializeObject<CatLocalidades>(data.ToString());
            List<Object> LocList = new List<Object>();
            var Localidad = new DataTblVideos();
            return Localidad.TakeLocalidad(Jloc.IdLocalidad);
        }
        public Object PostTakeLocalidadesFilt(string Param)
        {
            List<Object> LocList = new List<Object>();
            var Localidad = new DataTblVideos();
            return Localidad.InicializarLocalidadFil(Param); 
        }
        public  Object PostGuardarLocalidades(object data)
        {
            try
            {
                CatLocalidades Jloc = JsonConvert.DeserializeObject<CatLocalidades>(data.ToString());
                var Localidad = new DataTblVideos();
                if (Jloc.IdLocalidad == 0)
                {
                    return Localidad.GuardarLocalidad(Jloc);
                }
                else
                {
                    return Localidad.ActualizaLocalidades(Jloc);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //EDIFICIOS
        public Object PostTakeEdificios()
        {
            List<Object> LocList = new List<Object>();
            var Edificio = new DataCatEdificio();
            return Edificio.InicializarEdificios();
        }
        public Object PostGuardarEdificios(object data)
        {
            try
            {
                CatEdificios Jloc = JsonConvert.DeserializeObject<CatEdificios>(data.ToString());
                var Edificio = new DataCatEdificio();
                if (Jloc.IdEdificio == 0)
                {
                    return Edificio.GuardarEdificio(Jloc);
                }
                else
                {
                    return Edificio.ActualizaEdificios(Jloc);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //BLOQUES
        public Object PostTakeBloques()
        {
            List<Object> LocList = new List<Object>();
            var Localidad = new DataCatTipoBloques();
            return Localidad.InicializarTiposBloques();
        }
        public Object PostGuardarBloques(object data)
        {
            try
            {
                CatTipoBloques Jloc = JsonConvert.DeserializeObject<CatTipoBloques>(data.ToString());
                var TipoBloque = new DataCatTipoBloques();
                if (Jloc.IdTipoBloque == 0)
                {
                    return TipoBloque.GuardarTipoBloque(Jloc);
                }
                else
                {
                    return TipoBloque.ActualizaTipoBloques(Jloc);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //RESERVAS 
        public Object PostTakeReservas()
        {
            List<Object> LocList = new List<Object>();
            var Localidad = new DataTipoReserva();
            return Localidad.InicializarTipoR();
        }
        public Object PostGuardarReservas(object data)
        {
            try
            {
                CatTipoReserva Jloc = JsonConvert.DeserializeObject<CatTipoReserva>(data.ToString());
                var Reserva = new DataTipoReserva();
                if (Jloc.IdTipoReserva == 0)
                {
                    return Reserva.GuardarTipoReserva(Jloc);
                }
                else
                {
                    return Reserva.ActualizaTipoReserva(Jloc);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //CREADOR VIDEOS
        public Object PostTakeCreador()
        {
            List<Object> LocList = new List<Object>();
            var inst = new DataCreadorVideos();
            return inst.InizializarCreador();
        }
        public Object PostCreadoresVideosSave(object data)
        {
            try
            {
                TblCreadorVideos Jloc = JsonConvert.DeserializeObject<TblCreadorVideos>(data.ToString());
                var Creador = new DataCreadorVideos();
                if (Jloc.IdCreadorVideo == 0)
                {
                    return Creador.GuardarCreador(Jloc);
                }
                else
                {
                    return Creador.ActualizaCreador(Jloc);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }

}
