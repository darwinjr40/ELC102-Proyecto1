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
        public Punto rotacion;
        public Punto escalacion;
        #endregion
        public Escenario()
        {
            this.lista = new Dictionary<string, Objeto>();
            this.origen = new Punto();
            this.rotacion = new Punto();
            this.escalacion = new Punto(1, 1, 1);
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
            this.AplicarTransformacion();
            foreach (var objetos in lista.Values) 
                objetos.Dibujar();
        }
        //-----------------------------------------------------------------------------------------------------------------
        public void Rotar(float x, float y, float z)
        {
            rotacion.x = rotacion.x % 360 + x;
            rotacion.y = rotacion.y % 360 + y;
            rotacion.z = rotacion.z % 360 + z;

        }
        //-----------------------------------------------------------------------------------------------------------------
        public void Trasladar(float x, float y, float z)
        {
            this.origen.acumular(x, y, z);
        }
        //-----------------------------------------------------------------------------------------------------------------
        public void Escalar(float x, float y, float z)
        {
            if (x <= 0) x = 1;
            if (y <= 0) y = 1;
            if (z <= 0) z = 1;
            this.escalacion.multiplicar(x, y, z);
        }

        private void AplicarTransformacion()
        {
            GL.Translate(origen.x, origen.y, origen.z);
            GL.Scale(escalacion.x, escalacion.y, escalacion.z);
            GL.Rotate(rotacion.x, 1, 0, 0); GL.Rotate(rotacion.y, 0, 1, 0); GL.Rotate(rotacion.z, 0, 0, 1);
        }
    }
}
