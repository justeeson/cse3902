using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMario.Interfaces;
using SuperMario.Command;

namespace SuperMario.Controller
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {  
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

                foreach (Keys key in pressedKeys)
                {
                    if (Game1.validKeys.Contains(key))
                 {
                      controllerMappings[key].Execute();
                 }
                }
        }
    }
}
