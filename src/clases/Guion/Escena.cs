using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_01.src.clases.Guion
{
    class Escena
    {
        string nombre { get; set; }
        public List<Accion> acciones { get; set; }
        long tiempoDeDuracion;
        public Escena()
        {
            acciones = new List<Accion>();
            tiempoDeDuracion = 0;
            nombre = "";
        }
        public Escena(string nombre, List<Accion> lista)
        {
            this.nombre = nombre;
            acciones = lista;
            tiempoDeDuracion = 0;
            for (int i = 0; i < lista.Count; i++)
                tiempoDeDuracion += (lista.ElementAt(i).tiempoF - lista.ElementAt(i).tiempoI + 1);
        }

        public Accion getAccion(int i)
        {
            return acciones.ElementAt(i);
        }
        public int getCantidad()
        {
            return acciones.Count;
        }

    }
}