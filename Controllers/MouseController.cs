using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using LegendofZelda.Interfaces;
using System.Diagnostics;
using Commands;

namespace Controllers
{

    public class MouseController : IController
    {
        private Vector2 center;
        private Game1 myGame;
        private ButtonState previousButtonState;
        public MouseController(Game1 game, Vector2 vector)
        {
            center = vector;
            myGame = game;
            previousButtonState = ButtonState.Pressed;
        }

        public void Update()
        {
            MouseState state = Mouse.GetState();

            if (previousButtonState != ButtonState.Pressed) 
            {
                if (state.LeftButton == ButtonState.Pressed)
                {
                    if (state.X < center.X)
                    {
                        new PreviousRoomCommand(myGame).Execute();
                    }
                    else if (state.X > center.X)
                    {
                        new NextRoomCommand(myGame).Execute();
                    }
                }

            }
            previousButtonState = state.LeftButton;

        }

           
    }
    
}


