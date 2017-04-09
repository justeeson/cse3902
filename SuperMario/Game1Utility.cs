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
        public static Song StarMusic;
        public static SoundEffect GoombaStompSoundEffect;
        public static SoundEffect BreakableBrickSmashSoundEffect;
        public static SoundEffect MarioJumpSoundEffect;
        public static SoundEffect BreakableBrickBumpSoundEffect;
        public static SoundEffect CoinSoundEffect;
        public static SoundEffect MarioPowerUpSoundEffect;
        public static SoundEffect GreenMushroomSoundEffect;
        public static SoundEffect DeathSoundEffect;
        public static SoundEffect FireworksSoundEffect;
        public static SoundEffect GameOverSoundEffect;
        public static float RegularVolume;
        public static float HigherVolume;
        public static int FinalLevelLocation;
        public static int CameraOffset;
        public static int FireballMaxDistance;
        public static int MaxValueY;
        public static int MovingLeftOffset;
        public static int MarioTotalLives;

        public static void Initialize()
        {
            RegularVolume = 0.42f;
            HigherVolume = 0.8f;
            FinalLevelLocation = 6350;
            CameraOffset = 350;
            FireballMaxDistance = 500;
            MaxValueY = 400;
            MovingLeftOffset = -400;
            MarioTotalLives = 3;
         }
        public static void LoadContent()
        {
             StarMusic = Game1.GetInstance().Content.Load<Song>("StarMusic");
             GoombaStompSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("goombaStompSoundEffect");
             BreakableBrickSmashSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("breakableBrickSmashSoundEffect");
             MarioJumpSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("marioJumpSoundEffect");
             BreakableBrickBumpSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("breakableBrickBumpSoundEffect");
             CoinSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("coinSoundEffect");
             MarioPowerUpSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("marioPowerUpSoundEffect");
             GreenMushroomSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("1UPSoundEffect");
             DeathSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("deathSoundEffect");
             FireworksSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("FireworksSoundEffect");
             GameOverSoundEffect = Game1.GetInstance().Content.Load<SoundEffect>("GameOverSoundEffect");
        }
    }
}
