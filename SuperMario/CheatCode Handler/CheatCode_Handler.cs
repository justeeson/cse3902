using Microsoft.Xna.Framework.Input;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.CheatCode_Handler
{
    public class CheatCodeHandler
    {
        Game1 mygame;
        List<Keys> inputList = new List<Keys>();

        Dictionary<List<Keys>, ICommand> cheatMaps;

        List<Keys> fireCheat = new List<Keys>();
        List<Keys> bigCheat = new List<Keys>();

        public CheatCodeHandler(Game1 game)
        {
            mygame = game;
            fireCheat.Add(Keys.Up);
            fireCheat.Add(Keys.Up);
            fireCheat.Add(Keys.Down);
            fireCheat.Add(Keys.Down);
            fireCheat.Add(Keys.Left);
            fireCheat.Add(Keys.Right);
            fireCheat.Add(Keys.Left);
            fireCheat.Add(Keys.Right);

            bigCheat.Add(Keys.Up);
            bigCheat.Add(Keys.Left);
            bigCheat.Add(Keys.Down);
            bigCheat.Add(Keys.Right);
            bigCheat.Add(Keys.Up);
            bigCheat.Add(Keys.Left);
            bigCheat.Add(Keys.Down);
            bigCheat.Add(Keys.Right);
        }

        public void Update(KeyboardState oldKeyboardState, KeyboardState newKeyboardState)
        {
            Keys[] pressedKeys = oldKeyboardState.GetPressedKeys();
            foreach (Keys key in pressedKeys)
            {
                if (newKeyboardState.IsKeyUp(key))
                {
                    if(inputList.Count > 9)
                    {
                        inputList.RemoveAt(0);
                        inputList.Add(key);
                    }
                    else
                    {
                        inputList.Add(key);
                    }                    
                } 
            }

            if (executeCheat(inputList, fireCheat))
                mygame.MarioSprite.MarioFireState();

            if (executeCheat(inputList, bigCheat))
                mygame.MarioSprite.MarioBigState();

        }

        private Boolean executeCheat(List<Keys> inputs, List<Keys> cheat)
        {
            if (inputs.Count >= cheat.Count)
            {
                for (int i = 0; i < cheat.Count; i++)
                {
                    if (inputs.ElementAt(i) != cheat.ElementAt(i))
                        return false;
                }
            }
            else
                return false;

            return true;
        }

    }
}
