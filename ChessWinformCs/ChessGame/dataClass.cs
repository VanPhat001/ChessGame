using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    [Serializable]
    public class dataClass
    {
        public Point Start { get; }
        public Point End { get; }
        public bool ServerTurn { get; }
        public bool Evolution { get; }
        public int chessman { get; }
        public bool Chessmate { get; }


        public dataClass(Point start, Point end, bool serverTurn, bool evolution, int chessman, bool chessmate)
        {
            this.Start = start;
            this.End = end;
            this.ServerTurn = serverTurn;
            this.Evolution = evolution;
            this.chessman = chessman;
            this.Chessmate = chessmate;
        }

    }
}
