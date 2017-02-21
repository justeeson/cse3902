using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;

namespace SuperMario
{
    class ClearSprite : ISprite
    {
        private Texture2D texture;
        public ClearSprite(Texture2D text)
        {
            this.texture = text;
        }
      

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
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
        public Rectangle Area()
        {
           
            return new Rectangle();
        }
        public void CollisionSprite()
        {

        }
    }
}
