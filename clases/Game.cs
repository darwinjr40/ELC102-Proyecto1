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
            escenario.SetObjeto("cubo1", Objeto.DeserializeJsonFile("cubo.json"));
            escenario.GetObjeto("cubo1").SetOrigen(-30, 20, 0);
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
            Console.WriteLine(this.escenario.escalacion.ToString());
            //-----------------------
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnResize(EventArgs e)
        {
            float d = 80;
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
            this.capturarTeclado();
            base.OnUpdateFrame(e);
        }

        public void capturarTeclado()
        {
            KeyboardState input = Keyboard.GetState();
            if (input.IsKeyDown(Key.Q))
            {
                escenario.Rotar(0.8f, 0, 0);
            }
            if (input.IsKeyDown(Key.W))
            {
                escenario.Rotar(0, 0.8f, 0);
            }
            if (input.IsKeyDown(Key.E))
            {
                escenario.Rotar(0, 0, 0.8f);
            }
            if (input.IsKeyDown(Key.A))
            {
                escenario.Trasladar(-1f, 0, 0);
            }
            if (input.IsKeyDown(Key.S))
            {
                escenario.Trasladar(1f, 0, 0);
            }
            if (input.IsKeyDown(Key.D))
            {
                escenario.Trasladar(0, 1.0f, 0);
            }
            if (input.IsKeyDown(Key.F))
            {
                escenario.Trasladar(0, -1.0f, 0);
            }
            if (input.IsKeyDown(Key.G))
            {
                escenario.Trasladar(0, 0, 1.0f);
            }
            if (input.IsKeyDown(Key.H))
            {
                escenario.Trasladar(0, 0, -1.0f);
            }

            if (input.IsKeyDown(Key.Z))
            {
                escenario.Escalar(0.9f, 0, 0);
            }
            if (input.IsKeyDown(Key.X))
            {
                escenario.Escalar(1.1f, 0, 0);
            }
            if (input.IsKeyDown(Key.C))
            {
                escenario.Escalar(0, 0.9f, 0);
            }
            if (input.IsKeyDown(Key.V))
            {
                escenario.Escalar(0, 1.1f, 0);
            }
            if (input.IsKeyDown(Key.B))
            {
                escenario.Escalar(0, 0, 0.9f);
            }
            if (input.IsKeyDown(Key.N))
            {
                escenario.Escalar(0, 0, 1.1f);
            }

        }
    }
}
