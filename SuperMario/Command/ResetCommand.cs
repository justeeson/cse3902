using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMario.Interfaces;
using SuperMario.Game_Object_Classes;
using Microsoft.Xna.Framework.Media;

namespace SuperMario.Command
{
    class ResetCommand : ICommand
    {
        private Game1 MyGame;

        public ResetCommand(Game1 game)
        {
            MyGame = game;
        }
        public void Execute()
        {
            MyGame.MarioSprite.Reset();
            MyGame.World = new WorldManager(MyGame);
            MyGame.World.Load();
            MyGame.PlayerStat.Reset();
            Camera.CameraPositionX = 0;
            MyGame.CameraPointer.disableCamera = false;
            MediaPlayer.Volume = Game1Utility.RegularVolume;
            MediaPlayer.Play(Game1.GetInstance().BackgroundMusic);
        }
    }
}
