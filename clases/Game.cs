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

        public Objeto GetCuboSimple() //todos el mismo origen
        {
            Dictionary<string, Cara> caras = new Dictionary<string, Cara>
                         {
                            //atras
                            {
                                "cara1",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.LineLoop,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(-10.0f, -10.0f, -10.0f) },
                                        { "punto2", new Punto(-10.0f, 10.0f, -10.0f) },
                                        { "punto3", new Punto(10.0f, 10.0f, -10.0f) },
                                        { "punto4", new Punto(10.0f, -10.0f, -10.0f) }
                                    },
                                    Color.Pink,
                                    new Punto(0, 0, -10.0f)
                                )
                            },
                            //izquierda
                            {
                                "cara2",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.LineLoop,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(-10.0f, -10.0f, -10.0f) },
                                        { "punto2", new Punto(-10.0f, 10.0f, -10.0f) },
                                        { "punto3", new Punto(-10.0f, 10.0f, 10.0f) },
                                        { "punto4", new Punto(-10.0f, -10.0f, 10.0f) }
                                    },
                                    Color.Red,
                                    new Punto(-10.0f, 0, 0)
                                )
                            },
                            //derecha
                            {
                                "cara3",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.LineLoop,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(10.0f, -10.0f, 10.0f) },
                                        { "punto2", new Punto(10.0f, 10.0f, 10.0f) },
                                        { "punto3", new Punto(10.0f, 10.0f, -10.0f) },
                                        { "punto4", new Punto(10.0f, -10.0f, -10.0f) }
                                    },
                                    Color.Yellow,
                                    new Punto(10.0f, 0, 0)
                                )
                            },
                            //superior
                            {
                                "cara4",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.LineLoop,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(-10.0f, 10.0f, 10.0f) },
                                        { "punto2", new Punto(-10.0f, 10.0f, -10.0f) },
                                        { "punto3", new Punto(10.0f, 10.0f, -10.0f) },
                                        { "punto4", new Punto(10.0f, 10.0f, 10.0f) }
                                    },
                                    Color.Aqua,
                                    new Punto(0, 10.0f, 0)
                                )
                            },
                            //inferior
                            {
                                "cara5",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.LineLoop,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(-10.0f, -10.0f, -10.0f) },
                                        { "2", new Punto(-10.0f, -10.0f, 10.0f) },
                                        { "3", new Punto(10.0f, -10.0f, 10.0f) },
                                        { "4", new Punto(10.0f, -10.0f, -10.0f) }
                                    },
                                    Color.Blue,
                                    new Punto(0, -10.0f, 0)
                                )
                            },
                           // frente
                            {
                                "cara6",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.LineLoop,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(-10.0f, -10.0f, 10.0f) },
                                        { "punto2", new Punto(-10.0f, 10.0f, 10.0f) },
                                        { "punto3", new Punto(10.0f, 10.0f, 10.0f) },
                                        { "punto4", new Punto(10.0f, -10.0f, 10.0f) }
                                    },
                                    Color.Green,
                                    new Punto(0, 0, 10)
                                )
                            },

                         };
            return new Objeto(new Punto(0, 0, 0), 5, 5, 5, caras);
        }

    }
}
