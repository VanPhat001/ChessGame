using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Chess.Models;
using Chess.Objects;

namespace Chess.Forms
{
    public partial class ChessBoardForm : Form
    {
        private readonly SettingModel _model;
        private Board _board;
        private GamePlay _gamePlay;
        private bool _isClose;

        public SettingModel Model => _model;
        public bool IsClose { get => _isClose; private set => _isClose = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public ChessBoardForm(SettingModel model)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            _model = model;
            _board = new Board(this);
            _board.IsEnableBoard = false;
            _gamePlay = new GamePlay(this, _board);
            IsClose = false;

            this.progressBarCountTime.Minimum = 0;
            this.progressBarCountTime.Maximum = model.TimeOneTurn;
            this.progressBarCountTime.Value = model.TimeOneTurn;

            this.FormClosed += ChessBoardForm_FormClosed;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChessBoardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _gamePlay.StopClock();
            IsClose = true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            await _board.FillData();
            await _board.SetPieceIntoBoard();
        }


        /// <summary>
        /// chagne image for picturebox when mouse enter area (undo arrow image)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxUndo_MouseEnter(object sender, EventArgs e)
        {
            PictureBox picture = sender as PictureBox;
            picture.Image = Image.FromFile(@"Resource\undoArrrow.png");
        }

        /// <summary>
        /// change image for picturebox when mouse leave area (undo arrow image)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxUndo_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picture = sender as PictureBox;
            picture.Image = Image.FromFile(@"Resource\undoArrrowClicked.png");
        }

        /// <summary>
        /// change image for picturebox when mouse into area (next arrow image)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxNext_MouseEnter(object sender, EventArgs e)
        {
            PictureBox picture = sender as PictureBox;
            picture.Image = Image.FromFile(@"Resource\redoArrow.png");
        }

        /// <summary>
        /// change image for picturebox when mouse leave area (next arrow image)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxNext_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picture = sender as PictureBox;
            picture.Image = Image.FromFile(@"Resource\CantRedo.png");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            _gamePlay.Start();
            (sender as Button).Enabled = false;
        }

        /// <summary>
        /// previous state button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void pictureBoxUndo_Click(object sender, EventArgs e)
        {
            await _gamePlay.ChangePreviousState();
        }

        /// <summary>
        /// next status button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void pictureBoxNext_Click(object sender, EventArgs e)
        {
            await _gamePlay.ChangeNextState();
            //throw new Exception();
        }
    }
}
