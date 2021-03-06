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
    public class EnergyDrink : IItem
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public bool MovingLeft { get; set; }
        public bool IsFalling { get; set; }
        public bool HasBeenUsed{ get; set; }
        public Vector2 Location { get; set; }

        public EnergyDrink(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreateEnergyDrink();
            MyGame.Sprite = Sprite;
            HasBeenUsed = false;
            this.Location = location;
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public Rectangle Area()
        {
            if (HasBeenUsed)
                return new Rectangle(0, 0, 0, 0);
            else
                return Sprite.Area(Location);
        }
        public void UpdateCollision()
        {
            Game1Utility.EnergyDrinkSoundEffect.Play();
            this.Sprite = new CleanSprite(SpriteFactory.energyDrinkTexture);
            Mario.EnergyStatus = 2;
            HasBeenUsed = true;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.CameraPositionX, Location.Y));
        }
    }
}
