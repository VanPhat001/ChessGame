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
    public partial class MenuForm : Form
    {
        private readonly SettingModel _settingModel;        


        public MenuForm()
        {
            InitializeComponent();

            _settingModel = new SettingModel()
            {
                FirstBackColor = System.Drawing.Color.White,
                SecondBackColor = System.Drawing.Color.PowderBlue,
                SelectBackColor = System.Drawing.Color.LightSlateGray,
            };
        }

        /// <summary>
        /// open chessboard form and play
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnClick_Start(object sender, EventArgs e)
        {
            this.Hide();

            ChessBoardForm form = new ChessBoardForm(_settingModel);
            form.Show();
            await form.Start();

            while (!form.IsClose)
            {
                await Task.Delay(100);
            }

            this.Show();
        }

        /// <summary>
        /// open setting form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClick_Setting(object sender, EventArgs e)
        {
            // hide menu form
            this.Hide();

            SettingForm form = new SettingForm(_settingModel);
            form.ShowDialog();

            // show menu form
            this.Show();
        }

        /// <summary>
        /// close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClick_Quit(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
