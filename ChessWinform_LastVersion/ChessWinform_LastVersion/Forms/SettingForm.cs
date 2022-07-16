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

namespace Chess.Forms
{
    public partial class SettingForm : Form
    {
        #region fields
        private SettingModel _model;
        private ColorDialog _colorDialog;
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public SettingForm(SettingModel model)
        {
            InitializeComponent();

            _model = model;
            _colorDialog = new ColorDialog();


            #region set binding
            // pictureBoxSelectPiece.BackColor <=> model.SelectBackColor
            pictureBoxSelectPiece.DataBindings.Add(
                nameof(pictureBoxSelectPiece.BackColor), model, nameof(model.SelectBackColor), true, DataSourceUpdateMode.OnPropertyChanged);

            // pictureBoxFirstCell.BackColor <=> model.FirstBackColor
            pictureBoxFirstCell.DataBindings.Add(
                nameof(pictureBoxFirstCell.BackColor), model, nameof(model.FirstBackColor), true, DataSourceUpdateMode.OnPropertyChanged);

            // pictureBoxSecondCell.BackColor <=> model.SecondBackColor
            pictureBoxSecondCell.DataBindings.Add(
                nameof(pictureBoxSecondCell.BackColor), model, nameof(model.SecondBackColor), true, DataSourceUpdateMode.OnPropertyChanged);

            // trackBarTime.Value <=> model.TimeOneTurn
            trackBarTime.DataBindings.Add(
                nameof(trackBarTime.Value), model, nameof(model.TimeOneTurn), true, DataSourceUpdateMode.OnPropertyChanged);
                        
            // numericUpDownCurrentValue.Value <=> model.TimeOneTurn
            numericUpDownCurrentValue.DataBindings.Add(
                nameof(numericUpDownCurrentValue.Value), model, nameof(model.TimeOneTurn), true, DataSourceUpdateMode.OnPropertyChanged);

            // numericUpDownCurrentValue.Maximum <=> trackBarTime.Maximum
            numericUpDownCurrentValue.DataBindings.Add(
                nameof(numericUpDownCurrentValue.Maximum), trackBarTime, nameof(trackBarTime.Maximum), true, DataSourceUpdateMode.OnPropertyChanged);

            // numericUpDownCurrentValue.Minimum <=> trackBarTime.Minimum
            numericUpDownCurrentValue.DataBindings.Add(
                nameof(numericUpDownCurrentValue.Minimum), trackBarTime, nameof(trackBarTime.Minimum), true, DataSourceUpdateMode.OnPropertyChanged);

            // lblMaxValue.Text <= trackBarTime.Maximum
            lblMaxValue.DataBindings.Add(
                nameof(lblMaxValue.Text), trackBarTime, nameof(trackBarTime.Maximum));
            #endregion
        }


        #region events
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Click_ChangeBackColor(object sender, EventArgs e)
        {
            PictureBox picture = sender as PictureBox;
            _colorDialog.Color = picture.BackColor;

            if (_colorDialog.ShowDialog() == DialogResult.OK)
            {
                picture.BackColor = _colorDialog.Color;
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
