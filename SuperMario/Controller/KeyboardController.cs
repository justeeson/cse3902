using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMario.Interfaces;
using SuperMario.Command;
using SuperMario.MarioClass;

namespace SuperMario.Controller
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private ICommand command;
        private IMario mario;

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            mario = Game1.GetInstance().MarioSprite;
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update(GameTime GameTime)
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();          
                foreach (Keys key in pressedKeys)
                {
                    if(key == Keys.X)
                     {
                        command = new MarioFireCommand(Game1.GetInstance());
                        command.Execute();
                     }
                    if (Game1.validKeys.Contains(key))
                    {
                        controllerMappings[key].Execute();
                    }
                }
            
        }
    }
}
