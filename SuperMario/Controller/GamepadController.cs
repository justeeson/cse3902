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
    public class GamepadController : IController
    {
        private ICommand command;
        private Dictionary<Buttons, ICommand> controllerMappings;

        public GamepadController()
        {
            controllerMappings = new Dictionary<Buttons, ICommand>();
        }
        public void RegisterCommand(Buttons button, ICommand command)
        {
            controllerMappings.Add(button, command);
        }
        public void Update(GameTime gameTime)
        {
            GamePadState currentState = GamePad.GetState(PlayerIndex.One);
            if (currentState.IsConnected &&
                (currentState.IsButtonDown(Buttons.LeftThumbstickLeft) && currentState.IsButtonDown(Buttons.LeftThumbstickUp)))
            {
              //  command = new MarioMoveUpLeftCommand(Game1.self);
                command.Execute();
            }

            else if (currentState.IsConnected &&
                (currentState.IsButtonDown(Buttons.LeftThumbstickRight) && currentState.IsButtonDown(Buttons.LeftThumbstickUp)))
            {
              //  command = new MarioMoveUpRightCommand(Game1.self);
                command.Execute();
            }

            else if (currentState.IsConnected &&
                (currentState.IsButtonDown(Buttons.LeftThumbstickLeft) && currentState.IsButtonDown(Buttons.LeftThumbstickDown)))
            {
             //   command = new MarioMoveDownLeftCommand(Game1.self);
                command.Execute();
            }

            else if (currentState.IsConnected &&
              (currentState.IsButtonDown(Buttons.LeftThumbstickRight) && currentState.IsButtonDown(Buttons.LeftThumbstickDown)))
            {
               // command = new MarioMoveDownRightCommand(Game1.self);
                command.Execute();
            }

            else if (currentState.IsConnected && currentState.IsButtonDown(Buttons.LeftThumbstickLeft))
            {
                controllerMappings[Buttons.LeftThumbstickLeft].Execute();
            }

            else if (currentState.IsConnected && currentState.IsButtonDown(Buttons.LeftThumbstickRight))
            {
                controllerMappings[Buttons.LeftThumbstickRight].Execute();
            }

            else if (currentState.IsConnected && currentState.IsButtonDown(Buttons.LeftThumbstickUp))
            {
                controllerMappings[Buttons.LeftThumbstickUp].Execute();
            }

            else if (currentState.IsConnected && currentState.IsButtonDown(Buttons.LeftThumbstickDown))
            {
                controllerMappings[Buttons.LeftThumbstickDown].Execute();
            }

            else if (currentState.IsConnected && currentState.Buttons.A == ButtonState.Pressed)
            {
                controllerMappings[Buttons.A].Execute();
            }
            else if (currentState.IsConnected && currentState.Buttons.B == ButtonState.Pressed)
            {
                controllerMappings[Buttons.B].Execute();
            }
            else if (currentState.IsConnected && currentState.Buttons.X == ButtonState.Pressed)
            {
                controllerMappings[Buttons.X].Execute();
            }
        }

    }
}

