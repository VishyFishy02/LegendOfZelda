using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using LegendofZelda.Interfaces;
using LegendofZelda;
using GameStates;
using System.Linq;
using System.Diagnostics;

namespace Controllers
{
    public class KeyboardController : IController
	{
		private Dictionary<Keys, ICommand> keyBindings = new();
		private ICommand noInput;
		private ICommand previousCommand;
        private KeyboardState kstate;


        // Pass the noInput command into the keyboard controller in Game1's initialize function
        public KeyboardController(ICommand command) 
		{
			noInput = command;
			previousCommand = command;
		}

		public void AddCommand(Keys key, ICommand command)
		{
			keyBindings.Add(key, command);
		}

		public void Update()
		{
            
            kstate = Keyboard.GetState();

            if (kstate.GetPressedKeyCount() == 0)
            {
                noInput.Execute();
                previousCommand = noInput;
            }
            else if (kstate.GetPressedKeyCount() == 1)
            {
                // Loop through the bindings. If a key is down, execute its command.
                if (Link.Instance.isDamaged)
                {
                    if (Link.Instance.isDamagedCounter > 10)
                    {
                        handleInput();
                    }
                } else
                {
                    handleInput();
                }
            }
            else
            {
                if (kstate.GetPressedKeys().Contains(Keys.H))
                {
                    handleInput();
                }
            }
        }			
		

        private void handleInput()
        {
            foreach (Keys key in keyBindings.Keys)
            {
                if (kstate.IsKeyDown(key))
                {
                    Type typeField = previousCommand.GetType();
                    if (!Link.Instance.isDamaged)
                    {


                        if (typeField != keyBindings[key].GetType())
                        {
                            keyBindings[key].Execute();
                        }
                    } else
                    {
                        keyBindings[key].Execute();
                    }
                    previousCommand = keyBindings[key];
                }
            }
        }
    }
    
}


