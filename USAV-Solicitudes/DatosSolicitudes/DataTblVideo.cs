using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAV_Solicitudes.DatosSolicitudes
{
    public class DataTblVideo
    {
        public Object InicializarVideos()
        {
            BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes();
            var Query = from L in context.TblVideos
                        select new { L.Id, L.Descripcion, L.Photo, L.NombreVideo, L.IdYoutube, L.FechaSubida };
            return Query.ToList();
        }
        public Object InicializarVideosPV()
        {
            BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes();
            var Query = from L in context.TblVideos
                        select new { Id_hidden = L.Id, 
                            Desc_hidden = L.Descripcion, 
                            //Photo_hidden = L.Photo, 
                            L.NombreVideo,
                            IdYoutube_hidden = L.IdYoutube,
                            Fecha_hidden = L.FechaSubida,
                            L.Photo
                        };
            return Query.ToList();
        }
        public Object InicializarVideosSlideIndex()
        {
            BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes();
            var Query = (from L in context.TblVideos
                        select new
                        {
                           // Id_hidden = L.Id,
                            //Desc_hidden = L.Descripcion,
                            title = L.NombreVideo,
                            url = "https://www.youtube.com/embed/" + L.IdYoutube,
                            //Fecha_hidden = L.FechaSubida,
                            image = L.Photo
                        }).Take(5);
            return Query.ToList();
        }
        public Object GuardarVideos(List<TblVideos> List)
        {
            try
            {
                BDVideosUSAVEntitiesModelSolicitudes Model = new BDVideosUSAVEntitiesModelSolicitudes();
                foreach (var item in List)
                {
                    TblVideos Video = Model.TblVideos.FirstOrDefault(v => v.IdYoutube == item.IdYoutube);                    
                    if (Video == null) {
                        Model.TblVideos.Add(item);
                        Model.SaveChanges();
                    } else {
                        Video.NombreVideo = item.NombreVideo;
                        Video.Descripcion = item.Descripcion;
                        Video.Photo = item.Photo;
                        //agregar numero de visitas;
                        Model.SaveChanges();
                    }
                   
                }
                return "Videos Guardados Correctamente";   
            }
            catch(Exception ex)
            {
                return ex;
            }
        }
    }
}
