using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFLogicaEscenasPelis.Models;
using WCFLogicaEscenasPelis.Repositories;

namespace WCFLogicaEscenasPelis
{
    public class EscenaClass : IEscenasPelisContract
    {
        private RepositoryEscenaPelicula repo;

        public EscenaClass()
        {
            repo = new RepositoryEscenaPelicula();
        }

        public List<EscenaPeli> GetEscenaPelicula(int idpelicula)
        {
            return this.repo.GetEscenaPelicula(idpelicula);
        }

        public List<EscenaPeli> GetEscenas()
        {
            return this.repo.GetEscenas();
        }
    }
}
