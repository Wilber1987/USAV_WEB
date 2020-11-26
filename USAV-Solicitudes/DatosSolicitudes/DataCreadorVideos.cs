namespace USAV_Solicitudes.DatosSolicitudes
{
    using System;
    using System.Linq;

    public class DataCreadorVideos : TblCreadorVideos
    {
        public bool GuardarCreador(TblCreadorVideos Creador)
        {
            try
            {
                BDVideosUSAVEntitiesModelSolicitudes Model = new BDVideosUSAVEntitiesModelSolicitudes();
                Model.TblCreadorVideos.Add(Creador);
                Model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Object ActualizaCreador(TblCreadorVideos obj)
        {
            try
            {
                BDVideosUSAVEntitiesModelSolicitudes Model = new BDVideosUSAVEntitiesModelSolicitudes();
                var objeto = Model.TblCreadorVideos.FirstOrDefault(c => c.IdCreadorVideo == obj.IdCreadorVideo);
                objeto.Cedula = obj.Cedula;
                objeto.RutaImagenDocente = obj.RutaImagenDocente;
                objeto.Nombres = obj.Nombres;
                objeto.Apellido1 = obj.Apellido1;
                objeto.Apellido2 = obj.Apellido2;
                objeto.Espcialidad = obj.Espcialidad;
                Model.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return ex;
            }
        }
        public Object InizializarCreador()
        {
            BDVideosUSAVEntitiesModelSolicitudes Model = new BDVideosUSAVEntitiesModelSolicitudes();
            var Query = from c in Model.TblCreadorVideos
                        select new
                        {
                            c.RutaImagenDocente,
                            c.Nombres,
                            c.Apellido1,
                            c.Espcialidad,
                            c.Informacion,
                            c.IdCreadorVideo
                        };
            return Query.ToList();
        } 
        public Object MostrarCreadorVideos()
        {
            BDVideosUSAVEntitiesModelSolicitudes Model = new BDVideosUSAVEntitiesModelSolicitudes();
            var Query = from c in Model.TblCreadorVideos
                        select new
                        {
                            Photo = c.RutaImagenDocente,
                            c.Nombres,
                            c.Apellido1,
                            c.Espcialidad,
                            c.Email,
                            c.Informacion,
                            Id_hidden = c.IdCreadorVideo
                        };
            return Query.ToList();
        }
    }
}
