using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMario.Command;
using SuperMario.Controller;
using SuperMario.Game_Object_Classes;
using SuperMario.Interfaces;
using SuperMario.MarioClass;
using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
namespace SuperMario.Game_Object_Classes
{
    class ValidKeys 
    {
        private ArrayList result;
        private static ValidKeys instance = new ValidKeys();
        private ValidKeys()
        {

        }

        public static ValidKeys Instance
        {
            get
            {
                return instance;
            }
        }
        public ArrayList ArrayOfKeys()
        {
            result = new ArrayList();
            result.Add(Keys.Left);
            result.Add(Keys.Right);
            result.Add(Keys.Up);
            result.Add(Keys.Down);
            result.Add(Keys.Y);
            result.Add(Keys.U);
            result.Add(Keys.I);
            result.Add(Keys.O);
            result.Add(Keys.Q);
            result.Add(Keys.R);
            result.Add(Keys.Z);
            result.Add(Keys.X);
            result.Add(Keys.C);
            return result;
        }
    }
}
