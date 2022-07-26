using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BowlingApp.Models
{

    /* Property that represents the current step/status of a frame.
     * First = It's the first turn in a frame
     * Second = Second turn in the frame
     * End = End of a frame which means we can calculate that Frame's Score
     * Strike = State when 10 pins are hit during the First State. This causes us to skip the Second status.
     * Spare = Occurs when we knock the remaining Pins in the Second status
    */


    public class FrameModel : ObservableObject
    {

        /* Properties of a Frame within a Scoreboard.
         * First int value represents the frame number from 1 to 10
         * Next three values represent our 2 scores and the sum of those scores
         * Status tells us what step the Frame is in. It will help to track our Strike and Spare outcomes as well.
        */

        #region Properties
        public int FrameNumber { get; set; }

        private int _firstScore; 
        public int FirstScore
        {
            get { return _firstScore; }
            set
            {
                _firstScore = value;
                RaisePropertyChanged(() => FirstScore);
            }
        }


        private int _secondScore;

        public int SecondScore
        {
            get { return _secondScore; }
            set { 
                _secondScore = value;
                RaisePropertyChanged(() => SecondScore);
            }
        }

        private int _totalScore;

        public int TotalScore
        {
            get { return _totalScore; }
            set { 
                _totalScore = value;
                RaisePropertyChanged(() => TotalScore);
            }
        }





        private int _frameStatus;

        public int FrameStatus
        {
            get { return _frameStatus; }
            set { 
                _frameStatus = value;
                RaisePropertyChanged(() => FrameStatus);
            
            }
        }

        #endregion

        // 0 Waiting, 1 First, 2 Second, 3 Third, 9 spare, 10 Strike, 15 Finished 
        public FrameModel()
        {
            FrameNumber = 1;
            // Initialize with a blank score
            FirstScore = 0;
            SecondScore = 0;
            TotalScore = FirstScore + SecondScore;
            FrameStatus =0;
        }
        public FrameModel(int frameNumber)
        {
            FrameNumber = frameNumber;
            // Initialize with a blank score
            FirstScore = 0;
            SecondScore = 0;
            TotalScore = FirstScore + SecondScore;
            FrameStatus = 0;
        }





    }
    public class LastFrameModel : FrameModel
    {



        // The last frame of the model will have slots for 3 possible scores.
        private int _thirdScore;

        public int ThirdScore
        {
            get { return _thirdScore; }
            set { 
                _thirdScore = value;
                RaisePropertyChanged(() => ThirdScore);
            }
        }

        public LastFrameModel()
        {
            FrameNumber = 10;
            FirstScore = 0;
            SecondScore = 0;
            ThirdScore = 0;
            TotalScore = FirstScore + SecondScore + ThirdScore;
            // We set this to true since this is the last frame in our scoreboard
            FrameStatus = 0;
        }

    }
}