﻿using Microsoft.Xna.Framework;
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
        public static SoundEffect GoombaStompSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("goombaStompSoundEffect");
        public static SoundEffect BreakableBrickSmashSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("breakableBrickSmashSoundEffect");
        public static SoundEffect MarioJumpSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("marioJumpSoundEffect");
        public static SoundEffect BreakableBrickBumpSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("breakableBrickBumpSoundEffect");
        public static SoundEffect CoinSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("coinSoundEffect");
        public static SoundEffect MarioPowerUpSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("marioPowerUpSoundEffect");
        public static SoundEffect GreenMushroomSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("1UPSoundEffect");
        public static SoundEffect DeathSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("deathSoundEffect");
        public static float RegularVolume = 0.42f;
        public static float HigherVolume = 0.8f;
        public static Song StarMusic = Game1.GetInstance().Content.Load<Song>("starMusic");
        public static int finalLevelLocation = 6350;
        public static int cameraOffset = 350;
        public static int fireballMaxDistance = 500;
        public static int maxValueY = 400;
    }
}
