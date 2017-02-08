using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using SuperMario.Sprites;


namespace SuperMario.MarioClass
{
    public class Mario : IMario
    {
        public IMarioState state { get; set; }
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int totalFrames;

        public Mario(Texture2D texture, int rows, int columns)
        {
            state = new StandingRightSmallMarioState(this);
            Texture = texture;
            Rows = rows;
            Columns = columns;
            totalFrames = Rows * Columns;
        }

        public void LookLeft()
        {
            state = new StandingLeftSmallMarioState(this);
        }

        public void LookRight()
        {
            state = new StandingRightSmallMarioState(this);

        }

        public void Jump()
        {
            // Need a new state for mario is UP
            state = new StandingRightSmallMarioState(this);

        }
        public void Crouch()
        {
            // Need a new state for mario is UP
            state = new StandingRightSmallMarioState(this);

        }
        public void Big()
        {
            // Need a new state for mario is Big Mario
            state = new StandingRightSmallMarioState(this);

        }
        public void Small()
        {
            // Need a new state for mario is Small
            state = new StandingRightSmallMarioState(this);

        }
        public void Dead()
        {
            // Need a new state for mario is Dead
            state = new StandingRightSmallMarioState(this);

        }
        public void Fire()
        {
            // Need a new state for mario is Fire
            state = new StandingRightSmallMarioState(this);

        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            state.Draw(spriteBatch, location);
        }
    }
}
