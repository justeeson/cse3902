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
    public class HiddenBrick : IBlock
    {
        public ISprite Sprite { get; set; }
        public Game1 myGame { get; set; }
        public Rectangle Area { get; set; }
        public HiddenBrick(Game1 game)
        {
            myGame = game;
            Sprite = SpriteFactory.CreateSolidBrickWithCrews2();
            myGame.sprite = Sprite;
        }
        public void BrickToDisappear()
        {
        }
        public void HiddenToUsed()
        {
            new QuestionMarkBrickToUsed(myGame);
        }
        public void BecomeUsed()
        {
        }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            throw new NotImplementedException();
        }
    }
}
