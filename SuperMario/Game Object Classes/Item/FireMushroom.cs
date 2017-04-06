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
    public class FireMushroom : IItem
    {
        public ISprite Sprite { get; set; }
        public bool MovingLeft { get; set; }
        public bool IsFalling { get; set; }
        public Game1 MyGame { get; set; }
        public bool HasBeenUsed { get; set; }
        public Vector2 Location { get; set; }

        public FireMushroom(Game1 game, Vector2 location)
        {
            MovingLeft = false;
            MyGame = game;
            Sprite = SpriteFactory.CreateFireMushroom();
            MyGame.Sprite = Sprite;
            HasBeenUsed = false;
            IsFalling = true;
            Location = location;
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
            Game1Utility.GreenMushroomSoundEffect.Play();
            this.Sprite = new CleanSprite(SpriteFactory.fireMushroomTexture);
            MyGame.MarioSprite.MarioFireState();
            HasBeenUsed = true;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.cameraPositionX, Location.Y));
        }
    }
}
