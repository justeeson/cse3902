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
using SuperMario.Game_Object_Classes;

namespace SuperMario.Controller
{
    public class MouseController : IController
    {
        private Dictionary<String, ICommand> controllerMappings;
        private MouseState mouseState;
        private ICommand fireCommand;

        public MouseController()
        {
            controllerMappings = new Dictionary<String, ICommand>();
        }

        public void RegisterCommand(String button, ICommand command)
        {
            controllerMappings.Add(button, command);
        }

        public void Update()
        {          
            mouseState = Game1.GetInstance.MouseState;
            if ((mouseState.LeftButton == ButtonState.Pressed) && (Game1.GetInstance.MouseControl))
            {
                controllerMappings["LeftMouseClick"].Execute();
                fireCommand = new MarioFireCommand(Game1.GetInstance);
                fireCommand.Execute();
            }

            if ((mouseState.RightButton == ButtonState.Pressed) && (Game1.GetInstance.MouseControl))
            {
                controllerMappings["RightMouseClick"].Execute();
            }

            if ((mouseState.MiddleButton == ButtonState.Pressed) && (Game1.GetInstance.MouseControl))
            {
                controllerMappings["MiddleMouseClick"].Execute();
            }
        }
    }
}
