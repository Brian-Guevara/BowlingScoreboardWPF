using System;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingApp.Models;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace BowlingApp.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        // Main Object we will be showing is our Scoreboard.
        private ScoreboardModel _scoreboard = new ScoreboardModel();

        public ScoreboardModel Scoreboard
        {
            get { return _scoreboard; }
            set
            {
                _scoreboard = value;
                RaisePropertyChanged<ScoreboardModel>(() => Scoreboard);

            }


        }


        private int _scoreinput;
        public int ScoreInput
        {
            get { return _scoreinput; }
            set { _scoreinput = value;
                RaisePropertyChanged(() => ScoreInput);
            }
        }

        public ICommand Add_Score
        {
            get
            {
                return new RelayCommand(AddScore, () => true);
            }
        }

        public void AddScore()
        {
            if (0 > _scoreinput || 10 < _scoreinput)
            {
                MessageBox.Show("Incorrect value");
                return;
            }
            Scoreboard.AddScore(_scoreinput);
            RaisePropertyChanged(() => Scoreboard.Frames);
            RaisePropertyChanged(() => Scoreboard);

        }

    }
}
