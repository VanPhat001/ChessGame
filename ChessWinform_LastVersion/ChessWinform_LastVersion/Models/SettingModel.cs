using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    public class SettingModel : INotifyPropertyChanged
    {
        private Color _selectBackColor;
        private Color _firstBackColor;
        private Color _secondBackColor;
        private int _timeOneTurn;

        public SettingModel()
        {
        }

        public Color FirstBackColor
        {
            get => _firstBackColor;
            set
            {
                _firstBackColor = value;
                OnPropertyChanged(nameof(FirstBackColor));
            }
        }
        public Color SecondBackColor
        {
            get => _secondBackColor;
            set
            {
                _secondBackColor = value;
                OnPropertyChanged(nameof(SecondBackColor));
            }
        }
        public Color SelectBackColor
        {
            get => _selectBackColor;
            set
            {
                _selectBackColor = value;
                OnPropertyChanged(nameof(SelectBackColor));
            }
        }
        public int TimeOneTurn
        {
            get => _timeOneTurn;
            set
            {
                _timeOneTurn = value;
                OnPropertyChanged(nameof(TimeOneTurn));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
