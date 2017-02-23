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
        private ICommand command;
        private Dictionary<Keys, ICommand> controllerMappings;

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update(GameTime gameTime)
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            if ((pressedKeys.Contains(Keys.Right) && pressedKeys.Contains(Keys.Up))||(pressedKeys.Contains(Keys.D) && pressedKeys.Contains(Keys.W)))
            {
                if (!(command is MarioMoveUpRightCommand))
                {
                    command = new MarioMoveUpRightCommand(Game1.self);
                }
                command.Execute();
            }
            else if ((pressedKeys.Contains(Keys.Left) && pressedKeys.Contains(Keys.Up))|| (pressedKeys.Contains(Keys.A) && pressedKeys.Contains(Keys.W)))
            {
                if (!(command is MarioMoveUpLeftCommand))
                {
                    command = new MarioMoveUpLeftCommand(Game1.self);
                }

                command.Execute();
            }
            else if ((pressedKeys.Contains(Keys.Right) && pressedKeys.Contains(Keys.Down))||(pressedKeys.Contains(Keys.D) && pressedKeys.Contains(Keys.S)))
            {
                if (!(command is MarioMoveDownRightCommand))
                {
                    command = new MarioMoveDownRightCommand(Game1.self);
                }
                command.Execute();
            }
            else if ((pressedKeys.Contains(Keys.Left) && pressedKeys.Contains(Keys.Down))||(pressedKeys.Contains(Keys.A) && pressedKeys.Contains(Keys.S)))
            {
                if (!(command is MarioMoveDownLeftCommand))
                {
                    command = new MarioMoveDownLeftCommand(Game1.self);
                }
                command.Execute();
            }
            else
            {
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
}
