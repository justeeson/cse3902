using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace SuperMario
{
    public class Star : IItem
    {
        public ISprite Sprite { get; set; }
        public bool MovingLeft { get; set; }
        public bool IsFalling { get; set; }
        public Game1 MyGame { get; set; }
        public bool HasBeenUsed { get; set; }
        public Vector2 Location { get; set; }


        public Star(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreateStar();
            MyGame.Sprite = Sprite;
            HasBeenUsed = false;
            MovingLeft = false;
            IsFalling = true;
            this.Location = location;
        }

        public void Update(GameTime GameTime)
        {
            if (Location.X - Camera.cameraPositionX < 0)
            {
                MovingLeft = !MovingLeft;
            }
            else if (Location.X - Camera.cameraPositionX > MyGame.GraphicsDevice.Viewport.Width - Sprite.Area(Location).Width)
            {
                MovingLeft = !MovingLeft;
            }

            if (MovingLeft)
                Location = new Vector2(Location.X - 3, Location.Y);
            else
                Location = new Vector2(Location.X + 3, Location.Y);

            if (IsFalling)
            {
                Location = new Vector2(Location.X, Location.Y + 3);
            }

            Sprite.Update(GameTime);
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
            MediaPlayer.Play(Game1Utility.starMusic);
            MediaPlayer.Volume = 0.8f;
            this.Sprite = new CleanSprite(SpriteFactory.starTexture);
            HasBeenUsed = true;
            //MyGame.store.arrayOfSprites[6] = Sprite;
            Mario.StarPowerUp();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.cameraPositionX, Location.Y));

        }
    }
}
