using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        public static SoundEffect goombaStompSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("goombaStompSoundEffect");
        public static SoundEffect breakableBrickSmashSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("breakableBrickSmashSoundEffect");
        public static SoundEffect marioJumpSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("marioJumpSoundEffect");
        public static SoundEffect breakableBrickBumpSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("breakableBrickBumpSoundEffect");
    }
}
