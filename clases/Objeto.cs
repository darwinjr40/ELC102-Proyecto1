using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    public class Objeto : IObjeto
    {
        public Punto origen;
        public float ancho;
        public float alto;
        public float profundidad;
        public Dictionary<string, Cara> lista;

        //--------------------------------------------------------------------------------------------------------------------
        public Objeto(Punto origen, float ancho, float alto, float profundidad,  Dictionary<string, Cara> caras) {
            this.origen = origen;
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;
            this.lista = caras;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public Objeto(Objeto objeto)
        {
            this.origen = new Punto(objeto.origen);
            this.ancho = objeto.ancho;
            this.alto = objeto.alto;
            this.profundidad = objeto.profundidad;
            this.lista = new Dictionary<string, Cara>();
            foreach (var caras in objeto.lista)
                this.Adicionar(caras.Key, new Cara(caras.Value));
        }
        //--------------------------------------------------------------------------------------------------------------------
        public void Adicionar(string name, Cara x)
        {
            if (lista.ContainsKey(name)) { 
                lista.Remove(name); 
            }
            x.origen.acumular(origen);
            lista.Add(name, x);
        }

        public Cara GetCara(string name)
        {
            return (lista.ContainsKey(name)) ? lista[name] : null;
        }
        //-----------------------------------------------------------------------------------------------------------------
        public void Dibujar()
        {
            foreach (var caras in lista.Values) 
                caras.Dibujar();
        }
     

        

       

    }
}
