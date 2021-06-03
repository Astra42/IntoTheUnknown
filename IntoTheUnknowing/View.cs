using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntoTheUnknowing
{

	public partial class View : Form
	{
		public Bitmap SubmarineTexture1 = Resource1.Submarine,
					  SubmarineTexture2 = Resource1.Submarine3,
					  SubmarineTexture3 = Resource1.Submarine_Wait,

					  Submarinera_Down_DownB1 = Resource1.Subamrinera_Down_DownB1,
					  Subamrinera_Down_DownB2 = Resource1.Subamrinera_Down_DownB2, //вниз

					  Subamrinera_Down_UpB1 = Resource1.Subamrinera_Down_UpB1,
					  Subamrinera_Down_UpB2 = Resource1.Subamrinera_Down_UpB2, // вверх

					  Subamrinera_InTheSide_LeftB1 = Resource1.Subamrinera_InTheSide_LeftB1,
					  Subamrinera_InTheSide_LeftB2 = Resource1.Subamrinera_InTheSide_LeftB2,//влево

					  Subamrinera_InTheSide_RightB1 = Resource1.Subamrinera_InTheSide_RightB1,//вправо
					  Subamrinera_InTheSide_RightB2 = Resource1.Subamrinera_InTheSide_RightB2,

					  Subamrinera_InTheSide = Resource1.Subamrinera_InTheSide, //static
					  Subamrinera_Down = Resource1.Subamrinera_Down;



		public static bool flagSubmarine;
		public static bool flagForSubmarinera;
		public static char key;
		public static bool IsTheSubmarineSail;
	
		public static Bitmap SubmarineraTexture1;
		public static Bitmap SubmarineraTexture2;
		public static Bitmap SubmarineraTexture3;
		public static Bitmap SubmarineraTexture4;

		public static Bitmap SubmarineraTextureStatic;


		public void DrowSubmarine(Model.Submarine submarine, PaintEventArgs args)
		{
			if (submarine.IsSubmarineSail)
			{
				if (flagSubmarine)
				{
					args.Graphics.DrawImage(SubmarineTexture1, new Rectangle(100, 300, 233, 154));
					flagSubmarine = false;
				}
				else
				{
					args.Graphics.DrawImage(SubmarineTexture2, new Rectangle(100, 300, 233, 154));
					flagSubmarine = true;
				}
				submarine.IsSubmarineSail = false;
			}
            else 
			{
				args.Graphics.DrawImage(SubmarineTexture3, new Rectangle(100, 300, 233, 154)); 
			}
		}

		public void DrowSubmarinera(Model.Submarine submarine, PaintEventArgs args)
		{
			if (submarine.IsSubmarineSail)
			{
                if (flagForSubmarinera) //w
                {
					if (flagSubmarine)
					{
						args.Graphics.DrawImage(SubmarineraTexture1, new Rectangle(100, 300, 279, 156));
						flagSubmarine = false;
					}
					else
					{
						args.Graphics.DrawImage(SubmarineraTexture2, new Rectangle(100, 300, 279, 156));
						flagSubmarine = true;
					}
					flagForSubmarinera = false;
				}
                else//s
                {
					if (flagSubmarine)
					{
						args.Graphics.DrawImage(SubmarineraTexture3, new Rectangle(100, 300, 279, 156));
						flagSubmarine = false;
					}
					else
					{
						args.Graphics.DrawImage(SubmarineraTexture4, new Rectangle(100, 300, 279, 156));
						flagSubmarine = true;
					}
					flagForSubmarinera = false;
				}

				submarine.IsSubmarineSail = false;
			}
			else
			{
				args.Graphics.DrawImage(SubmarineraTextureStatic, new Rectangle(100, 300, 279, 156));
			}
		}
		public View()
		{

			var game = new Model.Game();

			var time = 0;
			var timer = new Timer();//кассены
			timer.Interval = 50; //тик вызвает абдейт у игры. вьюшка читает координаты у гейма и рисует.
			timer.Tick += (sender, args) =>
			{
				time++;
				Invalidate();
			};
			timer.Start();



			

			KeyPress += (sender, args) =>
			{
				var key = args.KeyChar;
				var control = new ContorlITU(key);
				control.UpdateConfig(game, game.Planet);
			};

			Paint += (sender, args) =>
			{
				

				args.Graphics.DrawString("The planet №" + game.Planet.Number.ToString(), new Font("Millitext", 16), Brushes.Aqua, new Point(0, 20));
				args.Graphics.DrawString("Depth:   " + game.Depth, new Font("Millitext", 16), Brushes.Aqua, new Point(0, 50));
				args.Graphics.DrawString("Distance:" + game.Distance, new Font("Pixel Text", 16), Brushes.Aqua, new Point(0, 80));
				args.Graphics.DrawString("Battery charge:   |###_ _| 72%", new Font("Pixel Text", 16), Brushes.Aqua, new Point(0, 110));
				args.Graphics.DrawString("Исследуйте океан", new Font("Millitext", 16), Brushes.Aqua, new Point(0, 130));
				args.Graphics.DrawString("Q - сменить аппарат", new Font("Millitext", 10), Brushes.Gray, new Point(0, 150));
				args.Graphics.DrawString("R - вращение турбинами, w,s- газ и обратный газ", new Font("Millitext", 10), Brushes.Gray, new Point(0, 170));


				SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

				args.Graphics.FillRectangle(new SolidBrush(game.Planet.Water), 0, 0, 2000, 900);

				var rnd = new Random();






				if(game.Submarine.Type == Model.TypeSubmarine.Submarine)
					DrowSubmarine(game.Submarine, args);
                else
                {
					if(game.Submarine.PositionMotors == Model.PositionMotors.Up)
                    {
						SubmarineraTexture1 = Subamrinera_Down_UpB1;
						SubmarineraTexture2 = Subamrinera_Down_UpB2;

						SubmarineraTexture3 = Submarinera_Down_DownB1;
						SubmarineraTexture4 = Subamrinera_Down_DownB2;

						SubmarineraTextureStatic = Subamrinera_Down;

						
					}
                    else
					{
						SubmarineraTexture1 = Subamrinera_InTheSide_RightB1;
						SubmarineraTexture2 = Subamrinera_InTheSide_RightB2;

						SubmarineraTexture3 = Subamrinera_InTheSide_LeftB1;
						SubmarineraTexture4 = Subamrinera_InTheSide_LeftB2;

						SubmarineraTextureStatic = Subamrinera_InTheSide;
					}

					DrowSubmarinera(game.Submarine, args);
				}
					




				game.Update();

				var dellistLeviathan = new List<Leviathan>();

				foreach (var leviathan in game.Leviathans)
				{
					leviathan.Location.X += leviathan.DirectionX + game.DirectionShiftX;
					leviathan.Location.Y += leviathan.DirectionY + game.DirectionShiftY;

					if (-3000 < leviathan.Location.Y && leviathan.Location.Y < 3000 && -3000 < leviathan.Location.X && leviathan.Location.X < 3000)
					{
						foreach (var cell in leviathan.Body)
						{
							args.Graphics.FillRectangle(new SolidBrush(cell.Color), (cell.Location.X) * leviathan.PixelSize + leviathan.Location.X, (cell.Location.Y) * leviathan.PixelSize + leviathan.Location.Y, leviathan.PixelSize, leviathan.PixelSize);
						}
					}
					else
						dellistLeviathan.Add(leviathan);
				}
				foreach (var del in dellistLeviathan)
					game.Leviathans.Remove(del);






				var dellistPlankton = new List<Plankton>();

				foreach (var plankton in game.Planktons)
                {
					plankton.Location.X += plankton.DirectionX + game.DirectionShiftX;
					plankton.Location.Y += plankton.DirectionY + game.DirectionShiftY;

					if (-3000 < plankton.Location.Y && plankton.Location.Y < 3000 && -3000 < plankton.Location.X && plankton.Location.X < 3000)
                    {
						foreach (var cell in plankton.Body)
						{
							args.Graphics.FillRectangle(new SolidBrush(cell.Color), (cell.Location.X) * plankton.PixelSize + plankton.Location.X, (cell.Location.Y) * plankton.PixelSize + plankton.Location.Y, plankton.PixelSize, plankton.PixelSize);
						}	
					}
					else
						dellistPlankton.Add(plankton);
				}
				foreach (var del in dellistPlankton)
					game.Planktons.Remove(del);


				var dellistFish = new List<Fish>();

				foreach(var fish in game.Fishes)
				{
					fish.Location.X += fish.DirectionX + game.DirectionShiftX; 
					fish.Location.Y += fish.DirectionY + game.DirectionShiftY;

					if (-3000 < fish.Location.Y && fish.Location.Y < 3000 && -3000 < fish.Location.X && fish.Location.X < 3000)
					{
						foreach (var cell in fish.Body)
						{
							args.Graphics.FillRectangle(new SolidBrush(cell.Color), (cell.Location.X) * fish.PixelSize + fish.Location.X, (cell.Location.Y) * fish.PixelSize + fish.Location.Y, fish.PixelSize, fish.PixelSize);
						}
					}
					else
						dellistFish.Add(fish);
				}
				foreach (var del in dellistFish)
					game.Fishes.Remove(del);

				game.DirectionShiftX = 0;
				game.DirectionShiftY = 0;
			};
		}

        public static void Main()
		{
			Application.Run(new View());
		}



	}
}