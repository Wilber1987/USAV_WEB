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
    public class AdminVideoController : ApiController
    {        
        public Object PostTakeVideos()
        {
            List<Object> LocList = new List<Object>();
            var videos = new DataTblVideo();
            return videos.InicializarVideos();
        }
        public Object PostTakeVideosPV()
        {            
            var videos = new DataTblVideo();
            return videos.InicializarVideosPV();
        }
        public Object PostTakeVideosSlideIndex()
        {
            var videos = new DataTblVideo();
            return videos.InicializarVideosSlideIndex();
        }
        public Object PostGuardarVideos(object data)
        {
            try
            {
                List<TblVideos> Jloc = JsonConvert.DeserializeObject<List<TblVideos>>(data.ToString());
                var DataVideos = new DataTblVideo();
                return DataVideos.GuardarVideos(Jloc);               
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
