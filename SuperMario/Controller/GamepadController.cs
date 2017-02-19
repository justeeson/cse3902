using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMario.Interfaces;

namespace SuperMario.Controller
{
    public class GamepadController : IController
    {
        private Dictionary<Buttons, ICommand> controllerMappings;

        public GamepadController()
        {
            controllerMappings = new Dictionary<Buttons, ICommand>();
        }
        public void RegisterCommand(Buttons botton, ICommand command)
        {
            controllerMappings.Add(botton, command);
        }
        public void Update(GameTime gameTime)
        {
            GamePadState currentState = GamePad.GetState(PlayerIndex.One);
            if (currentState.IsConnected && currentState.Buttons.Start == ButtonState.Pressed)
            {
                controllerMappings[Buttons.Start].Execute();
            }
            if (currentState.IsConnected && currentState.Buttons.A == ButtonState.Pressed)
            {
                controllerMappings[Buttons.A].Execute();
            }
            if (currentState.IsConnected && currentState.Buttons.B == ButtonState.Pressed)
            {
                controllerMappings[Buttons.B].Execute();
            }
            if (currentState.IsConnected && currentState.Buttons.X == ButtonState.Pressed)
            {
                controllerMappings[Buttons.X].Execute();
            }
            if (currentState.IsConnected && currentState.Buttons.Y == ButtonState.Pressed)
            {
                controllerMappings[Buttons.Y].Execute();
            }
        }
    }
}
