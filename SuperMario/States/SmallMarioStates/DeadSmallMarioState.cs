using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SuperMario.Interfaces;
using SuperMario.Command;
using Microsoft.Xna.Framework.Media;
using SuperMario.MarioClass;

namespace SuperMario.Sprites
{
    public class DeadSmallMarioState : IMarioState
    {
        private Mario mario;
        private int currentFrame;
        private int flashStatus;
        private bool playSoundEffect;
        private int resetTimer;
        private ICommand command;
        public DeadSmallMarioState(Mario mario)
        {
            this.mario = mario;
            currentFrame = 0;
            flashStatus = 0;
            resetTimer = 0;
            playSoundEffect = false;
            command = new ResetCommand(Game1.GetInstance);           
        }

        public void Update(GameTime GameTime)
        {
            if(!playSoundEffect)
            {
                MediaPlayer.Stop();
                Game1Utility.DeathSoundEffect.Play();
                playSoundEffect = true;
                Game1.GetInstance.DisableControl = true;
                Game1Utility.MarioTotalLives--;
            }
            resetTimer += GameTime.ElapsedGameTime.Milliseconds;
            if (resetTimer > 3000)
            {               
                resetTimer -= 3000;
                playSoundEffect = false;
                MediaPlayer.Volume = Game1Utility.RegularVolume;
                command.Execute();
                if (Game1Utility.MarioTotalLives == 0)
                {
                    Game1.GetInstance.GameStatus = Game1.GameState.End;
                }
                else
                {
                    Game1.GetInstance.GameStatus = Game1.GameState.LivesScreen;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = mario.Texture.Width / mario.Columns;
            int height = mario.Texture.Height / mario.Rows;
            int row = (int)((float)currentFrame / (float)mario.Columns);
            int column = currentFrame % mario.Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            if (flashStatus == 1)
            {
                spriteBatch.Draw(mario.Texture, destinationRectangle, sourceRectangle, Color.White * 0.5f);
            }
            else
            {
                spriteBatch.Draw(mario.Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            spriteBatch.End();
        }


    }
}