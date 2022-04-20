# BowlingScoreboardWPF
This program represents a Scoreboard that can be used to track scores in Bowling. It is written in WPF using an MVVM Model.
Language: C#/WPF
Program is designed to make a Scoreboard object and add 10 frames to it. Scores are recorded from the Scoreboard class and added to Frames. Frames have multiple statuses that can vary how they calculate their total scores.

Packages that must be installed in addition to the ones in the 'packages' folder are:
 - MvvmLightLibs.5.4.1.1 (used for ObservableCollection objects)
 - System.Runtime.Serialization.Primitives.4.3.0

The program is launched through a Bootstrapper created from the Caliburn.Micro package.
