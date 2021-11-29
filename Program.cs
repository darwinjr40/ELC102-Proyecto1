using Proyecto1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Game juego = new Game(800, 600, "LearnOpenTK");
            juego.Run(60);
        }
    }
}
