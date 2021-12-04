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
        [JsonProperty] public Punto rotacionCm;
        [JsonProperty] public Punto rotacionO;
        [JsonProperty] public Punto rotacionE;
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
            this.rotacionCm = new Punto();
            this.rotacionO = new Punto();
            this.rotacionE = new Punto();
        }
        //-----------------------------------------------------------------------------------------------------------------

        public Cara(Punto origen, PrimitiveType tipo, Dictionary<string, Punto> puntos, Color c, Punto cm)
        {
            this.lista = puntos;
            this.origen = new Punto(origen);
            this.tipo = tipo;
            this.color = c;
            this.cm = new Punto(cm);
            this.rotacionCm = new Punto();
            this.rotacionO = new Punto();
            this.rotacionE = new Punto();
        }
        //-----------------------------------------------------------------------------------------------------------------
        public Cara(Cara cara)
        {
            this.origen = new Punto(cara.origen);
            this.cm = new Punto(cara.cm);
            this.tipo = cara.tipo;
            this.color = cara.color;
            this.lista = new Dictionary<string, Punto>();
            this.rotacionCm = new Punto();
            this.rotacionO = new Punto();
            this.rotacionE = new Punto();
            foreach (var puntos in cara.lista)
                Adicionar(puntos.Key, new Punto(puntos.Value));
        }
        //-----------------------------------------------------------------------------------------------------------------
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
                this.AplicarTransformacion();
                GL.Begin(tipo); //tipo de figura
                GL.Color4(color); //color de la cara
                foreach (var vertice in lista.Values)
                    GL.Vertex3((vertice.x), (vertice.y), (vertice.z));
                GL.End();
            GL.PopMatrix();
        }
        //--------------------------------------------------------------------------------------------------------------------
        public void Rotar(float x, float y, float z)
        {
            rotacionCm.acumular(x, y, z); 
        }
        
        //--------------------------------------------------------------------------------------------------------------------
        public void Escalar(float x, float y, float z)
        {
            if (x <= 0) x = 1;
            if (y <= 0) y = 1;
            if (z <= 0) z = 1;
            this.cm.multiplicar(x, y, z);
            foreach (var vertice in lista.Values)
                vertice.multiplicar(x, y, z);
        }
        //--------------------------------------------------------------------------------------------------------------------
        public void Trasladar(float x, float y, float z)
        {
            origen.acumular(x, y, z); 
        }
        //--------------------------------------------------------------------------------------------------------------------
        public void RotarO(float x, float y, float z)
        {
            rotacionO.acumular(x, y, z);
        }
        public void RotarE(float x, float y, float z)
        {
            rotacionE.acumular(x, y, z);
        }





        private void AplicarTransformacion()
        {
            this.rotar(new Punto(), rotacionE );
            this.rotar(origen, rotacionO);
            this.rotar(cm, rotacionCm);
            GL.Translate(-cm.x, -cm.y, -cm.z);
        }
        private void rotar(Punto ori, Punto rot)
        {
            GL.Translate(ori.x, ori.y, ori.z);
            GL.Rotate(rot.x, 1, 0, 0);
            GL.Rotate(rot.y, 0, 1, 0);
            GL.Rotate(rot.z, 0, 0, 1);
        }
    }

}
