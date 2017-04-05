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
    public class BreakableHorizontalBrick : IBlock
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Rectangle Area { get; set; }
        public Vector2 Location { get; set; }
        private int timer=0;
        private bool destroyed = false;
        public BreakableHorizontalBrick(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreateBreakableHorizonalBrick();
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
            if (MyGame.MarioSprite.StateMachine.MarioMode == (int)MarioStateMachine.MarioModes.Small)
            {
                Sprite = new BreakableHorizontalBrickForSmallMarioSprite(SpriteFactory.brickableHorizontalBrickTexture, 4, 8);
                timer = 1;
            }
            else
            {
                MediaPlayer.Play(Game1Utility.breakableBrickSoundEffect);
                Sprite = new CleanSprite(SpriteFactory.brickableHorizontalBrickTexture);
                destroyed = true;
            }
            
        }
        public void Update(GameTime GameTime)
        {
            if (timer == 0 && !destroyed)
            {
                Sprite = new BreakableHorizontalBrickSprite(SpriteFactory.brickableHorizontalBrickTexture,4,8);

            }
            Sprite.Update(GameTime);
            timer = 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location = new Vector2(Location.X - Camera.cameraPositionX, Location.Y);
            Sprite.Draw(spriteBatch, location);
        }
    }
}
