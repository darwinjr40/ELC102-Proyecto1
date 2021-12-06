using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_01.src.clases.Guion
{
    class Guion
    {
        public List<Escena> escenas { get; set; }

        public Guion()
        {
            escenas = new List<Escena>();
        }

        public Guion(List<Escena> escenas)
        {
            this.escenas = escenas;
        }
        public void setEscena(Escena x)
        {
            escenas.Add(x);
        }
        public Escena getEscena(int i)
        {
            return escenas.ElementAt(i);
        }

        
        public void SetEscena(Escena e)
        {
            escenas.Add(e);
        }
    }
}
