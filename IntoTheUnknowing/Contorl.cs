using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntoTheUnknowing
{

    class ContorlITU
    {
        public char Key;
        public ContorlITU(char key) { Key = key; }

        public void UpdateConfig(Model.Game game, Model.Planet planet)
        {

            if (Key == 'r')
            {
                if (game.Submarine.PositionMotors == Model.PositionMotors.Down)
                    game.Submarine.PositionMotors = Model.PositionMotors.Up;
                else
                    game.Submarine.PositionMotors = Model.PositionMotors.Down;
            }

            if (Key == 'q')
            {
                if (game.Submarine.Type == Model.TypeSubmarine.Submarine)
                    game.Submarine.Type = Model.TypeSubmarine.Submarinera;
                else
                    game.Submarine.Type = Model.TypeSubmarine.Submarine;
            }

            if (Key == 'w')//up
            {
                if (game.Submarine.Type == Model.TypeSubmarine.Submarine)
                {
                    game.Depth -= 10;
                    planet.DepthDif = 1;
                    game.DirectionShiftY = 10;
                }
                else
                {
                    if (game.Submarine.PositionMotors == Model.PositionMotors.Up)
                    {
                        game.Depth -= 20;
                        planet.DepthDif = 1;
                        game.DirectionShiftY = 20;
                    }
                    else
                    {
                        game.Depth -= 20;
                        game.DirectionShiftX = -20;
                    }
                   
                    View.flagForSubmarinera = true;
                }
                game.Submarine.IsSubmarineSail = true;
                game.Temperature += new Random().Next(2);
                
            }

            if (Key == 's')//down
            {
                if (game.Submarine.Type == Model.TypeSubmarine.Submarine)
                {
                    game.DirectionShiftY = -10;
                    planet.DepthDif = 2;
                    game.Depth += 10;
                }
                else
                {
                    if (game.Submarine.PositionMotors == Model.PositionMotors.Up)
                    {
                        game.DirectionShiftY = -20;
                        planet.DepthDif = 2;
                        game.Depth += 20;
                    }
                    else
                    {
                        game.DirectionShiftX = 20;
                        game.Distance -= 20;
                    }
                    View.flagForSubmarinera = false;
                }
              
                if (game.Temperature < 250)
                    game.Temperature -= new Random().Next(2);
                game.Submarine.IsSubmarineSail = true;
                
            }
                
            if (Key == 'a')//left
            {
                if (game.Submarine.Type == Model.TypeSubmarine.Submarine)
                {
                    game.DirectionShiftX = 10;
                    game.Distance -= 10;
                    planet.DepthDif = 0;
                    game.Submarine.IsSubmarineSail = true;
                }
            }
            if (Key == 'd')//right
            {
                if (game.Submarine.Type == Model.TypeSubmarine.Submarine)
                {
                    game.DirectionShiftX = -10;
                    game.Distance += 10;
                    planet.DepthDif = 0;
                    game.Submarine.IsSubmarineSail = true;
                }
            }
 

        }
    }
}
