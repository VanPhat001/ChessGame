using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Objects
{
    public class ChessPieceRule
    {
        #region fields
        private Board _board;
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        public ChessPieceRule(Board board)
        {
            _board = board;
        }

        #region methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="pieceTurn"></param>
        /// <returns></returns>
        public bool CanMove(Point start, Point end, PositionEnums pieceTurn)
        {
            ChessPiece cellFrom = _board[start.Y, start.X];
            ChessPiece cellTo = _board[end.Y, end.X];

            if (start.X == end.X && start.Y == end.Y) return false;
            if (cellFrom.PiecePosition != pieceTurn) return false;
            if (cellTo.PieceType != PieceEnums.Empty && cellFrom.PiecePosition == cellTo.PiecePosition) return false;

            // todo: check path between from..to
            switch (cellFrom.PieceType)
            {
                case PieceEnums.Pawn:
                    return CheckPawnMove(start, end, cellFrom, cellTo);

                case PieceEnums.Bishop:
                    return CheckBishopMove(start, end);

                case PieceEnums.Knight:
                    return CheckKnightMove(start, end);

                case PieceEnums.Rook:
                    return CheckRookMove(start, end);

                case PieceEnums.Queen:
                    return CheckQueenMove(start, end);

                case PieceEnums.King:
                    return CheckKingMove(start, end);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private bool CheckRookMove(Point start, Point end)
        {
            int dx = Math.Abs(start.X - end.X);
            int dy = Math.Abs(start.Y - end.Y);

            if (dx * dy == 0 && dx + dy != 0)
            {
                if (dx == 0)
                {
                    return CheckEmpty(start, end, new Point(0, (end.Y - start.Y) / dy));
                }
                else // dy == 0
                {
                    return CheckEmpty(start, end, new Point((end.X - start.X) / dx, 0));
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private bool CheckKnightMove(Point start, Point end)
        {
            int dx = Math.Abs(start.X - end.X);
            int dy = Math.Abs(start.Y - end.Y);
            return (dx + dy == 3 && dx * dy == 2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private bool CheckBishopMove(Point start, Point end)
        {
            int dx = end.X - start.X;
            int dy = end.Y - start.Y;

            if (dy != 0 && Math.Abs(dx / dy) == 1)
            {
                return CheckEmpty(start, end, new Point(dx / Math.Abs(dx), dy / Math.Abs(dy)));
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private bool CheckQueenMove(Point start, Point end)
        {
            return CheckRookMove(start, end) || CheckBishopMove(start, end);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private bool CheckKingMove(Point start, Point end)
        {
            int dx = Math.Abs(start.X - end.X);
            int dy = Math.Abs(start.Y - end.Y);

            return dx <= 1 && dy <= 1 && dx + dy > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private bool CheckPawnMove(Point start, Point end, ChessPiece pieceFrom, ChessPiece pieceTo)
        {
            return pieceFrom.PiecePosition == PositionEnums.Top
                ? CheckPawnTop(start, end, pieceTo)
                : CheckPawnBottom(start, end, pieceTo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private bool CheckPawnTop(Point start, Point end, ChessPiece pieceTo)
        {
            if (end.Y - start.Y == 2
                && start.Y == 1
                && start.X == end.X
                && pieceTo.PieceType == PieceEnums.Empty)
            {
                return _board[2, start.X].PieceType == PieceEnums.Empty;
            }
            else if (end.Y - start.Y == 1)
            {
                if (end.X - start.X == 0)
                {
                    return pieceTo.PieceType == PieceEnums.Empty;
                }
                else if (Math.Abs(end.X - start.X) <= 1)
                {
                    return pieceTo.PieceType != PieceEnums.Empty;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private bool CheckPawnBottom(Point start, Point end, ChessPiece pieceTo)
        {
            if (end.Y - start.Y == -2
                && start.Y == 6
                && start.X == end.X
                && pieceTo.PieceType == PieceEnums.Empty)
            {
                return _board[5, start.X].PieceType == PieceEnums.Empty;
            }
            else if (end.Y - start.Y == -1)
            {
                if (end.X - start.X == 0)
                {
                    return pieceTo.PieceType == PieceEnums.Empty;
                }
                else if (Math.Abs(end.X - start.X) <= 1)
                {
                    return pieceTo.PieceType != PieceEnums.Empty;
                }
            }

            return false;
        }

        /// <summary>
        /// check path (start, end)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="delta"></param>
        /// <returns></returns>
        private bool CheckEmpty(Point start, Point end, Point delta)
        {
            while (true)
            {
                start.X += delta.X;
                start.Y += delta.Y;

                if (start.X == end.X && start.Y == end.Y)
                {
                    break;
                }
                if (!_board.CheckRange(start.X, start.Y)
                    || _board[start.Y, start.X].PieceType != PieceEnums.Empty)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

    }
}
