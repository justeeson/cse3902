using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class Camera
    {
        public static int cameraPositionX;
        public static int cameraPositionY;

        public Camera()
        {
            cameraPositionX = 0;
            cameraPositionY = 0;
        }

        public void UpdateX(int MarioPositionX)
        {
            if (MarioPositionX < 6350)
            {
                if (MarioPositionX > cameraPositionX + 400)
                {
                    cameraPositionX += MarioPositionX - (cameraPositionX + 400);
                }
                if (MarioPositionX < cameraPositionX + 400 && cameraPositionX > (cameraPositionX + 400) - MarioPositionX)
                {
                    cameraPositionX -= (cameraPositionX + 400) - MarioPositionX;
                }
            }
        }
    }
}
