using SuperMario.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Game_Object_Classes
{
    class ObjectArray : IObject
    {
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
            new Turtle(game);
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
            new NormalMonster(game);
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
            return result;
        }
        
    }
}
