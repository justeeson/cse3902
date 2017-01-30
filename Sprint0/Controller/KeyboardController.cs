using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
using Sprint0.Command;

namespace Sprint0.Controller
{
    // This file is used to map Keyboard keys to commands, if detect a key press then execute the commands.
    // This file is modified from http://web.cse.ohio-state.edu/~boggus/3902/slides/KeyboardController.cs
    public class KeyboardController : IController
    {   //declare map of key globally
        private Dictionary<Keys, ICommand> controllerMappings;

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {   //add keys to the map
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                controllerMappings[key].Execute();

            }
        }
    }
}
