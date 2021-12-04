using Newtonsoft.Json;
using Proyecto1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_01.src.clases.Guion
{
    [JsonObject(MemberSerialization.OptIn)]
    class Accion
    {
        [JsonProperty] public List<string> nombreObjeto;
        [JsonProperty] public byte tipoObjeto;  //escenario = 0, objeto = 1, cara = 2
        [JsonProperty] public long tiempoI;
        [JsonProperty] public long tiempoF;
        [JsonProperty] public long tiempoSiguiente;
        [JsonProperty] public List<byte> accion;  //escalara = 1, rotar = 1, trasladar = 1
        [JsonProperty] public List<float> parametros;
        [JsonProperty] public long cuantas;

        public Accion() : this(null, null, null, 0, 0, 0, 0) { }

        public Accion(List<string> objeto, List<byte> accion, List<float> parametros, long tiempoI, long tiempoF, byte tipoObjeto, long cuantas)
        {
            this.nombreObjeto = objeto;
            this.accion = accion;
            this.parametros = parametros;
            this.tiempoI = this.tiempoSiguiente = tiempoI;
            this.tiempoF = tiempoF;
            this.tipoObjeto = tipoObjeto;
            this.cuantas = cuantas;
        }

        public static void SerializeJsonFile(string path, Accion obj)
        {
            string textJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(path, textJson);
        }
        public static Accion DeserializeJsonFile(string json)
        {
            string textJson = new StreamReader(json).ReadToEnd();
            return JsonConvert.DeserializeObject<Accion>(textJson);
        }

    }
}
