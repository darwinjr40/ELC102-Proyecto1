using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Proyecto1
{
    public class Cubo
    {
        private float ancho;
        private float alto;
        private float profundidad;
        public Punto origen;

        public Cubo(Punto p, float ancho, float alto, float profundidad)
        {
            origen = p;
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;
        }

        public void Dibujar()
        {
            GL.Rotate(20, 1, 1, 0);
            PrimitiveType primitiveType = PrimitiveType.LineLoop;
            //PrimitiveType primitiveType = PrimitiveType.Quads;
            //GL.Rotate(0.9, 1, 1, 1);
            back(primitiveType);  //rosado
            left(primitiveType);   //rojo
            right(primitiveType);  //amarillo
            top(primitiveType);  //celeste
            front(primitiveType);  //verde
            bottom(primitiveType); //azul
        }

        private void right(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            //GL.Color4(Color.Aqua);
            GL.Color3(1.0, 1.0, 0.0);//amarillo
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z + profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z + profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z - profundidad);
            GL.End();
        }

        private void left(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color3(1, 0.0, 0.0);//rojo
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z + profundidad);
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z + profundidad);
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z - profundidad);
            GL.End();
        }

        private void front(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color3(0.0, 1.0, 0.0);//verde
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z + profundidad);
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z + profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z + profundidad);
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z + profundidad);
            GL.End();
        }

        private void back(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color3(1, 0.2, 1);//rosado
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z - profundidad);
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z - profundidad);
            GL.End();
        }

        private void bottom(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color3(0.0, 0.0, 1.0);//azul;
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z + profundidad);
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z + profundidad);
            GL.End();
        }

        private void top(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color3(0, 1, 1.3);//azul;
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z + profundidad);
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z + profundidad);
            GL.End();
        }

    }
}

