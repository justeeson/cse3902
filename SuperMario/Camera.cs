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
        public bool disableCamera = false;

        public Camera()
        {
            cameraPositionX = 0;
            cameraPositionY = 0;
        }

        public void UpdateX(int MarioPositionX)
        {
            if (!disableCamera)
            {
                if (MarioPositionX < 6350)
                {
                    if (MarioPositionX > cameraPositionX + 350)
                    {
                        cameraPositionX += MarioPositionX - (cameraPositionX + 350);
                    }
                    else if (MarioPositionX < cameraPositionX + 350 && cameraPositionX > (cameraPositionX + 350) - MarioPositionX)
                    {
                        cameraPositionX -= (cameraPositionX + 350) - MarioPositionX;
                    }
                }
            }
        }
        
        public void SetPositionZero()
        {
            cameraPositionX = 0;
        }
    }
}
