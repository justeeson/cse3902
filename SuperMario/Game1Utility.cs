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
        public static SoundEffect coinSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("coinSoundEffect");
        public static SoundEffect marioPowerUpSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("marioPowerUpSoundEffect");
        public static SoundEffect greenMushroomSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("1UPSoundEffect");
        public static SoundEffect deathSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("deathSoundEffect");
        public static Song starMusic = Game1.GetInstance().Content.Load<Song>("starMusic");
    }
}
