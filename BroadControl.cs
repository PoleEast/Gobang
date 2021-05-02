using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace 五子棋
{
    class BroadControl
    {
        public Point LastPut =new Point (-1, -1);
        private readonly int DetectRadius = 15;
        private readonly int DetectCenterCompartment = 75;
        public Piece[,] pieces = new Piece[11, 11];             //Edge join boundary two so is 11

        public bool CanPutPiece(int x, int y)
        {
            if (aroundwhere(x, y))                             //Find the nearrest node
            {
                if (pieces[nodeld(x, y).X, nodeld(x, y).Y] == null)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }                //judge can put piece?
        public Piece PiaceAPiece(int x, int y, bool WorB)       // W = false,B = true
        {
            if (CanPutPiece(x, y) == false)
                return null;
            else
            {
                if (pieces[nodeld(x, y).X, nodeld(x, y).Y] != null)         // Check if the piece exists
                    return null;
            }

            if (WorB == true)
                pieces[nodeld(x, y).X, nodeld(x, y).Y] = new PieceB(nodeld(x, y).X * DetectCenterCompartment - Piece.ImageWidth / 2, nodeld(x, y).Y * DetectCenterCompartment - Piece.ImageWidth / 2);
            if (WorB == false)
                pieces[nodeld(x, y).X, nodeld(x, y).Y] = new PieceW(nodeld(x, y).X * DetectCenterCompartment - Piece.ImageWidth / 2, nodeld(x, y).Y * DetectCenterCompartment - Piece.ImageWidth / 2);
            LastPut = nodeld(x,y);
            return pieces[nodeld(x, y).X, nodeld(x, y).Y];
        }
        private bool aroundwhere(int x, int y)                  //Determine whether or not small hand
        {
            if (nodeld(x, y).X == -1 || nodeld(x, y).Y == -1)
                return false;
            else
                return true;

        }
        private int pieceNumbe(int x)                           //Calculate piece position by virtual location
        {
            for (int xnumber = 1; xnumber <= 9; xnumber++)
            {
                int xpos = DetectCenterCompartment * xnumber;
                if (x <= xpos + DetectRadius && x >= xpos - DetectRadius)
                    return xnumber;
            }
            return -1;
        }
        private Point nodeld(int x, int y)                      //Record location to pieces(cs.15)
        {
            Point Nodeld = new Point(pieceNumbe(x), pieceNumbe(y));
            return Nodeld;
        }
        public bool PiececColor(int x, int y)                   //call  PiececColor
        {
            return pieces[x, y].PiececColor();
        }                                                                             

    }
}
