using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public class Star : IItem
    {
        public ISprite Sprite { get; set; }
        public bool movingLeft { get; set; }
        public bool isFalling { get; set; }
        public Game1 MyGame { get; set; }
        public bool hasBeenUsed { get; set; }
        public Vector2 Location { get; set; }
        private float locationY;
        private float yVelocity;
        private float yAcceleration;


        public Star(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreateStar();
            MyGame.sprite = Sprite;
            hasBeenUsed = false;
            movingLeft = false;
            locationY = 0;
            yVelocity = 18;
            yAcceleration = -1;
            isFalling = true;
            this.Location = location;
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
                Location = new Vector2(Location.X - 4, Location.Y);
            else
                Location = new Vector2(Location.X + 4, Location.Y);

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
            this.Sprite = new CleanSprite(SpriteFactory.starTexture);
            hasBeenUsed = true;
            //MyGame.store.arrayOfSprites[6] = Sprite;
            Mario.StarPowerUp();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.cameraPositionX, Location.Y));

        }
    }
}
