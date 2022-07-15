using Chess.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Objects
{
    public struct GameState
    {
        private readonly PieceEnums[,] _pieceType;
        private readonly PositionEnums[,] _piecePosition;
        private readonly ChessPiece _cellSelect;        
        private readonly PositionEnums _turn;

        public GameState(Board board, ChessPiece cellSelect, PositionEnums turn)
        {
            _cellSelect = cellSelect;
            _turn = turn;

            _pieceType = new PieceEnums[8, 8];
            _piecePosition = new PositionEnums[8, 8];
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    _pieceType[r, c] = board[r, c].PieceType;
                    _piecePosition[r, c] = board[r, c].PiecePosition;
                }
            }
        }



        public ChessPiece CellSelect => _cellSelect;

        public PositionEnums Turn => _turn;

        public PieceEnums[,] PieceType => _pieceType;

        public PositionEnums[,] PiecePosition => _piecePosition;
    }
}
