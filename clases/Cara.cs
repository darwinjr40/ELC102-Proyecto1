using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenTK;

namespace Proyecto1
{
    public class Cara : IObjeto
    {

        public Punto origen ;
         public Punto cm;
        public Punto rotacion;
        public Punto escalacion;
        public Dictionary<string, Punto> lista;
        public Color color;
        public PrimitiveType tipo;
        
        
       //-----------------------------------------------------------------------------------------------------------------
        public Cara(Punto origen, PrimitiveType tipo, Dictionary<string, Punto> puntos, Color c, Punto cm)
        {
            this.lista = puntos;
            this.origen = new Punto(origen);
            this.tipo = tipo;
            this.color = c;
            this.cm = new Punto(cm);
            this.rotacion = new Punto();
            this.escalacion = new Punto(1, 1, 1);
        }
        //-----------------------------------------------------------------------------------------------------------------

        public Cara(Cara cara)
        {
            this.origen = new Punto(cara.origen);
            this.cm = new Punto(cara.cm);
            this.tipo = cara.tipo;
            this.color = cara.color;
            this.rotacion = new Punto();
            this.escalacion = new Punto(1, 1, 1);
            this.lista = new Dictionary<string, Punto>();
            foreach (var puntos in cara.lista)
                Adicionar(puntos.Key, new Punto(puntos.Value));
        }
        //--------------------------------------------------------------------------------------------------------------------

        public void Adicionar(string name, Punto x)
        {
            if (lista.ContainsKey(name)) { 
                lista.Remove(name); 
            }
            lista.Add(name, x);
        }
        
        //--------------------------------------------------------------------------------------------------------------------
        public Punto Get(string name)
        {
            return (lista.ContainsKey(name)) ? lista[name] : null;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public void Dibujar()
        {
            GL.PushMatrix();
            GL.Begin(tipo); //tipo de figura
                GL.Color4(color); //color de la cara
                foreach (var vertice in lista.Values) //dibujar los vertices
                    GL.Vertex3((this.origen.x + vertice.x), (this.origen.y + vertice.y), (this.origen.z + vertice.z));
                GL.End();
            GL.PopMatrix();
        }
        //--------------------------------------------------------------------------------------------------------------------
       

    }

}
