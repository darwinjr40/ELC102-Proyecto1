using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
   
    public class Punto
    {
        //atributos
        private float ejeX { get; set; }
        private float ejeY { get; set; }
        private float ejeZ { get; set; }
        //properties
         public float x { get { return ejeX; } set { ejeX = value; } }
         public float y { get => ejeY; set => ejeY = value;}
         public float z { get => ejeZ; set => ejeZ = value; }

        //contructor con parametros---------------------------------------------------------
        public Punto(float x, float y, float z)
        {
            this.ejeX = x;
            this.ejeY = y;
            this.ejeZ = z;
        }
        //-----------------------------------------------------------------------------------------------------------------
        public Punto(): this(0, 0, 0) { }
        //-----------------------------------------------------------------------------------------------------------------
        //Contructor copia
        public Punto(Punto p)
        {
            this.ejeX = p.ejeX;
            this.ejeY = p.ejeY;
            this.ejeZ = p.ejeZ;
        }
        //-----------------------------------------------------------------------------------------------------------------
        //Contructor con el mismo valor inicial 
        public Punto(float valor)
        {
            this.ejeX = this.ejeY = this.ejeZ = valor;
        }
        //-----------------------------------------------------------------------------------------------------------------
        public Vector3 ToVector3() 
        { 
            return new Vector3(this.ejeX, this.ejeY, this.ejeZ); 
        }
        //-----------------------------------------------------------------------------------------------------------------
        public void acumular(Punto p)
        {
            this.ejeX += p.x; 
            this.ejeY += p.y;
            this.ejeZ += p.z;
        }
        public void acumular(float x, float y, float z)
        {
            this.ejeX += x;
            this.ejeY += y;
            this.ejeZ += z;
        }
        public void multiplicar(float x, float y, float z)
        {
            this.ejeX *= x;
            this.ejeY *= y;
            this.ejeZ *= z;
        }
        public void setPunto(float valor)
        {
            this.ejeX = this.ejeY = this.ejeZ = valor;
        }
        //-----------------------------------------------------------------------------------------------------------------
        public bool compareTo(Punto a)
        {
            return (this.ejeX == a.ejeX && this.ejeY == a.ejeY && this.ejeZ == a.ejeZ);
        }
        public override string ToString() => $"({ejeX}|{ejeY}|{ejeZ})";
        


    }
}
