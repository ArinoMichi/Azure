using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLogicaPrimerServicio
{
    internal class MetodosVariosClass : IMetodosVariosContract
    {
        public int GetNumeroDoble(int numero)
        {
            return numero * 2;
        }

        public string GetSaludo(string nombre)
        {
            return "Mi primer WCF, Bienvenido " + nombre;
        }

        public List<int> GetTablaMultiplicar(int numero)
        {
            List<int> tabla = new List<int>();
            for(int i = 1; i <= 10; i++) 
            {
                int resultado = numero * i;
                tabla.Add(resultado);
            }
            return tabla;

        }

        public string MetodoInvisible()
        {
            return "No sirvo para nada...";
        }
    }
}
