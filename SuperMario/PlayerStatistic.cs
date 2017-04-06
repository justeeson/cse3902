using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class PlayerStatistic
    {
        private SpriteBatch spriteBatch;
        private SpriteFont textFont;
        private int score;
        private int coin;
        private int time;
        private Vector2 position;
        private Vector2 displayPos;
        private Vector2 displayVelocity;
        private string headerKeywords;
        private string headerVariables;
        private ISprite coinTexture;
        private string displayScore;
        private bool endGame;
        private int counter;
        private int displayTime=0;
        private string flagScore;
        public PlayerStatistic(SpriteBatch spritePatch, ContentManager content)
        {
            spriteBatch = spritePatch;
            textFont = content.Load<SpriteFont>("TextFont");
            position = new Vector2(400,22);
            displayPos = new Vector2();
            displayVelocity = new Vector2(0, -2);
            headerKeywords = "MARIO                                  WORLD             TIME";
            endGame = false;
            coinTexture =  SpriteFactory.CreateCoin();
            flagScore = "5000";
            score = 0;
            coin = 0;
            time = 400;
            displayScore = "";
            headerVariables = FormatString(score, 6) + "             x" + FormatString(coin, 2) + "                   1-1                  " + FormatString(time, 3);
        }

       

        public void Update(GameTime gameTime)
        {
            counter++;
            if (counter == 60)
            {
                counter = 0;
                if (time > 0)
                {
                    time--;
                }
            }

            if (displayTime > 0)
            {
                displayTime--;
                displayPos += displayVelocity;
            }

            coinTexture.Update(gameTime);
            headerVariables = FormatString(score,6) + "             x" + FormatString(coin, 2) + "                   1-1                  " + FormatString(time, 3);
        }

        public string FormatString(int score, int digit)
        {
            string result = "";
            if (score != 0)
            {
                for (int i = 0; i < digit; i++)
                {
                    if (score >= (Math.Pow(10, i)))
                    {
                        result = "";
                        for (int j = digit - i - 1; j > 0; j--)
                        {
                            result += "0";
                        }
                        result += score;
                    }
                }
            }
            else
            {
                for (int i = 0; i < digit; i++)
                {
                    result += "0";
                }
            }

            return result;

        }
        public void ConvertTimeToScore()
        {
            score = score + time * 20;
            time = 0;
        }
        public void SetEndGame(bool value)
        {
            endGame = value;
        }
        public void SetScoreValue(int score)
        {
            this.score += score;
        }

        public void SetCoinValue() {
            coin += 1;
        }

        public void Reset()
        {
            score = 0;
            coin = 0;
            time = 400;
        }

        public void Draw(Vector2 camera)
        {
            Vector2 OriginalFont = textFont.MeasureString(headerKeywords)/2;
            spriteBatch.Begin();
            spriteBatch.DrawString(textFont, headerKeywords, position,
                Color.White, 0, OriginalFont, new Vector2(2, 2), SpriteEffects.None, 0.5f);
            if (displayTime > 0)
            {
                Vector2 displayOrigin = textFont.MeasureString(displayScore)/2;
                spriteBatch.DrawString(textFont, displayScore, displayPos-camera, Color.White, 0, displayOrigin, new Vector2(2, 2), SpriteEffects.None, 0.5f);
            }
            spriteBatch.DrawString(textFont, headerVariables, position+(new Vector2(0,30)), Color.White, 0, OriginalFont, new Vector2(2, 2), SpriteEffects.None, 0.5f);
            if (endGame)
            {
                spriteBatch.DrawString(textFont, flagScore, position + (new Vector2(150, 150)), Color.White, 0, OriginalFont, new Vector2(1, 1), SpriteEffects.None, 0.5f);
            }

            spriteBatch.End();
            coinTexture.Draw(spriteBatch, new Vector2(260,30));
        }

    }
}
