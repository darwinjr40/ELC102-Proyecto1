using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    public class Escenario: IObjeto 
    {
        #region Atributos
        public Dictionary<string, Objeto> lista;
        public Punto origen;
        #endregion
        public Escenario()
        {
            lista = new Dictionary<string, Objeto>();
            origen = new Punto();
        }
        //-----------------------------------------------------------------------------------------------------------------

        public Objeto GetObjeto(string name)
        {
            return (lista.ContainsKey(name)) ? lista[name] : null;
        }
        //-----------------------------------------------------------------------------------------------------------------

        public void SetObjeto(string name,Objeto x)
        {
            if (lista.ContainsKey(name)) { lista.Remove(name); }
            lista.Add(name, x);
        }
        //-----------------------------------------------------------------------------------------------------------------

        public void Dibujar()
        {
            foreach (var objetos in lista.Values) {
                objetos.Dibujar();
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

      

    }
}
