using System;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingApp.Models;
using GalaSoft.MvvmLight;

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
        private FrameStatus _frameStatus;

        public FrameStatus FrameStatus
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
                RaisePropertyChanged(() => CurrentFrame);
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
    }
}
