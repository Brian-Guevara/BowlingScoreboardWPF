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


namespace BowlingApp.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        // Main Object we will be showing is our Scoreboard.
        private ScoreboardModel _scoreboard = new ScoreboardModel();
        // This model will be the current frame we are working with
        private FrameModel _currentFrame;

        // Scores of the frames we are working with
        private int _firstscore;
        private int _secondscore;
        private int _thirdscore;
        private int _totalscore;
        private int _frameNumber;
        private int _frameStatus;

        private int _scoreinput;

        public int ScoreInput
        {
            get { return _scoreinput; }
            set { _scoreinput = value; }
        }


        public int FrameStatus
        {
            get { return _frameStatus; }
            set { 
                _frameStatus = value;
                RaisePropertyChanged(() => FrameStatus);
            }
        }


        public FrameModel CurrentFrame
        {
            get { return _currentFrame; }
            set 
            { 
                _currentFrame = value;
                RaisePropertyChanged<FrameModel>(() => CurrentFrame);
            }
        }



        public ScoreboardModel Scoreboard
        {
            get { return _scoreboard; }
            set
            {
                _scoreboard = value;
                RaisePropertyChanged<ScoreboardModel>(() => Scoreboard);

            }


        }

        public int FrameNumber
        {
            get { return _frameNumber; }
            set { 
                _frameNumber = value;
                RaisePropertyChanged(() => FrameNumber);
            }
        }


        public int FirstScore
        {
            get
            { return _firstscore; }
            set
            {
                _firstscore = value;
                RaisePropertyChanged(() => FirstScore);
                RaisePropertyChanged(() => TotalScore);
            }
        }

        public int SecondScore
        {
            get { return _secondscore; }
            set
            {
                _secondscore = value;
                RaisePropertyChanged(() => SecondScore);
                RaisePropertyChanged(() => TotalScore);

            }
        }

        public int ThirdScore
        {
            get { return _thirdscore; }
            set
            {
                _thirdscore = value;
                RaisePropertyChanged(() => ThirdScore);
                RaisePropertyChanged(() => TotalScore);

            }
        }
        public int TotalScore
        {
            get
            {return _totalscore;}
            set
            {
                _totalscore = _firstscore + _secondscore;
                RaisePropertyChanged(() => TotalScore);
            }
        }

        public  void FirstScore_Add(object sender, KeyEventArgs e)
        {
               MessageBox.Show("HEY");

            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Scoreboard.AddScore(_firstscore);
                e.Handled = true;
            }
        }

        public  void SecondScore_Add(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Scoreboard.AddScore(_secondscore);
                e.Handled = true;
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
            _scoreboard.AddScore(_scoreinput);

            RaisePropertyChanged<ScoreboardModel>(() => Scoreboard);
            RaisePropertyChanged<FrameModel>(() => CurrentFrame);
        }
    }
}
