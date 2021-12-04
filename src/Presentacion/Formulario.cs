using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Proyecto1;
using Proyecto1_01.src.clases.Guion;

namespace Proyecto1_01.src.Presentacion
{
    public partial class Formulario : Form
    {
        
        GLControl glControl;
        ControladorAnimacion ca;

        private void Formulario_Load(object sender, EventArgs e)
        {
            ca = new ControladorAnimacion();
            this.glControl = new GLControl();
            this.glControl.BackColor = System.Drawing.Color.CadetBlue;
            this.glControl.Location = new System.Drawing.Point(420, 0);
            this.glControl.Name = "glControl1";
            this.glControl.Size = new System.Drawing.Size(this.Width - 440, this.Height - 44);//(780, this.Height);
            this.glControl.TabIndex = 1;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl.Resize += new System.EventHandler(glControl_Resize);
            this.Controls.Add(this.glControl);
            this.button1.Click += new System.EventHandler(ca.iniciarAnimacion);
        }

        private void glControl_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color4.Black);
            GL.Enable(EnableCap.DepthTest);
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.LoadIdentity();
            glControl.MakeCurrent();
            //-----------------------
            escenario.Dibujar();
            //-----------------------
            glControl.Invalidate();
            glControl.SwapBuffers();
        }

        private void glControl_Resize(object sender, EventArgs e)
        {
            float d = 80;
            GL.Viewport(0, 0, glControl.Width, glControl.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-d, d, -d, d, -d, d);
            //GL.Frustum(-70, 70, -70, 70, 5, 50);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            glControl.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            escenario.GetObjeto("brazoD12").Rotar(0, -1, 0);
        }
    }
}
