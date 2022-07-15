using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Forms;

namespace Chess.Objects
{
    public class GamePlay
    {
        private Board _board;
        private ChessBoardForm _window;
        private ChessPiece _cellSelect;
        private List<Point> _suggestList;
        private PositionEnums _turn;

        public PositionEnums Turn => _turn;

        public ChessPiece CellSelect
        {
            get => _cellSelect;
            set
            {
                #region clear status
                if (_cellSelect != null)
                {
                    _cellSelect.ReloadImage();

                    // clear suggest
                    foreach (Point point in _suggestList)
                    {
                        _board[point.Y, point.X].Image = null;
                    }
                    _suggestList.Clear();
                }
                #endregion

                #region move piece and exit setter if can
                if (_cellSelect != null && _cellSelect.PieceType != PieceEnums.Empty)
                {
                    ChessPieceRule rule = new ChessPieceRule(_board);
                    if (rule.CanMove(_cellSelect.PieceLocation, value.PieceLocation, Turn))
                    {
                        // check end game
                        if (value.PieceType == PieceEnums.King)
                        {
                            System.Windows.Forms.MessageBox.Show("Chessmate");
                            _window.pnlBoard.Enabled = false;
                            return;
                        }

                        // move piece to cellTo
                        value.PiecePosition = _cellSelect.PiecePosition;
                        value.PieceType = _cellSelect.PieceType;

                        // clear piece from cellFrom
                        _cellSelect.PieceType = PieceEnums.Empty;

                        // evolution
                        if (value.PieceType == PieceEnums.Pawn && (value.PieceLocation.Y == 0 || value.PieceLocation.Y == 7))
                        {
                            // show evolution form
                            EvolutionForm evolutionForm = new EvolutionForm(value.PiecePosition);
                            evolutionForm.ShowDialog();
                            value.PieceType = (PieceEnums)evolutionForm.Tag;
                        }

                        _cellSelect = null;
                        ChangeTurn();
                        return;
                    }
                }
                #endregion

                #region set new status
                _cellSelect = value;
                if (_cellSelect != null)
                {
                    _cellSelect.BackColor = _window.Model.SelectBackColor;

                    // add suggest
                    // suggest when in turn
                    if (_cellSelect.PiecePosition == Turn)
                    {
                        ChessPieceRule rule = new ChessPieceRule(_board);
                        for (int r = 0; r < 8; r++)
                        {
                            for (int c = 0; c < 8; c++)
                            {
                                if (rule.CanMove(value.PieceLocation, new Point(c, r), value.PiecePosition))
                                {
                                    _board[r, c].Image = System.Drawing.Image.FromFile(@"Resource\PossibleMove.png");
                                    _suggestList.Add(new Point(c, r));
                                }
                            }
                        }
                    }
                }
                #endregion
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ChangeTurn()
        {
            _turn = _turn == PositionEnums.Top ? PositionEnums.Bottom : PositionEnums.Top;
            _window.textBoxShowTurn.Text = $"Turn of { (_turn == PositionEnums.Top ? "Black" : "White") } chess piece";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        public GamePlay(ChessBoardForm window, Board board)
        {
            _window = window;
            _board = board;
            _cellSelect = null;
            _suggestList = new List<Point>();
            _turn = PositionEnums.Top;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            _board.IsEnableBoard = true;
            _suggestList.Clear();
            _board.CellClick += _board_CellClick;
            _window.KeyDown += _window_KeyDown;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _window_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                CellSelect = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _board_CellClick(object sender, EventArgs e)
        {
            CellSelect = sender as ChessPiece;
        }
    }
}
