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
    public class FireMushroom : IItem
    {
        public ISprite Sprite { get; set; }
        public bool movingLeft { get; set; }
        public bool isFalling { get; set; }
        public Game1 MyGame { get; set; }
        public bool hasBeenUsed { get; set; }
        public Vector2 Location { get; set; }

        public FireMushroom(Game1 game, Vector2 location)
        {
            movingLeft = false;
            MyGame = game;
            Sprite = SpriteFactory.CreateFireMushroom();
            MyGame.sprite = Sprite;
            hasBeenUsed = false;
            isFalling = true;
            Location = location;
        }

        public void Update(GameTime GameTime)
        {
            if (Location.X - Camera.cameraPositionX < 0)
            {
                movingLeft = !movingLeft;
            }
            else if (Location.X - Camera.cameraPositionX > MyGame.GraphicsDevice.Viewport.Width - Sprite.Area(Location).Width)
            {
                movingLeft = !movingLeft;
            }

            if (movingLeft)
                Location = new Vector2(Location.X - 3, Location.Y);
            else
                Location = new Vector2(Location.X + 3, Location.Y);

            if (isFalling)
            {
                Location = new Vector2(Location.X, Location.Y + 3);
            }

            Sprite.Update(GameTime);
        }
        public Rectangle Area()
        {
            if (hasBeenUsed)
                return new Rectangle(0, 0, 0, 0);
            else
                return Sprite.Area(Location);
        }
        public void UpdateCollision()
        {
            this.Sprite = new CleanSprite(SpriteFactory.fireMushroomTexture);
            //MyGame.store.arrayOfSprites[3] = Sprite;
            MyGame.MarioSprite.MarioFireState();
            hasBeenUsed = true;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.cameraPositionX, Location.Y));
        }
    }
}
