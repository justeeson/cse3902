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
        public static Song StarMusic
        { get; set; }
        public static SoundEffect GoombaStompSoundEffect
        { get; set; }
        public static SoundEffect BreakableBrickSmashSoundEffect
        { get; set; }
        public static SoundEffect MarioJumpSoundEffect
        { get; set; }
        public static SoundEffect BreakableBrickBumpSoundEffect
        { get; set; }
        public static SoundEffect CoinSoundEffect
        { get; set; }
        public static SoundEffect MarioPowerUpSoundEffect
        { get; set; }
        public static SoundEffect GreenMushroomSoundEffect
        { get; set; }
        public static SoundEffect DeathSoundEffect
        { get; set; }
        public static SoundEffect FireworksSoundEffect
        { get; set; }
        public static SoundEffect GameOverSoundEffect
        { get; set; }
        public static float RegularVolume
        { get; set; }
        public static float HigherVolume
        { get; set; }
        public static int FinalLevelLocation
        { get; set; }
        public static int CameraOffset
        { get; set; }
        public static int FireballMaxDistance
        { get; set; }
        public static int MaxValueY
        { get; set; }
        public static int MovingLeftOffset
        { get; set; }
        public static int MarioTotalLives
        { get; set; }

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
             StarMusic = Game1.GetInstance.Content.Load<Song>("StarMusic");
             GoombaStompSoundEffect = Game1.GetInstance.Content.Load<SoundEffect>("goombaStompSoundEffect");
             BreakableBrickSmashSoundEffect = Game1.GetInstance.Content.Load<SoundEffect>("breakableBrickSmashSoundEffect");
             MarioJumpSoundEffect = Game1.GetInstance.Content.Load<SoundEffect>("marioJumpSoundEffect");
             BreakableBrickBumpSoundEffect = Game1.GetInstance.Content.Load<SoundEffect>("breakableBrickBumpSoundEffect");
             CoinSoundEffect = Game1.GetInstance.Content.Load<SoundEffect>("coinSoundEffect");
             MarioPowerUpSoundEffect = Game1.GetInstance.Content.Load<SoundEffect>("marioPowerUpSoundEffect");
             GreenMushroomSoundEffect = Game1.GetInstance.Content.Load<SoundEffect>("1UPSoundEffect");
             DeathSoundEffect = Game1.GetInstance.Content.Load<SoundEffect>("deathSoundEffect");
             FireworksSoundEffect = Game1.GetInstance.Content.Load<SoundEffect>("FireworksSoundEffect");
             GameOverSoundEffect = Game1.GetInstance.Content.Load<SoundEffect>("GameOverSoundEffect");
        }
    }
}
