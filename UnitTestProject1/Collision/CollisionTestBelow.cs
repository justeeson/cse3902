using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario.Collision
{
    
    [TestClass]
    public class CollisionTestBelow : IObject
    {
        public Rectangle Area { get; set; }


        public class BelowTest
        {
            public Rectangle Area { get; set; }
            public BelowTest(int X, int Y, int width, int height)
            {
                this.Area = new Rectangle(X, Y, width, height);
            }
           
        }
        [TestMethod()]
        public void TestBelow()
        {
           
            Rectangle collisionRectangle;
            BelowTest obj = new BelowTest(16, 16, 4, 8);
            BelowTest mario = new BelowTest(50, 80, 20, 40);
            for (int y = 0; y <= 54; y++)
            {
                mario.Area = new Rectangle(50, 80 - y, 20, 40);
                collisionRectangle = Rectangle.Intersect(mario.Area, obj.Area);
                if (collisionRectangle.Bottom == obj.Area.Bottom && collisionRectangle.Width > collisionRectangle.Height)
                {
                    
                }
                else
                {
                    Assert.Fail();
                }
            }
        }
      
    }
}
