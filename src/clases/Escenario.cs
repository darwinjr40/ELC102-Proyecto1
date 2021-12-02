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

        #endregion
        public Escenario()
        {
            this.lista = new Dictionary<string, Objeto>();
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
            //this.AplicarTransformacion();
            foreach (var objetos in lista.Values) 
                objetos.Dibujar();
        }
        //-----------------------------------------------------------------------------------------------------------------
        public void Rotar(float x, float y, float z)
        {
            foreach (var objetos in lista.Values)
                objetos.RotarE(x, y, z);
        }
        //-----------------------------------------------------------------------------------------------------------------
        public void Trasladar(float x, float y, float z)
        {
            foreach (var objetos in lista.Values)
                objetos.Trasladar(x, y, z);
        }
        //-----------------------------------------------------------------------------------------------------------------
        public void Escalar(float x, float y, float z)
        {
            foreach (var objetos in lista.Values)
                objetos.Escalar(x, y, z);
        }
        //-----------------------------------------------------------------------------------------------------------------

    }
}
