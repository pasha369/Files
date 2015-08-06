using System.Collections.Generic;

namespace Prototype_Image
{
    public class ImageManager
    {
        private Dictionary<int, ImagePrototype> images;

        public ImageManager(string pathToDir)
        {
            images = new Dictionary<int, ImagePrototype>();

            images[0] = new ImagePrototype(pathToDir + "Tetris_I.svg.png");
            images[1] = new ImagePrototype(pathToDir + "Tetris_J.svg.png");
            images[2] = new ImagePrototype(pathToDir + "Tetris_L.svg.png");
            images[3] = new ImagePrototype(pathToDir + "Tetris_O.svg.png");
            images[4] = new ImagePrototype(pathToDir + "Tetris_S.svg.png");
            images[5] = new ImagePrototype(pathToDir + "Tetris_T.svg.png");
            images[6] = new ImagePrototype(pathToDir + "Tetris_Z.svg.png");
        }

        public ImagePrototype this[int num]
        {
            set
            {
                images.Add(num, value);
            }
            get { return images[num]; }
        }
    }
}