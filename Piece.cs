using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace 五子棋
{
    abstract class Piece : PictureBox
    {
        public static readonly int ImageWidth = 50;
        public Piece(int x, int y)
        {
            this.BackColor = Color.Transparent;
            this.Location = new Point(x, y);
            this.Size = new Size(ImageWidth, ImageWidth);
        }
        public abstract bool PiececColor(); 
    }
}
