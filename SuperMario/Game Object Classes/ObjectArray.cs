using SuperMario.Interfaces;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Game_Object_Classes
{
    class ObjectArray : IObject
    {
        public Rectangle Area { get; set; }
        private static ObjectArray instance = new ObjectArray();
        private ObjectArray()
        {

        }
        
        public static ObjectArray Instance
        {
            get
            {
                return instance;
            }
        }

        public ArrayList ArrayOfObjects(Game1 game)
        {
            ArrayList result = new ArrayList();
            new Koopa(game);
            result.Add(game.sprite);
            new Coin(game);
            result.Add(game.sprite);
            new GrownupMushroom(game);
            result.Add(game.sprite);
            new FireMushroom(game);
            result.Add(game.sprite);
            new Star(game);
            result.Add(game.sprite);
            new Flower(game);
            result.Add(game.sprite);
            new Goomba(game);
            result.Add(game.sprite);
            new SolidBrick(game);
            result.Add(game.sprite);
            new SolidBrickWithCrews(game);
            result.Add(game.sprite);
            new QuestionMarkBrick(game);
            result.Add(game.sprite);
            new BreakableCurlyBrick(game);
            result.Add(game.sprite);
            new BreakableHorizontalBrick(game);
            result.Add(game.sprite);
            new Pipe(game);
            result.Add(game.sprite);
            result.Add(game.sprite);
            return result;
        }

        public static void ResetArrayOfObjects(Game1 game, ArrayList result)
        {
            result.Clear();
            new Koopa(game);
            result.Add(game.sprite);
            new Coin(game);
            result.Add(game.sprite);
            new GrownupMushroom(game);
            result.Add(game.sprite);
            new FireMushroom(game);
            result.Add(game.sprite);
            new Star(game);
            result.Add(game.sprite);
            new Flower(game);
            result.Add(game.sprite);
            new Goomba(game);
            result.Add(game.sprite);
            new SolidBrick(game);
            result.Add(game.sprite);
            new SolidBrickWithCrews(game);
            result.Add(game.sprite);
            new QuestionMarkBrick(game);
            result.Add(game.sprite);
            new BreakableCurlyBrick(game);
            result.Add(game.sprite);
            new BreakableHorizontalBrick(game);
            result.Add(game.sprite);
            new Pipe(game);
            result.Add(game.sprite);
            result.Add(game.sprite);
        }

    }
}
