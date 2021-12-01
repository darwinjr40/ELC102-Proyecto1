using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    public class Game : GameWindow
    {
        Escenario escenario;


        //-----------------------------------------------------------------------------------------------------------------
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }
        
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color4.Black);
            //------------------------------
            this.escenario = new Escenario();
            //Objeto.SerializeJsonFile("cubo.json", GetCuboSimple());
            escenario.SetObjeto("cubo", Objeto.DeserializeJsonFile("cubo.json"));
            //------------------------------
            base.OnLoad(e);     
        }
        
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            //GL.DepthMask(true);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.LoadIdentity();
            //-----------------------
            this.escenario.Dibujar();
            //-----------------------
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnResize(EventArgs e)
        {
            float d = 30;
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-d, d, -d, d, -d, d);
            //GL.Frustum(-80, 80, -80, 80, 4, 100);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            base.OnResize(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            base.OnUnload(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }


    }
}
