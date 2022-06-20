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

        public int StartFrame { get; set; }
        public int EndFrame { get; set; }


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
            StartFrame = 0;
            EndFrame = 0;
            AddScore(10);
            AddScore(10);
            AddScore(10);
   
            
            AddScore(10);
            AddScore(10);
            AddScore(10);
            AddScore(10);
            AddScore(10);
            AddScore(10);
            AddScore(5);
            AddScore(1);
            //AddScore(5);



            /*AddScore(6);
            AddScore(4);
            AddScore(4);
            AddScore(2);
            AddScore(5);
            AddScore(6);
            */


            RaisePropertyChanged<ObservableCollection<FrameModel>>(() => Frames);

        }

        //Function which will add the score to a Frame and update its status.
        public void AddScore(int score)
        {
           
            // Starting frame we will iterate from until we hit a Waiting
            int i = StartFrame;
            int x = EndFrame;
            while (i <= x && _frames[i].Status != FrameStatus.Waiting)
            {

                FrameModel currentFrame = _frames[i];


                switch(currentFrame.Status)
                {
                    case FrameStatus.First:
                        currentFrame.FirstScore = score;
                        //Strike
                        if (score == 10)
                        {
                            currentFrame.SecondScore = 0;
                            currentFrame.Status = FrameStatus.Strike;
                            this.EndFrame++;
                        }
                        //Non-Strike
                        else
                        {
                            currentFrame.Status = FrameStatus.Second;
                        }
                        break;


                    case FrameStatus.Second:
                        currentFrame.SecondScore = score;

                        // Spare
                       if ((currentFrame.FirstScore + score) == 10)
                                {

                            currentFrame.SecondScore = score;
                            currentFrame.Status = FrameStatus.Spare;
                            this.EndFrame++;

                        }
                       // Non Spare
                        else if ((currentFrame.FirstScore + score) < 10)
                        {
                            currentFrame.Status = FrameStatus.End;
                            if (i >0)
                                currentFrame.TotalScore += _frames[i - 1].TotalScore;
                            this.StartFrame++;

                        }


                        break;

                    case FrameStatus.Spare:
                        currentFrame.Status = FrameStatus.End;
                        if (i > 0)
                            currentFrame.TotalScore += _frames[i - 1].TotalScore;
                        this.StartFrame++;
                        break;

                    case FrameStatus.Strike:
                        currentFrame.Status = FrameStatus.Spare;
                        break;


                }
                currentFrame.TotalScore += score;
                i++;

            }

            if (_frames[EndFrame].Status == FrameStatus.Waiting && EndFrame < 10)
                _frames[EndFrame].Status = FrameStatus.First;


        }




    }
}
