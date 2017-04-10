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
        private Dictionary<Buttons, ICommand> controllerMappings;
        private ICommand fireCommand;

        public GamepadController()
        {
            controllerMappings = new Dictionary<Buttons, ICommand>();
        }
        public void RegisterCommand(Buttons button, ICommand command)
        {
            controllerMappings.Add(button, command);
        }
        public void Update(GameTime GameTime)
        {
            GamePadState currentState = GamePad.GetState(PlayerIndex.One);
            
            if (currentState.IsConnected && currentState.IsButtonDown(Buttons.LeftThumbstickLeft))
            {
                controllerMappings[Buttons.LeftThumbstickLeft].Execute();
            }

            else if (currentState.IsConnected && currentState.IsButtonDown(Buttons.LeftThumbstickRight))
            {
                controllerMappings[Buttons.LeftThumbstickRight].Execute();
            }

            else if (currentState.IsConnected && currentState.IsButtonDown(Buttons.LeftThumbstickDown))
            {
                controllerMappings[Buttons.LeftThumbstickDown].Execute();
            }

            if (currentState.IsConnected && currentState.IsButtonDown(Buttons.A))
            {
                controllerMappings[Buttons.A].Execute();
            }

            if (currentState.IsConnected && currentState.IsButtonDown(Buttons.B))
            {
                controllerMappings[Buttons.B].Execute();
            }
            if (currentState.IsConnected && currentState.IsButtonDown(Buttons.B))
            {
                fireCommand = new MarioFireCommand(Game1.GetInstance());
                fireCommand.Execute();
            }
        }

    }
}

