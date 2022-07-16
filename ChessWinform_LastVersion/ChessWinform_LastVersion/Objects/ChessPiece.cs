using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.Objects
{
    public class ChessPiece : PictureBox
    {
        #region fields
        private Point _pieceLocation;
        private Color _pieceBackColor;
        private PieceEnums _pieceType;
        private PositionEnums _piecePosition;
        private readonly Board _controlParent;
        #endregion

        #region properties
        public static readonly string BlackPieceFolderPath = @"Resource\black\";
        public static readonly string WhitePieceFolderPath = @"Resource\white\";

        public Board ControlParent => _controlParent;

        public Point PieceLocation
        {
            get => _pieceLocation;
            private set
            {
                _pieceLocation = value;
            }
        }
        public Color PieceBackColor
        {
            get => _pieceBackColor;
            private set => _pieceBackColor = value;
        }
        public PieceEnums PieceType
        {
            get => _pieceType;
            set
            {
                _pieceType = value;
                ReloadImage();
            }
        }
        public PositionEnums PiecePosition
        {
            get => _piecePosition;
            set
            {
                _piecePosition = value;
                ReloadImage();
            }
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="pieceLocation"></param>
        /// <param name="pieceBackColor"></param>
        /// <param name="pieceType"></param>
        /// <param name="piecePosition"></param>
        public ChessPiece(Board parent, int x, int y, Color pieceBackColor, PieceEnums pieceType = PieceEnums.Empty, PositionEnums piecePosition = PositionEnums.Top)
        {
            PieceLocation = new Point(x, y);
            BackColor = PieceBackColor = pieceBackColor;
            PieceType = pieceType;
            PiecePosition = piecePosition;
            _controlParent = parent;

            BackgroundImageLayout = ImageLayout.Zoom;
            SizeMode = PictureBoxSizeMode.CenterImage;
            Margin = new Padding(0);
        }

        #region methods
        /// <summary>
        /// 
        /// </summary>
        public void ReloadImage()
        {            
            if (PieceType == PieceEnums.Empty)
            {
                BackgroundImage = null;
            }
            else
            {
                string folderPath = PiecePosition == PositionEnums.Top ? BlackPieceFolderPath : WhitePieceFolderPath;
                BackgroundImage = Image.FromFile(folderPath + PieceType.ToString() + ".png");
            }
            BackColor = PieceBackColor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pieceType"></param>
        /// <param name="piecePosition"></param>
        public void CopyState(PieceEnums pieceType, PositionEnums piecePosition)
        {
            this.PieceType = pieceType;
            this.PiecePosition = piecePosition;
        }
        #endregion
    }
}
