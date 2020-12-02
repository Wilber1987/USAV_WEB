namespace USAV_Solicitudes.DatosSolicitudes
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class DataCatEdificio : CatEdificios
    {
        public Object GuardarEdificio(CatEdificios Obj)
        {
            try
            {
                BDVideosUSAVEntitiesModelSolicitudes Model = new BDVideosUSAVEntitiesModelSolicitudes();
                var querybusca = from c in Model.CatEdificios
                                 where c.DescEdificios == Obj.DescEdificios
                                 select c;
                if (querybusca.ToList().Count == 0)
                {
                    Model.CatEdificios.Add(Obj);
                    Model.SaveChanges();
                    return true;
                }
                else
                {
                    return "Descripcion repetida";
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public Object ActualizaEdificios(CatEdificios obj)
        {
            try
            {
                BDVideosUSAVEntitiesModelSolicitudes Model = new BDVideosUSAVEntitiesModelSolicitudes();
                var querybusca = from c in Model.CatEdificios
                                 where c.DescEdificios == obj.DescEdificios && c.IdEdificio != obj.IdEdificio
                                 select c;
                if (querybusca.ToList().Count == 0)
                {
                    var objeto = Model.CatEdificios.FirstOrDefault(c => c.IdEdificio == obj.IdEdificio);
                    objeto.IdEdificio = obj.IdEdificio;
                    objeto.DescEdificios = obj.DescEdificios;
                    objeto.Ubicacion = obj.Ubicacion;
                    objeto.Photo = obj.Photo;
                    Model.SaveChanges();
                    return true;
                }
                else
                {
                    return "Descripcion repetida";
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
        public Object InicializarEdificios()
        {
            BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes();

            var Query = from L in context.CatEdificios
                        select new { L.IdEdificio, L.DescEdificios, L.Photo, L.Ubicacion };
            return Query.ToList();
        }
        public List<CatEdificios> VerEdificios(int ID)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                var Query = from C in context.CatEdificios
                            where C.IdEdificio == ID
                            select C;
                return Query.ToList();
            }
        }

        public List<CatEdificios> VerEdificios(string nombre)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                var Query = from C in context.CatEdificios
                            where C.DescEdificios.Contains(nombre)
                            select C;
                return Query.ToList();
            }
        }
    }
}
