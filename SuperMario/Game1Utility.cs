using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SuperMario.Command;
using SuperMario.Controller;
using SuperMario.Game_Object_Classes;
using SuperMario.Interfaces;
using SuperMario.Levels;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SuperMario
{
    public static class Game1Utility 
    {
        public static Song goombaStompSoundEffect = Game1.GetInstance().Content.Load<Song>("goombaStompSoundEffect");
        public static Song breakableBrickSoundEffect = Game1.GetInstance().Content.Load<Song>("breakableBrickSoundEffect");
    }
}
