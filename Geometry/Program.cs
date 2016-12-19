using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{

    abstract class GeoObj
    {
        public GeoObj(double area, double circuperim, int vertices)
        {
            Area = area;
            Circuperim = circuperim;
            Vertices = vertices;
        }
        private double Area, Circuperim; // Circumference or Perimeter
        public double area
        {
            get { return area; }
            set { Area = area; }
        }

        public double circuperim
        {
            get { return circuperim; }
            set { Circuperim = circuperim; }
        }

        private int Vertices;
        public int vertices
        {
            get { return vertices; }
            set { Vertices = vertices; }
        }

        public override String ToString()
        {
            return string.Format("c: {0:0.00}, a: {1:0.00}, v: {2}", Circuperim, Area, Vertices);
        }
    }


    class Rectangle : GeoObj
    {
        public Rectangle(double height, double width)
                : base((height * width), (2 * height + 2 * width), 4)
        {
            Height = height;
            Width = width;
        }
        private double Height, Width;
        public double height
        {
            get { return height; }
            set { Height = height; }
        }
        public double width
        {
            get { return width; }
            set { Width = width; }
        }
    }
    // TODO: implement classes: Point, Square, Circle, RightAngleTriangle
    // TODO: create 2 instances of each, add to ArrayList<GeoObj>
    // TODO: print result of toString on each element on a single line

    class Point : GeoObj
    {

        public Point()
            : base(0, 0, 0)
        {
        }
    }

    class Square : Rectangle
    {

        public Square(double edge)
            : base(edge, edge)
        {
        }
        private double Edge;
        public double edge
        {
            get { return edge; }
            set { Edge = edge; }
        }
    }

    class Circle : GeoObj
    {
        private double Radius;
        public double radius
        {
            get { return radius; }
            set { Radius = radius; }
        }
        public Circle(double radius)
            : base((radius * radius * Math.PI), (2 * Math.PI * radius), 0)
        {
            Radius = radius;
        }
    }

    class RightAngleTriangle : GeoObj
    {
        private double RBase, Height;
        public double rBase
        {
            get { return rBase; }
            set { RBase = rBase; }
        }
        public double height
        {
            get { return height; }
            set { Height = height; }
        }

        public RightAngleTriangle(double rBase, double height)
            : base((rBase * height * 0.5), (rBase + height + Math.Sqrt(Math.Pow(rBase, 2) + Math.Pow(height, 2))), 3)
        {
            RBase = rBase;
            Height = height;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<GeoObj> shapes = new List<GeoObj>();
            shapes.Add(new RightAngleTriangle(2, 3));
            shapes.Add(new Circle(5));
            shapes.Add(new Square(3));
            Point p1 = new Point();
            shapes.Add(p1);
            shapes.Add(new Rectangle(2, 4));

            //
            foreach (GeoObj g in shapes)
            {
                Console.WriteLine(g.ToString());
            }
            //
            //            List<GeoObj> SortedList1 = shapes.OrderBy(o => o.area).ToList();
            shapes.Sort((x, y) => x.area.CompareTo(y.area));
            Console.WriteLine("Sorted naturally by area:");
            foreach (GeoObj g in shapes)
            {
                Console.WriteLine(g);
            }
            //
            // Comparator interface, compare() method
            //List<GeoObj> SortedList2 = shapes.OrderBy(o => o.circuperim).ToList();
            //Console.WriteLine("Sorted by circumference / perimiter:");
            //foreach (GeoObj g in SortedList2)
            //{
            //    Console.WriteLine(g);
            //}
            ////
            //List<GeoObj> SortedList3 = shapes.OrderBy(o => o.vertices).ToList();
            //Console.WriteLine("Sorted by vertices:");
            //foreach (GeoObj g in SortedList3)
            //{
            //    Console.WriteLine(g);
            //}
            Console.ReadKey();
        }
    }
}