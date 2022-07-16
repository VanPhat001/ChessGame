using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Chess.Models
{
    public class SettingModel : INotifyPropertyChanged
    {
        #region fields
        private Color _selectBackColor;
        private Color _firstBackColor;
        private Color _secondBackColor;
        private int _timeOneTurn;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public SettingModel()
        {
        }


        #region properties
        public Color FirstBackColor
        {
            get => _firstBackColor;
            set
            {
                _firstBackColor = value;
                OnPropertyChanged();
            }
        }
        public Color SecondBackColor
        {
            get => _secondBackColor;
            set
            {
                _secondBackColor = value;
                OnPropertyChanged();
            }
        }
        public Color SelectBackColor
        {
            get => _selectBackColor;
            set
            {
                _selectBackColor = value;
                OnPropertyChanged();
            }
        }
        public int TimeOneTurn
        {
            get => _timeOneTurn;
            set
            {
                _timeOneTurn = value;
                OnPropertyChanged();
            }
        }
        #endregion



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
