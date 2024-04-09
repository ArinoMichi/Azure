using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFLogicaEscenasPelis.Models;

namespace WCFLogicaEscenasPelis
{
    [ServiceContract]
    public interface IEscenasPelisContract
    {
        [OperationContract]
        List<EscenaPeli> GetEscenas();
        [OperationContract]
        List<EscenaPeli> GetEscenaPelicula(int idpelicula);
    }
}
