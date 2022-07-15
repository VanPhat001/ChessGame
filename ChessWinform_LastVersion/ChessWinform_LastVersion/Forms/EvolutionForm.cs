using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess.Objects;

namespace Chess.Forms
{

    public partial class EvolutionForm : Form
    {
        private ImageList imgList;
        private int imgIndex;
        public static readonly PieceEnums[] pieceEvolution = { PieceEnums.Rook, PieceEnums.Knight, PieceEnums.Bishop, PieceEnums.Queen };        

        public EvolutionForm(PositionEnums piecePosition)
        {
            InitializeComponent();

            string path = piecePosition == PositionEnums.Top
                ? ChessPiece.BlackPieceFolderPath
                : ChessPiece.WhitePieceFolderPath;


            imgList = new ImageList();
            foreach (var item in pieceEvolution)
            {
                string imgPath = path + item.ToString() + ".png";
                imgList.Images.Add(Image.FromFile(imgPath));
            }


            imgIndex = 0;
            ShowImageSelect();

            this.FormClosed += EvolutionForm_FormClosed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void EvolutionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Tag = pieceEvolution[imgIndex];
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowImageSelect()
        {
            pictureBoxShowPiece.BackgroundImage = imgList.Images[imgIndex];
            lblName.Text = pieceEvolution[imgIndex].ToString();
        }

        /// <summary>
        /// show prev piece image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (--imgIndex < 0) imgIndex = 0;
            ShowImageSelect();
        }

        /// <summary>
        /// show next piece image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (++imgIndex >= imgList.Images.Count) imgIndex = imgList.Images.Count - 1;
            ShowImageSelect();
        }

        /// <summary>
        /// accept and close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEvolution_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
