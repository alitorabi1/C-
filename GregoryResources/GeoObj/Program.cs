using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObj
{
    abstract class GeoObj
    {
        public double Area, Circumperim;
        private int vertices;
        public int Vertices
        {
            get { return vertices; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Vertices cannot have negative value");
                }
                else
                {
                    vertices = value;
                }
            }
        }
        public override string ToString()
        {
            return String.Format("{0},area: {1:0.00}, circumperim: {2:0.00}," +
            "vertices: {3}"
            , this.GetType().Name, Area, Circumperim, Vertices);
        }
    }
    class Rectangle : GeoObj
    {
        double height;
        public double Height
        {
            get { return height; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Height cannot have negative value");
                }
                else
                {
                    height = value;
                }
            }
        }
        double width;
        public double Width
        {
            get { return width; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Width cannot have negative value");
                }
                else
                {
                    width = value;
                }
            }
        }
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
            Vertices = 4;
            Circumperim = (height + width) * 2;
            Area = height * width;
        }

    }
    class Square : Rectangle
    {
        public Square(double edge) : base(edge, edge) { }
    }
    class Circle : GeoObj
    {
        double radius;

        public double Radius
        {
            get { return radius; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Radius canoot be negative");
                }
                else
                {
                    radius = value;
                }
            }
        }
        public Circle(double radius)
        {
            Radius = radius;
            Area = Math.PI * radius * radius;
            //Area = Math.PI * Math.Pow(radius, 2);
            Circumperim = 2 * Math.PI * radius;
            //Vertices = 0;
        }
    }
    class RightAngleTriangle : GeoObj
    {
        double basis;

        public double Basis
        {
            get { return basis; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("basis canoot be negative");
                }
                else
                {
                    basis = value;
                }
            }
        }
        double height;

        public double Height
        {
            get { return height; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("height canoot be negative");
                }
                else
                {
                    height = value;
                }
            }
        }
        public RightAngleTriangle(double height, double basis)
        {
            Height = height;
            Basis = basis;
            Area = basis * height * 0.5;
            Circumperim = basis + height + Math.Sqrt(Math.Pow(basis, 2) + Math.Pow(height, 2));
            Vertices = 3;
        }
    }
    class Point : GeoObj
    {
        public Point()
        {
            Vertices = 1;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            List<GeoObj> shapesList = new List<GeoObj>();

            try
            {
                shapesList.Add(new Rectangle(10, 15));
                //shapesList.Add(new Rectangle(-10, 15));
                shapesList.Add(new Square(10));
                //shapesList.Add(new Square(-5));
                shapesList.Add(new Circle(10));
                //shapesList.Add(new Circle(-5));
                shapesList.Add(new RightAngleTriangle(10, 5));
                //shapesList.Add(new RightAngleTriangle(10, -5));
                shapesList.Add(new Point());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);

            }
            foreach (GeoObj shape in shapesList)
            {
                Console.WriteLine(shape);
            }
            //Sort the shape Objects in the list by Area
            List<GeoObj> sortedByAreaList =
                shapesList.OrderBy(x => x.Area).ToList();
            Console.WriteLine("\nSorted naturally by area: ");
            foreach (GeoObj shape in sortedByAreaList)
            {
                Console.WriteLine(shape);
            }
            //Sort the shape Objects in the list by Circumperim in descending order
            List<GeoObj> sortedByCircumperimList =
                shapesList.OrderByDescending(x => x.Circumperim).ToList();
            Console.WriteLine("\nSorted descending by Circumperim: ");
            foreach (GeoObj shape in sortedByCircumperimList)
            {
                Console.WriteLine(shape);
            }
            //Sort the shape Objects in the list by Vertices,
            //if there are two shapes with the same number of vertices
            //sort by area in descending order

            List<GeoObj> sortedByVerticesList =
                shapesList.OrderBy(x =>
                    x.Vertices).ThenByDescending(x => x.Area).ToList();
            Console.WriteLine("\nSorted ascending by Vertices: ");
            foreach (GeoObj shape in sortedByVerticesList)
            {
                Console.WriteLine(shape);
            }
            Console.ReadKey();

        }
    }
}
