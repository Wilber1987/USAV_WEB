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
    public class ValuesController : ApiController
    {
        
        public Object PostCreadoresVideos()
        {
            var Instance = new DataCreadorVideos();
            return Instance.MostrarCreadorVideos();
        }
        public Object PostTakeServicios()
        {
            BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes();
            var Query = from L in context.TblArticulos
                        select new { L.IdArticulo, L.TituloArticulo, L.ContenidoArticulo };
            return Query.ToList();
        }
    }
}
