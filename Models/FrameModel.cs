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
         * The boolean isLastFrame tells us if this is the last frame in our scoreboard. 
         *      This is set to true for the 10th frame.
         * Status tells us what step the Frame is in. It will help to track our Strike and Spare outcomes.
           
        */
        public int FrameNumber { get; set; }
        public int FirstScore { get; set; }
        public int SecondScore { get; set; }
        public int TotalScore { get; set; }
        public bool IsLastFrame { get; set; }
        // 0 Waiting, 1 First, 2 Second, 3 Third, 9 spare, 10 Strike, 15 Finished 
        public int FrameStatus { get; set; }
        public FrameModel()
        {
            FrameNumber = 1;
            // Initialize with a blank score
            FirstScore = 0;
            SecondScore = 0;
            TotalScore = FirstScore + SecondScore;
            IsLastFrame = false;
            FrameStatus =0;
        }
        public FrameModel(int frameNumber)
        {
            FrameNumber = frameNumber;
            // Initialize with a blank score
            FirstScore = 0;
            SecondScore = 0;
            TotalScore = FirstScore + SecondScore;
            IsLastFrame = false;
            FrameStatus = 0;
        }

        public void setFirst(int x)
        {
            FirstScore = x;
            RaisePropertyChanged(() => FirstScore);
            RaisePropertyChanged(() => TotalScore);
            RaisePropertyChanged(() => FrameStatus);

        }


        public void setSecond(int x)
        {
            if ((FirstScore + x) > 10)
            {
                MessageBox.Show("First and Second Score are higher than 10");
                return;
            }
            SecondScore = x;
            RaisePropertyChanged(() => SecondScore);
            RaisePropertyChanged(() => TotalScore);
            RaisePropertyChanged(() => FrameStatus);


        }

        public void refreshFrames()
        {
            RaisePropertyChanged(() => FirstScore);
            RaisePropertyChanged(() => SecondScore);
            RaisePropertyChanged(() => TotalScore);
            RaisePropertyChanged(() => FrameStatus);

        }





    }
    public class LastFrameModel : FrameModel
    {
        // The last frame of the model will have slots for 3 possible scores.
        public int ThirdScore { get; set; }
        public LastFrameModel()
        {
            FrameNumber = 10;
            FirstScore = 0;
            SecondScore = 0;
            ThirdScore = 0;
            TotalScore = FirstScore + SecondScore + ThirdScore;
            // We set this to true since this is the last frame in our scoreboard
            IsLastFrame = true;
            FrameStatus = 0;
        }

        public void setThird(int x)
        {
            ThirdScore= x;
            RaisePropertyChanged(() => ThirdScore);
            RaisePropertyChanged(() => TotalScore);
            RaisePropertyChanged(() => FrameStatus);


        }

        public void refreshFrames()
        {
            RaisePropertyChanged(() => FirstScore);
            RaisePropertyChanged(() => SecondScore);
            RaisePropertyChanged(() => ThirdScore);
            RaisePropertyChanged(() => TotalScore);
            RaisePropertyChanged(() => FrameStatus);

        }

    }
}