using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.MarioClass;
using Microsoft.Xna.Framework.Media;

namespace SuperMario
{
    public class GodMushroom : IItem
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public bool MovingLeft { get; set; }
        public bool IsFalling { get; set; }
        public bool HasBeenUsed { get; set; }
        public Vector2 Location { get; set; }

        public GodMushroom(Game1 game, Vector2 location)
        {
            MovingLeft = false;
            MyGame = game;
            Sprite = SpriteFactory.CreateGodMushroom();
            IsFalling = true;
            MyGame.Sprite = Sprite;
            HasBeenUsed = false;
            this.Location = location;
            
        }

        public void Update(GameTime gameTime)
        {
            if (MovingLeft)
                Location = new Vector2(Location.X - 4, Location.Y);
            else
                Location = new Vector2(Location.X + 4, Location.Y);

            if (IsFalling)
            {
                Location = new Vector2(Location.X, Location.Y + 3);
            }

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
            Game1Utility.GodMushroomSoundEffect.Play();
            this.Sprite = new CleanSprite(SpriteFactory.godMushroomTexture);
            HasBeenUsed = true;
            Mario.GodStatus = true;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.CameraPositionX, Location.Y));
        }
    }
}
