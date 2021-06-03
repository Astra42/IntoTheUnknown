using System;
using System.Collections.Generic;
using System.Drawing;

namespace IntoTheUnknowing
{
    public class Model
    {
        public class Planet
        {
            //добавить генерацию биомов
            public Color Water;
            public int R;
            public int G;
            public int B;
            public int P;
            public int DepthDif;
            public int Number;

            public Planet()
            {
               
                DepthDif = 0;
                var rnd = new Random();
                Number = rnd.Next(10000, 1000000000);

                R = rnd.Next(255);
                G = rnd.Next(255);
                B = rnd.Next(50,255);
                P = rnd.Next(0, 190);
                Water = Color.FromArgb(P, R, G, B);
            }
            public void Update()
            {
                var d = 1;
                if (DepthDif == 1)
                {
                    if (R + d < 255 && G + d < 255 && B + d < 255 && P - d > 0 )
                    {
                        R = (R + d);
                        G = (G + d);
                        B = (B + d);
                        P -= d;

                    }
                }
                else if (DepthDif == 2)
                {
                    if (R - d > 0 && G - d > 0 && B - d > 0 && P + d < 255)
                    {
                        R = (R - d);
                        G = (G - d);
                        B = (B - d);
                        P += d;
                        
                    }
                }

                DepthDif = 0;
                Water = Color.FromArgb(P, R, G, B);
            }
          


        }
       
        public class Submarine
        {

            public Point Coordinates;
            public TypeSubmarine Type;
            public bool IsSubmarineSail;
            public PositionMotors PositionMotors;

        }
        public enum TypeSubmarine
        {
            Submarine,
            Submarinera
        }
        public enum PositionMotors
        {
            Down,
            Up
        }
        public class Game
        {
            public  Planet Planet;
            public  Submarine Submarine;

            public List<Plankton> Planktons;
            public List<Fish> Fishes;
            public List<Leviathan> Leviathans;

            public static int limitCntFish;
            public static int limitCntPlankton;
            public static int limitCntLeviathan;

            public int DirectionShiftX;
            public int DirectionShiftY;


            public int Distance;
            public int Temperature;
            public int Depth;

            


            public Game()
            {
                Distance = 0;
                Depth = 10000;
                Temperature = new Random().Next(-100, 200);

                Planktons = new List<Plankton>();
                Fishes = new List<Fish>();
                Leviathans = new List<Leviathan>();

                Planet = new Planet();
                limitCntLeviathan = new Random().Next(1, 2);
                limitCntFish = new Random().Next(20, 100);
                limitCntPlankton = new Random().Next(50, 200);
                Submarine = new Submarine() { Coordinates = new Point(0, 0), IsSubmarineSail = false, Type = Model.TypeSubmarine.Submarinera, PositionMotors = Model.PositionMotors.Down, };
            }

            public void Update()
            {
                var rnd = new Random();

                Planet.Update();

               if(Leviathans.Count < limitCntLeviathan)
                {
                    var leviathan = new Leviathan
                    {
                        Location = new Point(rnd.Next(0, 500), rnd.Next(0, 500)),
                        DirectionX = rnd.Next(-10, 10),
                        DirectionY = rnd.Next(-10, 10)
                    };
                    leviathan.Create();
                    Leviathans.Add(leviathan);
                }

               if(Planktons.Count < limitCntPlankton)
                {
                    var pl = new Plankton
                    {
                        Location = new Point(rnd.Next(0, 500), rnd.Next(0, 500)),
                        DirectionX = rnd.Next(-10, 10),
                        DirectionY = rnd.Next(-10, 10)
                    };

                    pl.Create();
                    Planktons.Add(pl);
                }

                if (Fishes.Count < limitCntFish)
                {
                    var fish = new Fish
                    {
                        Location = new Point(rnd.Next(0, 1000), rnd.Next(0, 1000)),
                        DirectionX = (rnd.Next(-10, 10)),
                        DirectionY = (rnd.Next(-10, 10))
                    };

                    fish.Create();
                    Fishes.Add(fish);
                }
            }
        }
    }
}
