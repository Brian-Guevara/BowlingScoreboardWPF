using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace BowlingApp.Models
{
    public class ScoreboardModel:ObservableObject
    {
        private ObservableCollection<FrameModel> _frames = new ObservableCollection<FrameModel>();

        public ObservableCollection<FrameModel> Frames { get { return _frames; } }

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
            _frames[0].FrameStatus = 1;
            StartFrame = 0;
            EndFrame = 0;

           


            /*
            AddScore(4);
            AddScore(4);
            AddScore(4);
            AddScore(4);
            AddScore(4);
            AddScore(4);
            AddScore(4);
            AddScore(4);
            AddScore(4);
            AddScore(4);
            AddScore(4);
            AddScore(4);
            AddScore(4);
            AddScore(4);
            AddScore(4);
            AddScore(4);
            AddScore(4);
            */


            RaisePropertyChanged<ObservableCollection<FrameModel>>(() => Frames);

        }

        
        //Function which will add the score to a Frame and update its status.
        public void AddScore(int score)
        {
            if (EndFrame== 9 && _frames[EndFrame].FrameStatus == 15)
            {
                MessageBox.Show("The Game is over!\nTotal Score: " + _frames[EndFrame].TotalScore);
                return;
            }




            // Starting frame we will iterate from until we hit a Waiting
            int i = StartFrame;
            int x = EndFrame;
            while (i <= x && _frames[i].FrameStatus != 0 && i < 10)
            {

                FrameModel currentFrame = _frames[i];


                // 10th Frame Conditions
                if (currentFrame.FrameNumber == 10)
                {
                    var LastFrame = (LastFrameModel)currentFrame;
                    switch (currentFrame.FrameStatus)
                    {
                        case 1:
                            LastFrame.FirstScore = score;
                            LastFrame.FrameStatus = 2;
                            break;


                        case 2:
                            LastFrame.SecondScore = score;

                            // Spare
                            if ((LastFrame.FirstScore + score) == 10)
                            {

                                LastFrame.FrameStatus = 3;

                            }
                            else if (score == 10)
                            {
                                LastFrame.FrameStatus = 3;

                            }
                            // Non Spare
                            else
                            {
                                LastFrame.FrameStatus = 15;
                                LastFrame.TotalScore += _frames[i - 1].TotalScore;

                            }

                            break;

                        case 3:
                            LastFrame.ThirdScore = score;
                            LastFrame.FrameStatus = 15;
                            LastFrame.TotalScore += _frames[i - 1].TotalScore;
                            Console.Write(LastFrame.TotalScore);
                            break;

                    }
                    LastFrame.refreshFrames();
                }

                // Frames 1 - 9
                else
                {
                    switch (currentFrame.FrameStatus)
                    {
                        case 1:
                            currentFrame.FirstScore = score;
                            //Strike
                            if (score == 10)
                            {
                                currentFrame.SecondScore = 0;
                                currentFrame.FrameStatus = 10;
                                this.EndFrame++;
                            }
                            //Non-Strike
                            else
                            {
                                currentFrame.FrameStatus = 2;
                            }
                            break;


                        case 2:
                            currentFrame.SecondScore = score;

                            // Spare
                            if ((currentFrame.FirstScore + score) == 10)
                            {

                                currentFrame.FrameStatus = 9;
                                this.EndFrame++;

                            }
                            // Non Spare
                            else if ((currentFrame.FirstScore + score) < 10)
                            {
                                currentFrame.FrameStatus = 15;
                                if (i >= 1)
                                    currentFrame.TotalScore += _frames[i - 1].TotalScore;
                                this.StartFrame++;
                                this.EndFrame++;

                            }


                            break;

                        case 9:
                            currentFrame.FrameStatus = 15;
                            if (i > 0)
                                currentFrame.TotalScore += _frames[i - 1].TotalScore;
                            this.StartFrame++;
                            break;

                        case 10:
                            currentFrame.FrameStatus = 9;
                            break;


                    }
                    currentFrame.refreshFrames();

                }
                currentFrame.TotalScore += score;
                currentFrame.refreshFrames();

                i++;

            }
            if (_frames[EndFrame].FrameStatus == 0 && EndFrame < 10)
                _frames[EndFrame].FrameStatus = 1;

        }



    }
}
