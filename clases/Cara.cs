using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenTK;
using Newtonsoft.Json;

namespace Proyecto1
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Cara : IObjeto
    {

        [JsonProperty] public Punto origen;
        [JsonProperty] public Punto cm;
        [JsonProperty] public Dictionary<string, Punto> lista;
        [JsonProperty] public Color color;
        [JsonProperty] public PrimitiveType tipo;


        //-----------------------------------------------------------------------------------------------------------------
        public Cara()
        {
            this.lista = new Dictionary<string, Punto>();
            this.origen = new Punto();
            this.tipo = PrimitiveType.LineLoop;
            this.color = Color.Pink;
            this.cm = new Punto();
        }
        //-----------------------------------------------------------------------------------------------------------------

        public Cara(Punto origen, PrimitiveType tipo, Dictionary<string, Punto> puntos, Color c, Punto cm)
        {
            this.lista = puntos;
            this.origen = new Punto(origen);
            this.tipo = tipo;
            this.color = c;
            this.cm = new Punto(cm);
        }
        //-----------------------------------------------------------------------------------------------------------------

        public Cara(Cara cara)
        {
            this.origen = new Punto(cara.origen);
            this.cm = new Punto(cara.cm);
            this.tipo = cara.tipo;
            this.color = cara.color;
            this.lista = new Dictionary<string, Punto>();
            foreach (var puntos in cara.lista)
                Adicionar(puntos.Key, new Punto(puntos.Value));
        }

        public static void SerializeJsonFile(string path, Cara obj)
        {
            string textJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(path, textJson);
        }
        public static Cara DeserializeJsonFile(string json)
        {
            string textJson = new StreamReader(json).ReadToEnd();
            return JsonConvert.DeserializeObject<Cara>(textJson);
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
