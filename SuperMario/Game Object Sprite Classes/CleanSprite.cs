using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class CleanSprite : ISprite
    {
        private Texture2D texture;

        public CleanSprite(Texture2D item)
        {
            this.texture = item;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 0, 0);
            Rectangle destinationRectangle = new Rectangle(0, 0, 0, 0);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void CollisionSprite()
        { }

        public Rectangle Area(Vector2 location)
        {
            return new Rectangle();

        }

    }
}
