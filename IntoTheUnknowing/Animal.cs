using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace IntoTheUnknowing
{
    public class ColorPoint
    {
        public Point Location;
        public Color Color;
        public ColorPoint(Point location, Color color)
        {
            Location = location;
            Color = color;
        }
    }
    public class Animal
    {
        
        public Point Location;
        public int DirectionX;
        public int DirectionY;
        public List<ColorPoint> Body;
        public int Width;
        public int Height;
        public enum Rang
        {
            MicroPlankton,
            Plankton,
            Fish,
            LargeFish,
            Leviathan
        }
        public Rang range; //сделать енум на ранг
        public int limitedSize;

        public List<Color> Gamma;
       

        public int PixelSize;

        public Animal()
        {
            var rnd = new Random();
            range = (Rang)rnd.Next(5);
        }

        public void Create()
        {
            var rnd = new Random();
            Gamma = new List<Color>()
            {
                Color.FromArgb(rnd.Next(120, 255), rnd.Next(255), rnd.Next(255), rnd.Next(255)),
                Color.FromArgb(rnd.Next(120, 255), rnd.Next(255), rnd.Next(255), rnd.Next(255)),
                Color.FromArgb(rnd.Next(120, 255), rnd.Next(255), rnd.Next(255), rnd.Next(255))
            };

            var limit = limitedSize;
           
            var start = new Point(Height / 2, Width / 2);
            var markedCells = new HashSet<Point>();
            var availableCells = new HashSet<Point>();

            Body = new List<ColorPoint>();

            while (limit != 0)
            {
                Body.Add(new ColorPoint(start, Gamma[rnd.Next(Gamma.Count)]));

                markedCells.Add(start);

                limit--;

                var area = GetAreaPfPoint(start);

                foreach (var point in area)
                {
                    if (!availableCells.Contains(point) && !markedCells.Contains(point)
                        && point.X < Height && point.Y < Width && point.X >= 0 && point.Y >= 0)
                        availableCells.Add(point);
                }
                if (availableCells.Count == 0)
                    break;

                var availableCell = availableCells.ToArray()[rnd.Next(availableCells.Count)];
                availableCells = availableCells.ToHashSet();
                availableCells.Remove(availableCell);
                start = availableCell;
            }
        }

        private Point[] GetAreaPfPoint(Point point)
        {
            return new Point[]
            {
                new Point(point.X, point.Y),
                new Point(point.X, point.Y-1),
                new Point(point.X-1, point.Y),
                new Point(point.X+1, point.Y),
                new Point(point.X, point.Y+1)
            };
        }
    }
    public class MicroPlankton : Animal
    {
        public MicroPlankton()
        {
            PixelSize = 3;
            var rnd = new Random();
            Height = rnd.Next(1, 100);
            Width = rnd.Next(1, 100);
            limitedSize = rnd.Next(1, 4);
        }


    }
    public class Plankton : Animal
    {
        public Plankton()
        {
            PixelSize = 5;
            var rnd = new Random();
            Height = rnd.Next(5, 100);
            Width = rnd.Next(5, 100);
            limitedSize = rnd.Next(3, Math.Max(4, 10));
        }


    }
    public class Fish : Animal
    {
        public Fish()
        {
            PixelSize = 7;
            var rnd = new Random();
            Height = rnd.Next(10, 100);
            Width = rnd.Next(40, 100);
            limitedSize = rnd.Next(15, 30);
        }

    }
    public class LargeFish : Animal
    {

        public LargeFish()
        {
            PixelSize = 10;
            var rnd = new Random();
            Height = rnd.Next(5, 20);
            Width = rnd.Next(5, 20);
            limitedSize = rnd.Next(3, Math.Max(4, Width * Height - 80));
        }
    }
    public class Leviathan : Animal
    {
        public Leviathan()
        {
            PixelSize = 15;
            var rnd = new Random();
            Height = rnd.Next(20, 80);
            Width = rnd.Next(40, 80);
            limitedSize = rnd.Next(15, 200);
        }
    }
}
