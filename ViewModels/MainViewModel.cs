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

        public ScoreboardModel Scoreboard
        {
            get { return _scoreboard; }
            set
            {
                _scoreboard = value;
                RaisePropertyChanged<ScoreboardModel>(() => Scoreboard);

            }


        }
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
            set { _scoreinput = value;
                RaisePropertyChanged(() => ScoreInput);
            }
        }

        /*
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
        */


        

        /*
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
                _totalscore = value;
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
         */
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
