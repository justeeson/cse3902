using Microsoft.Xna.Framework;
using System;
using System.IO;

namespace SuperMario.BackLog_Writer
{
    public class BackLog
    {
        String path;
        String fileName;

        public BackLog()
        {
            fileName = DateTime.Now.ToString("g").Replace("/", " ");
            fileName = fileName.Replace(":", " ");
            path = "../../../../BackLog Writer/";
            path = path + fileName + ".txt";
            File.Create(path);
        }

        public string Path()
        {
            return path;
        }

    }
}
