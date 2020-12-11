using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace USAV_Solicitudes.DatosSolicitudes
{
    public class DataTblVideos:CatLocalidades
    {
       
        public Object InicializarLocalidad()
        {              
            BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes();  
            var Query = from L in context.CatLocalidades                            
                            select new {
                                L.IdLocalidad,
                                L.DescLocalidades,
                                L.IdTipoBloque,
                                L.IdConfigLaboral,
                                L.IdEdificio,
                                L.Pict
                            } ;
            return Query.ToList();  
        }
        public Object TakeLocalidad(int IdLocalidad)
        {
            BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes();
            var Query = (from L in context.CatLocalidades
                         where L.IdLocalidad == IdLocalidad
                            select new
                            {
                                IdLocalidad_hidden = L.IdLocalidad,
                                L.DescLocalidades,
                                IdTipoBloque_hidden = L.IdTipoBloque,
                                IdConfigLaboral__hidden = L.IdConfigLaboral,
                                IdEdificio_hidden = L.IdEdificio,
                                L.Pict
                            }).Take(1);
            return Query;
        }
        public Object InicializarLocalidadFil(string Param)
        {
            BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes();
            var Query = from L in context.CatLocalidades
                        where L.DescLocalidades.Contains(Param)
                        select new
                        {
                            L.IdLocalidad,
                            L.DescLocalidades,
                            L.IdTipoBloque,
                            L.IdConfigLaboral,
                            L.IdEdificio,
                            L.Pict
                        };
            return Query.ToList();
        }


        public Object GuardarLocalidad(CatLocalidades Obj)
        {
            try
            {
                BDVideosUSAVEntitiesModelSolicitudes Model = new BDVideosUSAVEntitiesModelSolicitudes();
                Model.CatLocalidades.Add(Obj);
                Model.SaveChanges();
                return "Guardado Correctamente";                
            }
            catch(Exception ex)
            {
                return ex;
            }
        }
        public Object ActualizaLocalidades(CatLocalidades obj)
        {
            try
            {
                BDVideosUSAVEntitiesModelSolicitudes Model = new BDVideosUSAVEntitiesModelSolicitudes();
               
                        var objeto = Model.CatLocalidades.FirstOrDefault(c => c.IdLocalidad == obj.IdLocalidad);
                        objeto.IdEdificio = obj.IdEdificio;
                        objeto.DescLocalidades = obj.DescLocalidades;
                        objeto.IdLocalidad = obj.IdLocalidad;
                        objeto.IdConfigLaboral = obj.IdConfigLaboral;
                        objeto.IdTipoBloque = obj.IdTipoBloque;
                        if (obj.Pict != null)
                        {
                            objeto.Pict = obj.Pict;
                        }
                        Model.SaveChanges();
                        return "Actualizado Correctamente";
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

    


       public class ListaLocalidad
        {
            public int IdLocalidad { get; set; }
            public string DescLocalidades { get; set; }
            public int? IdEdificio  { get; set; }
            public int? IdTipoBloque { get; set; }
            public int? IdConfiguracion { get; set; }
            public byte[]  Pict { get; set; }
            public string DescEdificio { get; set; }
            //public int? IdEdificioE { get; set; }
            
        }         
        // para cargar el edificio de la licalidad para la Grid
          //public List<ListaLocalidad> CargarLocalidad(int IDEdificioL, int IDLocalidad)
       
        
        
        public List<ListaLocalidad> CargarLocalidad()
        {
            BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes();
              var resultado = from L in context.CatLocalidades
                      join E in context.CatEdificios on  L.IdEdificio equals E.IdEdificio
                      //where (L.IdEdificio== IDEdificioL) && (L.IdLocalidad == IDLocalidad)
                      select new {      
                            L.IdLocalidad, 
                            L.DescLocalidades,
                            L.IdEdificio,
                            L.IdTipoBloque,
                            L.IdConfigLaboral,
                            L.Pict,
                            //E.IdEdificio,
                            E.DescEdificios};


              List<ListaLocalidad> Localidadesparagrid = new List<ListaLocalidad>();
            foreach (var match in resultado)
            {

                ListaLocalidad lpg = new ListaLocalidad();
                lpg.IdLocalidad = match.IdLocalidad;
                lpg.DescLocalidades = match.DescLocalidades;
                lpg.IdEdificio = match.IdEdificio;
                lpg.IdTipoBloque = match.IdTipoBloque;
                lpg.DescEdificio = match.DescEdificios;
                lpg.IdEdificio = match.IdEdificio;
                //lpg.Pict = match.Pict;

               // lpg.Nombre_Edificio = match.DescEdificios;
               
                Localidadesparagrid.Add(lpg);
            }
            return Localidadesparagrid.ToList();
        }

        public List<ListaLocalidad> CargarLocalidad(int IDLocalidad)
        {
            BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes();
            var resultado = from L in context.CatLocalidades
                            join E in context.CatEdificios on L.IdEdificio equals E.IdEdificio
                            where (L.IdLocalidad == IDLocalidad)
                            select new
                            {
                                L.IdLocalidad,
                                L.DescLocalidades,
                                L.IdEdificio,
                                L.IdTipoBloque,
                                L.IdConfigLaboral,
                                L.Pict,
                                //E.IdEdificio,
                                E.DescEdificios
                            };


            List<ListaLocalidad> Localidadesparagrid = new List<ListaLocalidad>();
            foreach (var match in resultado)
            {

                ListaLocalidad lpg = new ListaLocalidad();
                lpg.IdLocalidad = match.IdLocalidad;
                lpg.DescLocalidades = match.DescLocalidades;
                lpg.IdEdificio = match.IdEdificio;
                lpg.IdTipoBloque = match.IdTipoBloque;
                lpg.DescEdificio = match.DescEdificios;
                lpg.IdConfiguracion = match.IdConfigLaboral;
                lpg.IdEdificio = match.IdEdificio;
               // lpg.Pict = match.Pict;

                // lpg.Nombre_Edificio = match.DescEdificios;

                Localidadesparagrid.Add(lpg);
            }
            return Localidadesparagrid.ToList();
        }
        public string MostrarResp(string Localidad)
        {
            using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
            {
                var resultado = from L in context.CatLocalidades
                                where L.DescLocalidades == Localidad
                                select L;
                                //{ responsable = L.Responsable };
                string ResponsableN = "";
                foreach (var match in resultado)
                {
                    //ResponsableN = match.responsable;
                }
                return ResponsableN;
            }

        }



        public byte[] MostrarFoto(int id)
        {      
                using (BDVideosUSAVEntitiesModelSolicitudes context = new BDVideosUSAVEntitiesModelSolicitudes())
                {
                    var Query = from L in context.CatLocalidades
                                where L.IdLocalidad == id
                                select new { Pict = L.Pict};
                    byte[] Imagen = null;
                    foreach (var Row in Query)
                    {
                       // Imagen = Row.Pict;                        
                    }
                    return Imagen;  
                }    
        }

    }
}
