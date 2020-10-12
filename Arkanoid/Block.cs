using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Arkanoid.Properties;

namespace Arkanoid
{
    public class Block
    {
        private int life;
        private int positionX;
        private int positionY;
        public Image blockImage;
        
        public Block()
        {
            blockImage = new Image()
            {
                Width = 32,
                Height = 32,
                Source = new BitmapImage(new Uri(@"/Resources/Images/block.png", UriKind.Relative))
            };
        }
        public void SetPos(int positionX, int positionY)
        {
            Canvas.SetTop(blockImage, positionY);
            Canvas.SetLeft(blockImage, positionX);
        }
    }
}