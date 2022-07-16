using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess.Forms;

namespace Chess.Objects
{
    public class Board
    {
        #region fields
        private ChessBoardForm _window;
        private ChessPiece[,] _cells;
        private event EventHandler _cellClick;
        #endregion

        #region properties
        public event EventHandler CellClick
        {
            add => _cellClick += value;
            remove => _cellClick -= value;
        }


        public bool IsEnableBoard
        {
            get => _window.pnlBoard.Enabled;
            set => _window.pnlBoard.Enabled = value;
        }


        public ChessPiece this[int row, int col]
        {
            get => _cells[row, col];
            private set => _cells[row, col] = value;
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="window"></param>
        public Board(ChessBoardForm window)
        {
            _window = window;
            _cells = new ChessPiece[8, 8];
        }

        #region methods
        /// <summary>
        /// 
        /// </summary>
        public async Task SetPieceIntoBoard()
        {
            _cells[0, 0].PieceType = PieceEnums.Rook;
            _cells[0, 1].PieceType = PieceEnums.Knight;
            _cells[0, 2].PieceType = PieceEnums.Bishop;
            _cells[0, 3].PieceType = PieceEnums.Queen;
            _cells[0, 4].PieceType = PieceEnums.King;
            _cells[0, 5].PieceType = PieceEnums.Bishop;
            _cells[0, 6].PieceType = PieceEnums.Knight;
            _cells[0, 7].PieceType = PieceEnums.Rook;
            await Task.Delay(5);

            _cells[7, 0].PieceType = PieceEnums.Rook;
            _cells[7, 1].PieceType = PieceEnums.Knight;
            _cells[7, 2].PieceType = PieceEnums.Bishop;
            _cells[7, 3].PieceType = PieceEnums.Queen;
            _cells[7, 4].PieceType = PieceEnums.King;
            _cells[7, 5].PieceType = PieceEnums.Bishop;
            _cells[7, 6].PieceType = PieceEnums.Knight;
            _cells[7, 7].PieceType = PieceEnums.Rook;
            await Task.Delay(5);

            // test data
            //_cells[4, 0].PieceType = PieceEnums.Rook;
            //_cells[3, 4].PieceType = PieceEnums.Bishop;
            //_cells[3, 4].PiecePosition = PositionEnums.Bottom;
            //_cells[5, 2].PieceType = PieceEnums.Pawn;
            //_cells[2, 2].PieceType = PieceEnums.Pawn;
            //_cells[2, 2].PiecePosition = PositionEnums.Bottom;

            for (int x = 0; x < 8; x++)
            {
                _cells[1, x].PieceType = PieceEnums.Pawn;
                _cells[6, x].PieceType = PieceEnums.Pawn;

                _cells[0, x].PiecePosition = PositionEnums.Top;
                _cells[1, x].PiecePosition = PositionEnums.Top;
                _cells[6, x].PiecePosition = PositionEnums.Bottom;
                _cells[7, x].PiecePosition = PositionEnums.Bottom;
            }
        }


        /// <summary>
        /// set all controls in board to PieceEnums.Empty
        /// </summary>
        public void ResetData()
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    _cells[r, c].PieceType = PieceEnums.Empty;
                }
            }
        }


        /// <summary>
        /// clear all controls in board
        /// </summary>
        public void ClearData()
        {            
            _window.pnlBoard.Controls.Clear();
        }

        /// <summary>
        /// fill board with chess piece 
        /// </summary>
        public async Task FillData()
        {
            FlowLayoutPanel pnl = _window.pnlBoard;

            int cellWidth = pnl.Width / 8;
            int cellHeight = pnl.Height / 8;
            ChessPiece cell;
            bool isWhiteCell = true;

            for (int r = 0; r < 8; r++, isWhiteCell = !isWhiteCell)
            {
                for (int c = 0; c < 8; c++, isWhiteCell = !isWhiteCell)
                {
                    cell = new ChessPiece(this, c, r, isWhiteCell ? _window.Model.FirstBackColor : _window.Model.SecondBackColor)
                    {
                        Width = cellWidth,
                        Height = cellHeight,
                    };
                    _cells[r, c] = cell;
                    pnl.Controls.Add(cell);

                    cell.Click += Cell_Click;
                }
                await Task.Delay(1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool CheckRange(int x, int y)
        {
            return 0 <= x && x < 8
                && 0 <= y && y < 8;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        private void OnCellClick(object sender)
        {
            this._cellClick?.Invoke(sender, new EventArgs());
        }
        #endregion


        #region events
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cell_Click(object sender, EventArgs e)
        {
            OnCellClick(sender);
        }
        #endregion
    }
}
