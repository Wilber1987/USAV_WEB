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
    public class ReservasController : ApiController
    {
        public Object PostTakeBloques(object data)
        {
            TblCalendario Jloc = JsonConvert.DeserializeObject<TblCalendario>(data.ToString());
            var Calendario = new DataCalendario();
            DateTime dateTime1 = Convert.ToDateTime(Jloc.FechaCalendario);
            DateTime dateTime2 = Convert.ToDateTime(Jloc.FechaCalendario).AddDays(1);
            return Calendario.InicializarCalendario(dateTime1, dateTime2, Convert.ToInt32(Jloc.IdLocalidad));
        }
    }
}
