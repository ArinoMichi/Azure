using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WCFLogicaEscenasPelis.Models;

namespace WCFLogicaEscenasPelis.Repositories
{
    public class RepositoryEscenaPelicula
    {
        private XDocument document;

        public RepositoryEscenaPelicula()
        {
            string resourceName = "WCFLogicaEscenasPelis.escenaspeliculas.xml";
            Stream stream = this.GetType().Assembly.GetManifestResourceStream(resourceName);
            this.document = XDocument.Load(stream);
        }

        public List<EscenaPeli> GetEscenas()
        {
            var consulta = from datos in this.document.Descendants("escena")
                           select new EscenaPeli()
                           {
                               IdPelicula = int.Parse(datos.Attribute("idpelicula").Value),
                               TituloEscena = datos.Element("tituloescena").Value,
                               Descripcion = datos.Element("descripcion").Value,
                               Imagen = datos.Element("imagen").Value
                           };
            return consulta.ToList();
        }


        public List<EscenaPeli> GetEscenaPelicula(int idpelicula)
        {
            var consulta = from datos in this.document.Descendants("escena")
                           where datos.Attribute("idpelicula").Value == idpelicula.ToString()
                           select new EscenaPeli()
                           {
                               IdPelicula = int.Parse(datos.Attribute("idpelicula").Value),
                               TituloEscena = datos.Element("tituloescena").Value,
                               Descripcion = datos.Element("descripcion").Value,
                               Imagen = datos.Element("imagen").Value
                           };
            return consulta.ToList();
        }

    }
}
