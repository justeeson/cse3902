﻿using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
   public class BreakableCurlyBrick : IBlock
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Rectangle Area { get; set; }
        public Vector2 Location { get; set; }

        public BreakableCurlyBrick(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreateBreakableCurlyBrick();
            MyGame.Sprite = Sprite;
            this.Location = location;
        }

        public void BrickToDisappear()
        {
        }
        public void HiddenToUsed()
        {
        }
        public void BecomeUsed()
        {
        }

        public void Update(GameTime GameTime)
        {
            Sprite.Update(GameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location = new Vector2(Location.X - Camera.cameraPositionX, Location.Y);
            Sprite.Draw(spriteBatch, location);
        }
    }
}
