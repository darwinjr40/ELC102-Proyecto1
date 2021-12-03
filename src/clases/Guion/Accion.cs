using Proyecto1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_01.src.clases.Guion
{
    class Accion
    {
        public string nombreObjeto;
        public long tiempoI;
        public long tiempoF;
        public long tiempoSiguiente;
        public bool estado;
        public List<byte> accion;  //escalara = 0, rotar = 1, trasladar = 2
        public List<float> parametros;

        public enum Transformacion { R = 0, T = 1, E = 2 }
        public Accion()
        {
            this.nombreObjeto = "";
            this.accion = null;
            this.parametros = null;
            this.tiempoI = 0;
            this.tiempoF = 0;
            this.estado = true;
            this.tiempoSiguiente = 0;

        }
        public Accion(string objeto, List<byte> accion, List<float> parametros, long tiempoI, long tiempoF, bool estado)
        {
            this.nombreObjeto = objeto;
            this.accion = accion;
            this.parametros = parametros;
            this.tiempoI = this.tiempoSiguiente = tiempoI;
            this.tiempoF = tiempoF;
            this.estado = estado;
        }
    }
}
