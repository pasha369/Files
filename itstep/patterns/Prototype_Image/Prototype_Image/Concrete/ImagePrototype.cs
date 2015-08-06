using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Prototype_Image
{
    [Serializable]
    public class ImagePrototype:Prototype
    {
        private Bitmap image;
        public Bitmap Source
        {
            get { return image;  }
        }
        public ImagePrototype(string path)
        {
            image = new Bitmap(path);
        }

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }

        public override Prototype DeepCopy()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                return (Prototype)binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}