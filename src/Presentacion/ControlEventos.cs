using Proyecto1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_01.src.Presentacion
{
    public partial class Formulario : Form
    {
        
        public Escenario escenario;
        Punto trasladar, escalar;
        string nombreComboCara, nombreComboObjeto;
        sbyte indiceComboObjeto, indiceComboCara;


        public Formulario()
        {
            InitializeComponent();
            escenario = new Escenario();
            //Objeto.SerializeJsonFile("cubo.json", GetCuboSimple());
            escenario.SetObjeto("cubo1", Objeto.DeserializeJsonFile("cubo.json"));
            escenario.SetObjeto("cubo2", Objeto.DeserializeJsonFile("cubo.json"));
            escenario.GetObjeto("cubo1").Trasladar(40, 0, 0);
            escenario.GetObjeto("cubo2").Trasladar(-40, 0, 0);
            escenario.GetObjeto("cubo2").Rotar(15, 40, 0.0f);
            iniciarCombo();
            trasladar = new Punto();
            escalar = new Punto();
        }
        //iniciadores----------------------------------------------------------------------------
        private void iniciarCombo()
        {
            comboSeleccionar.Items.Add("Escenario");
            foreach (var name in this.escenario.lista.Keys) //dibujar los vertices
                comboSeleccionar.Items.Add(name);
        }

        private void CargarCaras()
        {
            this.comboSeleccionarCaras.Items.Clear();
            this.comboSeleccionarCaras.Text = "Seleccionar Cara";
            this.indiceComboCara = -1;
            if (this.indiceComboObjeto > 0)// el 0 es el escenario
            {
                Objeto aux = escenario.GetObjeto(this.nombreComboObjeto);
                foreach (var nombreDeCaras in aux.lista.Keys) //dibujar los vertices
                {
                    comboSeleccionarCaras.Items.Add(nombreDeCaras);
                }
                //int indice = this.ComboSeleccionarCaras.SelectedIndex;
                //string seleccionado = this.ComboSeleccionarCaras.Items[indice].ToString();
            }
        }

        //Combos-------------------------------------------------------------------------------------------

        private void comboSeleccionar_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.indiceComboObjeto = (sbyte)this.comboSeleccionar.SelectedIndex;
            this.nombreComboObjeto = this.comboSeleccionar.Items[this.indiceComboObjeto].ToString();
            this.CargarCaras();
        }

        private void comboSeleccionarCaras_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.indiceComboCara = (sbyte)this.comboSeleccionarCaras.SelectedIndex;
            this.nombreComboCara = this.comboSeleccionarCaras.Items[this.indiceComboCara].ToString();
        }
        //Traslacion---------------------------------------------------------------------------------------------

        private void trackBarTraslacionX_Scroll(object sender, EventArgs e)
        {
            realizarTraslacionX();
        }

        private void trackBarTraslacionY_Scroll(object sender, EventArgs e)
        {
            realizarTraslacionY();
        }

        private void trackBarTraslacionZ_Scroll(object sender, EventArgs e)
        {
            realizarTraslacionZ();
        }
        //Rotacion---------------------------------------------------------------------------------------------

        private void trackBarRotacionX_Scroll(object sender, EventArgs e)
        {
            realizarRotacionX();
        }

        private void trackBarRotacionY_Scroll(object sender, EventArgs e)
        {
            realizarRotacionY();
        }

        private void trackBarRotacionZ_Scroll(object sender, EventArgs e)
        {
            realizarRotacionZ();
        }
        //Escalacion---------------------------------------------------------------------------------------------

        private void trackBarEscalacionX_Scroll(object sender, EventArgs e)
        {
            realizarEscalacionX();
        }

        private void trackBarEscalacionY_Scroll(object sender, EventArgs e)
        {
            realizarEscalacionY();
        }

        private void trackBarEscalacionZ_Scroll(object sender, EventArgs e)
        {
            realizarEscalacionZ();
        }

        //Privados------------------------------------------------------------------------------------------------
        private void realizarTraslacionX()
        {
            float x = trackBarTraslacionX.Value;
            float eje = (this.trasladar.x < x) ? 1.0f : -1.0f;
            this.trasladar.x = x;
            //Console.WriteLine(indice);
            if (this.indiceComboObjeto == 0) //escenario
            {
                escenario.Trasladar(eje, 0, 0);
            }
            else if (this.indiceComboCara == -1) //seleccion Objeto
            {
                escenario.GetObjeto(this.nombreComboObjeto).Trasladar(eje, 0, 0);
            }
            else //seleccionando Caras
            {
                escenario.GetObjeto(this.nombreComboObjeto).GetCara(this.nombreComboCara).Trasladar(eje, 0, 0);
            }
        }
        private void realizarTraslacionY()
        {
            float y = trackBarTraslacionY.Value;
            float eje = (trasladar.y < y) ? 1.0f : -1.0f;
            trasladar.y = y;
            if (this.indiceComboObjeto == 0) //escenario
            {
                escenario.Trasladar(0, eje, 0);
            }
            else if (this.indiceComboCara == -1) //seleccion Objeto
            {
                escenario.GetObjeto(this.nombreComboObjeto).Trasladar(0, eje, 0);
            }
            else //seleccionando Caras
            {
                escenario.GetObjeto(this.nombreComboObjeto).GetCara(this.nombreComboCara).Trasladar(0, eje, 0);
            }
        }
        private void realizarTraslacionZ()
        {
            float z = trackBarTraslacionZ.Value;
            float eje = (trasladar.z < z) ? 1.0f : -1.0f;
            trasladar.z = z;
            if (this.indiceComboObjeto == 0) //escenario
            {
                escenario.Trasladar(0, 0, eje);
            }
            else if (this.indiceComboCara == -1) //seleccion Objeto
            {
                escenario.GetObjeto(this.nombreComboObjeto).Trasladar(0, 0, eje);
            }
            else //seleccionando Caras
            {
                escenario.GetObjeto(this.nombreComboObjeto).GetCara(this.nombreComboCara).Trasladar(0, 0, eje);
            }
        }
        //
        private void realizarRotacionX()
        {
            float eje = 3.0f;
            if (this.indiceComboObjeto == 0) //escenario
            {
                escenario.Rotar(eje, 0, 0);
            }
            else if (this.indiceComboCara == -1) //seleccion Objeto
            {
                escenario.GetObjeto(this.nombreComboObjeto).Rotar(eje, 0, 0);
            }
            else //seleccionando Caras
            {
                escenario.GetObjeto(this.nombreComboObjeto).GetCara(this.nombreComboCara).Rotar(eje, 0, 0);
            }

        }

        private void realizarRotacionY()
        {
            float eje = 3.0f;
            if (this.indiceComboObjeto == 0) //escenario
            {
                escenario.Rotar(0, eje, 0);
            }
            else if (this.indiceComboCara == -1) //seleccion Objeto
            {
                escenario.GetObjeto(this.nombreComboObjeto).Rotar(0, eje, 0);
            }
            else //seleccionando Caras
            {
                escenario.GetObjeto(this.nombreComboObjeto).GetCara(this.nombreComboCara).Rotar(0, eje, 0);
            }
        }
        private void realizarRotacionZ()
        {
            float eje = 3.0f;
            if (this.indiceComboObjeto == 0) //escenario
            {
                escenario.Rotar(0, 0, eje);
            }
            else if (this.indiceComboCara == -1) //seleccion Objeto
            {
                escenario.GetObjeto(this.nombreComboObjeto).Rotar(0, 0, eje);
            }
            else //seleccionando Caras
            {
                escenario.GetObjeto(this.nombreComboObjeto).GetCara(this.nombreComboCara).Rotar(0, 0, eje);
            }
        }



        //
        private void realizarEscalacionX()
        {
            float x = trackBarEscalacionX.Value;
            float eje = (escalar.x < x) ? 0.9f : 1.1f;
            escalar.x = x;
            if (this.indiceComboObjeto == 0) //escenario
            {
                escenario.Escalar(eje, 0, 0);
            }
            else if (this.indiceComboCara == -1) //seleccion Objeto
            {
                escenario.GetObjeto(this.nombreComboObjeto).Escalar(eje, 0, 0);
            }
            else //seleccionando Caras
            {
                escenario.GetObjeto(this.nombreComboObjeto).GetCara(this.nombreComboCara).Escalar(eje, 0, 0);
            }
        }
        private void realizarEscalacionY()
        {
            float y = trackBarEscalacionY.Value;
            float eje = (escalar.y < y) ? 0.9f : 1.1f;
            escalar.y = y;
            if (this.indiceComboObjeto == 0) //escenario
            {
                escenario.Escalar(0, eje, 0);
            }
            else if (this.indiceComboCara == -1) //seleccion Objeto
            {
                escenario.GetObjeto(this.nombreComboObjeto).Escalar(0, eje, 0);
            }
            else //seleccionando Caras
            {
                escenario.GetObjeto(this.nombreComboObjeto).GetCara(this.nombreComboCara).Escalar(0, eje, 0);
            }
        }

        private void realizarEscalacionZ()
        {
            float z = trackBarEscalacionZ.Value;
            float eje = (escalar.z < z) ? 0.9f : 1.1f;
            escalar.z = z;
            if (this.indiceComboObjeto == 0) //escenario
            {
                escenario.Escalar(0, 0, eje);
            }
            else if (this.indiceComboCara == -1) //seleccion Objeto
            {
                escenario.GetObjeto(this.nombreComboObjeto).Escalar(0, 0, eje);
            }
            else //seleccionando Caras
            {
                escenario.GetObjeto(this.nombreComboObjeto).GetCara(this.nombreComboCara).Escalar(0, 0, eje);
            }

        }
    }
}
