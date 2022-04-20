using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace BowlingApp.Models
{
    public class ScoreboardModel:ObservableObject
    {
        private ObservableCollection<FrameModel> _frames = new ObservableCollection<FrameModel>();

        public ObservableCollection<FrameModel> Frames { get { return _frames; }}

        public int FrameCount { get; set; }


        public ScoreboardModel()
        {

            // Initialize by creating our first 9 frames followed by our 10th frame object.
            for (int i = 1; i < 10; i++)
            {
                _frames.Add(new FrameModel(i));
            }
            _frames.Add(new LastFrameModel());

            //Set our first frame to be ready/applicable for score
            _frames[0].Status = FrameStatus.First;
            FrameCount = 0;
            RaisePropertyChanged<ObservableCollection<FrameModel>>(() => Frames);

        }

        //Function which will add the score to a Frame and update its status.
        public void AddScore(int score)
        {
            FrameModel currentFrame = this._frames[this.FrameCount];

            // Condition if we hit lit than 10 pins in the first score of a frame
            if (currentFrame.Status == FrameStatus.First && score < 10)
            {
                currentFrame.FirstScore = score;
                currentFrame.Status = FrameStatus.Second;
            }

            // Condition if we hit a Strike
            else if (currentFrame.Status == FrameStatus.First && score == 10)
            {
                currentFrame.FirstScore = score;
                currentFrame.Status = FrameStatus.Strike;
                this._frames[this.FrameCount + 1].Status = FrameStatus.First;
            }

            // Condition if the two scores for a frame are less than 10 (not a spare)
            else if (currentFrame.Status == FrameStatus.Second && (currentFrame.FirstScore + score) < 10)
            {
                currentFrame.SecondScore = score;
                currentFrame.TotalScore = currentFrame.FirstScore + currentFrame.SecondScore;
                currentFrame.Status = FrameStatus.End;
            }
            else if (currentFrame.Status == FrameStatus.Second && (currentFrame.FirstScore + score) == 10)
            {
                currentFrame.SecondScore = score;
                currentFrame.TotalScore = currentFrame.FirstScore + currentFrame.SecondScore;
                currentFrame.Status = FrameStatus.Spare;
            }


        }

       


    }
}
