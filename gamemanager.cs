using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋
{
    class gamemanager
    {
        private readonly BroadControl BroadControl = new BroadControl();
        public char whoiswinner = 'n';
        private bool WorB = true;
        public bool PutPiece(int x, int y)
        {
            return BroadControl.CanPutPiece(x, y);
        }           //call BroadControl.CanPutPiece
        public Piece PiaceAPiece(int x, int y)
        {
            Piece piece = BroadControl.PiaceAPiece(x, y, WorB);
            if (piece != null)
            {
                if(Whowin()!='n')
                    return piece;
                WorB = !WorB;
                return piece;
            }
            return null;
        }       //call BroadControl.PiaceAPiece and change WorB 
        public char Whowin()
        {
            for (int cheakX = -1; cheakX <= 0; cheakX++)
            {
                for(int cheakY = -1; cheakY <= 1; cheakY++)
                {
                    int Conutelse = 0;
                    if (cheakY == 0 && cheakX == 0)
                        continue;
                    Conutelse = judgecount(cheakX, cheakY);
                    Conutelse += judgecount(cheakX * -1, cheakY * -1);
                    if (Conutelse == 4)
                    {
                        if (WorB == false)
                        {
                            whoiswinner = 'w';
                            return 'w';
                        }
                        if (WorB == true)
                        {
                            whoiswinner = 'b';
                            return 'b';

                        }
                    }
                }
            }
            whoiswinner = 'n';
            return 'n';
        }
        private int judgecount(int x,int y)
        {
            int Countelse = 0;
            int Count = 1;
            while (Count < 5)
            {
                int pieceX = BroadControl.LastPut.X;
                int pieceY = BroadControl.LastPut.Y;
                if (pieceX == -1 || pieceY == -1)
                    break;
                pieceX += Count * x;
                pieceY += Count * y;
                if (pieceX == -1 || pieceY == -1)
                    break;
                if (BroadControl.pieces[pieceX, pieceY] == null)                          //has cheak here piece 
                    break;
                if (BroadControl.PiececColor(pieceX, pieceY) != WorB)
                    break;
                Count++;
                Countelse++;
            }
            return Countelse;
        }
        public bool Draw()
        {
            int x = 1, y = 1;
            for (; x < 10; x++)
            {
                for (; y < 10; y++)
                {
                    if (BroadControl.pieces[x, y] != null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
