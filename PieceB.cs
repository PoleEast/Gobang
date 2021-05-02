using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋
{
    class PieceB : Piece
    {
        public PieceB(int x, int y) : base(x, y)
        {
            this.Image = Properties.Resources.black;
        }
        public override bool PiececColor()
        {
            return true;
        }
    }
}
