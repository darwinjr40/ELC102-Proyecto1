using Proyecto1_01.src.Presentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto1_01.src.clases.Guion
{
    class ControladorAnimacion
    {
        Guion guion;
        Thread hilo;
        bool sw;
        public ControladorAnimacion()
        {
            //this.guion = new Guion(this.getEscena());
            this.guion = new Guion();
            this.guion.SetEscena(Escena.DeserializeJsonFile("escena.json"));
            hilo = new Thread(new ThreadStart(play));
            sw = true;
        }
        public void iniciarAnimacion(Object sender, EventArgs e)
        {
            if (sw)
            {
                hilo.Start();
            }
            else
            {
                sw = true;
            }
            
        }

        public void play()
        {
            int dur = 10000;
            int tiempoInicial = Environment.TickCount & Int32.MaxValue;
            int tiempo = Environment.TickCount & Int32.MaxValue;
            int tiempoFinal = tiempo + dur;
            int tiempoActual = 0;
            //int i = 0;
            Escena escena = this.guion.escenas.ElementAt(0);
            Accion accion = this.guion.escenas.ElementAt(0).acciones.ElementAt(0);
            //Accion.SerializeJsonFile("accion.json", accion);
            //Escena.SerializeJsonFile("escena.json", escena);

            do
            {
                //Console.WriteLine(tiempoActual);
                for (int i = 0; i < escena.getCantidad(); i++)
                {
                    tiempoActual = (Environment.TickCount & Int32.MaxValue) - tiempoInicial;
                    //Console.WriteLine(tiempoActual);
                    accion = escena.getAccion(i);
                    if (tiempoActual >= accion.tiempoI && tiempoActual <= accion.tiempoF)
                    {
                        reproducirAccion(accion, tiempoActual);
                    }
                }
                if (tiempoActual >= dur && sw)
                {
                    sw = false;
                    tiempoActual = 0;
                    tiempoInicial = Environment.TickCount & Int32.MaxValue;
                    for (int i = 0; i < escena.getCantidad(); i++)
                         escena.getAccion(i).tiempoSiguiente = escena.getAccion(i).tiempoI;
                }
                while (!sw)
                {
                }

            } while (tiempoActual <= dur);
        }

        public void reproducirEscena(Escena e)
        {
            
        }

        public void reproducirAccion(Accion a, int tiempoActual)
        {
            
                if (a.accion[0] == 1) //escalar
                {
                    escalar(a, a.parametros, tiempoActual);
                }
                if (a.accion[1] == 1)//rotar
                {
                    rotar(a, a.parametros, tiempoActual);
                }
                if (a.accion[2] == 1)//trasladar
                {
                    trasladar(a, a.parametros, tiempoActual);
                }
            //Formulario.escenario.Dibujar();
        }

        public string[] getObjetoParte(string cad)
        {
            string[] res = cad.Split('.');
            return res;
        }

        public void trasladar(Accion a, List<float> par, int tiempoActual)
        {
            float tiempo = a.tiempoF - a.tiempoI;
            float cada = tiempo / a.cuantas;
            //Console.WriteLine(cada);
            //if (tiempoActual % cada == 0 && tiempoActual >= a.tiempoSiguiente)
            if (tiempoActual >= a.tiempoSiguiente)
            {
                a.tiempoSiguiente += (long)cada;
                //Console.WriteLine(tiempoActual);
                if (a.tipoObjeto == 0)
                {
                    Formulario.escenario.Trasladar(par[0], par[1], par[2]);
                }
                else if (a.tipoObjeto == 1)
                {
                    Formulario.escenario.GetObjeto(a.nombreObjeto[0]).Trasladar(par[0], par[1], par[2]);
                }
                else if (a.tipoObjeto == 2)
                {
                    Formulario.escenario.GetObjeto(a.nombreObjeto[0]).GetCara(a.nombreObjeto[1]).Trasladar(par[0], par[1], par[2]);
                }
            }

        }

        public void rotar(Accion a, List<float> par, int tiempoActual)
        {
            float tiempo = a.tiempoF - a.tiempoI;
            float cada = tiempo / a.cuantas;
            //Console.WriteLine(cada);
            //if (tiempoActual % cada == 0 && tiempoActual >= a.tiempoSiguiente)
            if (tiempoActual >= a.tiempoSiguiente)
            {
                a.tiempoSiguiente += (long)cada;
                //Console.WriteLine(tiempoActual);
                if (a.tipoObjeto == 0)
                {
                    Formulario.escenario.Rotar(par[0], par[1], par[2]);
                }
                else if (a.tipoObjeto == 1)
                {
                    Formulario.escenario.GetObjeto(a.nombreObjeto[0]).Rotar(par[0], par[1], par[2]);
                }
                else if (a.tipoObjeto == 2)
                {
                    Formulario.escenario.GetObjeto(a.nombreObjeto[0]).GetCara(a.nombreObjeto[1]).Rotar(par[0], par[1], par[2]);
                }
            }
        }

        public void escalar(Accion a, List<float> par, int tiempoActual)
        {
            float tiempo = a.tiempoF - a.tiempoI;
            float cada = tiempo / 12;
            //Console.WriteLine(cada);
            //if (tiempoActual % cada == 0 && tiempoActual >= a.tiempoSiguiente)
            if (tiempoActual >= a.tiempoSiguiente)
            {
                a.tiempoSiguiente += (long)cada;
                //Console.WriteLine(tiempoActual);
                if (a.tipoObjeto == 0)
                {
                    Formulario.escenario.Escalar(par[0], par[1], par[2]);
                }
                else if (a.tipoObjeto == 1)
                {
                    Formulario.escenario.GetObjeto(a.nombreObjeto[0]).Escalar(par[0], par[1], par[2]);
                }
                else if (a.tipoObjeto == 2)
                {
                    Formulario.escenario.GetObjeto(a.nombreObjeto[0]).GetCara(a.nombreObjeto[1]).Escalar(par[0], par[1], par[2]);
                }
            }
        }

        public List<Escena> getEscena()
        {
            
            //Accion p = new Accion(new List<string>() { "brazoD12" }, new List<byte>() { 0, 1, 0}, new List<float>() { 0, -1, 0 }, 0, 500, 1, 12) ;
            
            Escena e = new Escena("moverse", new List<Accion>() 
            {
                new Accion(new List<string>() { "brazoD12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 0, 500, 1, 12),
                new Accion(new List<string>() { "brazoD12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 1000, 1500, 1, 12),
                new Accion(new List<string>() { "brazoD12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 2000, 2500, 1, 12),
                new Accion(new List<string>() { "brazoD12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 3000, 3500, 1, 12),
                new Accion(new List<string>() { "brazoD12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 4000, 4500, 1, 12),
                new Accion(new List<string>() { "brazoD12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 5000, 5500, 1, 12),
                new Accion(new List<string>() { "brazoD12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 6000, 6500, 1, 12),
                new Accion(new List<string>() { "brazoD12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 7000, 7500, 1, 12),
                new Accion(new List<string>() { "brazoD12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 500, 1000, 1, 12),
                new Accion(new List<string>() { "brazoD12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 1500, 2000, 1, 12),
                new Accion(new List<string>() { "brazoD12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 2500, 3000, 1, 12),
                new Accion(new List<string>() { "brazoD12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 3500, 4000, 1, 12),
                new Accion(new List<string>() { "brazoD12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 4500, 5000, 1, 12),
                new Accion(new List<string>() { "brazoD12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 5500, 6000, 1, 12),
                new Accion(new List<string>() { "brazoD12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 6500, 7000, 1, 12),
                new Accion(new List<string>() { "brazoD12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 7500, 8000, 1, 12),
                //---------
                new Accion(new List<string>() { "brazoI22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 0, 500, 1, 12),
                new Accion(new List<string>() { "brazoI22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 500, 1000, 1, 12),
                new Accion(new List<string>() { "brazoI22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 1000, 1500, 1, 12),
                new Accion(new List<string>() { "brazoI22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 1500, 2000, 1, 12),
                new Accion(new List<string>() { "brazoI22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 2000, 2500, 1, 12),
                new Accion(new List<string>() { "brazoI22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 2500, 3000, 1, 12),
                new Accion(new List<string>() { "brazoI22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 3000, 3500, 1, 12),
                new Accion(new List<string>() { "brazoI22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 3500, 4000, 1, 12),
                new Accion(new List<string>() { "brazoI22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 4000, 4500, 1, 12),
                new Accion(new List<string>() { "brazoI22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 4500, 5000, 1, 12),
                new Accion(new List<string>() { "brazoI22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 5000, 5500, 1, 12),
                new Accion(new List<string>() { "brazoI22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 5500, 6000, 1, 12),
                new Accion(new List<string>() { "brazoI22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 6000, 6500, 1, 12),
                new Accion(new List<string>() { "brazoI22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 6500, 7000, 1, 12),
                new Accion(new List<string>() { "brazoI22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 7000, 7500, 1, 12),
                new Accion(new List<string>() { "brazoI22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 7500, 8000, 1, 12),



                new Accion(new List<string>() { "escenario" }, new List<byte>() { 0, 0, 1 }, new List<float>() { 0.1f, 0, 0 }, 0, 8000, 0, 500),//escenario
                //new Accion(new List<string>() { "rotar" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1.5f, 0 }, 8000, 10000, 0, 30),//escenario

                //Accion p9 = new Accion(new List<string>() { "brazoI22" }, new List<byte>() { 0, 0, 0 }, new List<float>() { 0, 1, 0 }, 3501, 4000, 1);

                new Accion(new List<string>() { "brazoD22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 500, 1000, 1, 12),
                new Accion(new List<string>() { "brazoD22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 1000, 1500, 1, 12),
                new Accion(new List<string>() { "brazoD22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 1500, 2000, 1, 12),
                new Accion(new List<string>() { "brazoD22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 2000, 2500, 1, 12),
                new Accion(new List<string>() { "brazoD22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 2500, 3000, 1, 12),
                new Accion(new List<string>() { "brazoD22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 3000, 3500, 1, 12),
                new Accion(new List<string>() { "brazoD22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 3500, 4000, 1, 12),
                new Accion(new List<string>() { "brazoD22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 4000, 4500, 1, 12),
                new Accion(new List<string>() { "brazoD22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 4500, 5000, 1, 12),
                new Accion(new List<string>() { "brazoD22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 5000, 5500, 1, 12),
                new Accion(new List<string>() { "brazoD22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 5500, 6000, 1, 12),
                new Accion(new List<string>() { "brazoD22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 6000, 6500, 1, 12),
                new Accion(new List<string>() { "brazoD22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 6500, 7000, 1, 12),
                new Accion(new List<string>() { "brazoD22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 7000, 7500, 1, 12),
                //---
                new Accion(new List<string>() { "brazoI12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 500, 1000, 1, 12),
                new Accion(new List<string>() { "brazoI12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 1000, 1500, 1, 12),
                new Accion(new List<string>() { "brazoI12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 1500, 2000, 1, 12),
                new Accion(new List<string>() { "brazoI12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 2000, 2500, 1, 12),
                new Accion(new List<string>() { "brazoI12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 2500, 3000, 1, 12),
                new Accion(new List<string>() { "brazoI12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 3000, 3500, 1, 12),
                new Accion(new List<string>() { "brazoI12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 3500, 4000, 1, 12),
                new Accion(new List<string>() { "brazoI12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 4000, 4500, 1, 12),
                new Accion(new List<string>() { "brazoI12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 4500, 5000, 1, 12),
                new Accion(new List<string>() { "brazoI12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 5000, 5500, 1, 12),
                new Accion(new List<string>() { "brazoI12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 5500, 6000, 1, 12),
                new Accion(new List<string>() { "brazoI12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 6000, 6500, 1, 12),
                new Accion(new List<string>() { "brazoI12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 6500, 7000, 1, 12),
                new Accion(new List<string>() { "brazoI12" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 7000, 7500, 1, 12),

                new Accion(new List<string>() { "brazoD21" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 1, 1.5f, 0 }, 8000, 10000, 1, 10),
                new Accion(new List<string>() { "brazoD22" }, new List<byte>() { 0, 0, 1 }, new List<float>() { 0, 0, -0.2f }, 8000, 10000, 1, 16),
                new Accion(new List<string>() { "brazoD22" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1, 0 }, 8000, 10000, 1, 16),

                //new Accion(new List<string>() { "espalda" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 8000, 10000, 0, 16),
                //new Accion(new List<string>() { "espalda" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, -1, 0 }, 8000, 10000, 0, 16),
             });
            List<Escena> lista = new List<Escena>() { e};
            return lista;
        }
    }
}
