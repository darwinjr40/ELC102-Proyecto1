using Proyecto1;
using Proyecto1_01.src.Presentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_01
{
    class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Formulario());
            

            //Game juego = new Game(800, 600, "LearnOpenTK");
            //juego.Run(60);
        }
    }
}
