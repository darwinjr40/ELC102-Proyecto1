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

        public ControladorAnimacion()
        {
            this.guion = new Guion(this.getEscena());
            hilo = new Thread(new ThreadStart(play));

        }
        public void iniciarAnimacion(Object sender, EventArgs e)
        {
            hilo.Start();
        }

        public void play()
        {
            int dur = 10000;
            int tiempoInicial = Environment.TickCount & Int32.MaxValue;
            int tiempo = Environment.TickCount & Int32.MaxValue;
            int tiempoFinal = tiempo + dur;
            int tiempoActual = 0;
            //int i = 0;
            Escena escena = guion.escenas.ElementAt(0);
            Accion accion = guion.escenas.ElementAt(0).acciones.ElementAt(0);
            bool sw = true;
            do
            {
                tiempoActual = (Environment.TickCount & Int32.MaxValue) - tiempoInicial ;
                //Console.WriteLine(tiempoActual);
                for (int i = 0; i < escena.getCantidad(); i++)
                {
                    accion = escena.getAccion(i);
                    if (tiempoActual >= accion.tiempoI && tiempoActual <= accion.tiempoF)
                    {
                        reproducirAccion(accion, tiempoActual);
                    }
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
                    escalar(a, a.parametros);
                }
                if (a.accion[1] == 1)//rotar
                {
                    rotar(a, a.parametros, tiempoActual);
                }
                if (a.accion[2] == 1)//trasladar
                {
                    trasladar(a, a.parametros, tiempoActual);
                }
            Formulario.escenario.Dibujar();
        }

        public string[] getObjetoParte(string cad)
        {
            string[] res = cad.Split('.');
            return res;
        }

        public void trasladar(Accion a, List<float> par, int tiempoActual)
        {
            float tiempo = a.tiempoF - a.tiempoI;
            float cada = tiempo / 5;
            //Console.WriteLine(cada);
            //if (tiempoActual % cada == 0 && tiempoActual >= a.tiempoSiguiente)
            if (tiempoActual >= a.tiempoSiguiente)
            {
                a.tiempoSiguiente += (long)cada;
                Console.WriteLine(tiempoActual);
                Formulario.escenario.GetObjeto(a.nombreObjeto).Trasladar(par[0], par[1], par[2]);
                //Formulario.escenario.GetObjeto(objeto[0]).GetCara(objeto[1]).Rotar(par[0], par[1], par[2]);
            }

        }

        public void rotar(Accion a, List<float> par, int tiempoActual)
        {
            float tiempo = a.tiempoF - a.tiempoI;
            float cada = tiempo / 5;
            //Console.WriteLine(cada);
            //if (tiempoActual % cada == 0 && tiempoActual >= a.tiempoSiguiente)
            if (tiempoActual >= a.tiempoSiguiente)
            {
                a.tiempoSiguiente += (long)cada;
                Console.WriteLine(tiempoActual);
                Formulario.escenario.GetObjeto(a.nombreObjeto).Rotar(par[0], par[1], par[2]);
                //Formulario.escenario.GetObjeto(objeto[0]).GetCara(objeto[1]).Rotar(par[0], par[1], par[2]);
            }
        }

        public void escalar(Accion a, List<float> par)
        {
            Formulario.escenario.GetObjeto(a.nombreObjeto).Escalar(par[0], par[1], par[2]);
        }

        public List<Escena> getEscena()
        {
            
            Accion p = new Accion("cubo2", new List<byte>() { 0, 0, 1}, new List<float>() { 1, 0, 0 },3000, 5000, true) ;
            Accion p1 = new Accion("cubo2", new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 20, 0 }, 5001, 7000, true);
            Accion p2 = new Accion("cubo2", new List<byte>() { 0, 0, 1 }, new List<float>() { -1, 0, 0 }, 7001, 9000, true);
            Escena e = new Escena("moverse", new List<Accion>() { p, p1, p2 });
            List<Escena> lista = new List<Escena>() { e};
            return lista;
        }
    }
}
