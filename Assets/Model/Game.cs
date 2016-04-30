using System;
using UnityEngine;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class Game
	{
		private const int BALL_COUNT_IN_STEP = 5;
		private const int STEP_COUNT = 5;

		public int CurrentBall { get; private set; }
		public int CurrentStep { get; private set; }
		public int SuccessCount { get; private set; }
		public int CountedBalls { get; private set; }
		public bool HasMoreBalls { get; private set; }
        public bool IsRunning { get; set; }
		public bool IsFinished { get; private set; }
		public GameDifficulty Difficulty { get; set; }
		public bool IsMoving { get; set; }

		private List<GameObject> _uncountedBalls; 

		private static Game _current;
		public static Game Current
		{
			get { return _current ?? (_current = new Game()); }
		}

		private Game ()
		{
			Reset ();
		}

		public void Reset() {
			CurrentBall = 1;
			CurrentStep = 1;
			SuccessCount = 0;
			CountedBalls = 0;
			HasMoreBalls = true;
            IsRunning = false;
			IsFinished = false;
			IsMoving = false;

			_uncountedBalls = new List<GameObject> ();
		}

		public void BallThrown(GameObject ball) {
			_uncountedBalls.Add (ball);

			CurrentBall++;

			CurrentStep = (CurrentBall + BALL_COUNT_IN_STEP - 1) / BALL_COUNT_IN_STEP;

			if (CurrentBall > BALL_COUNT_IN_STEP * STEP_COUNT) {
				HasMoreBalls = false;
			}
		}

		public void BasketFail(GameObject ball) {
			if (_uncountedBalls.Contains(ball)) {
				_uncountedBalls.Remove (ball);

				CountedBalls++;

				checkFinished ();

				Debug.Log (SuccessCount + " " + CountedBalls);
			}
		}

		public void BasketSuccess(GameObject ball) {
			if (_uncountedBalls.Contains(ball)) {
				_uncountedBalls.Remove (ball);

				SuccessCount++;
				CountedBalls++;

				checkFinished ();

				Debug.Log (SuccessCount + " " + CountedBalls);
			}
		}

		private void checkFinished() {
			if (CountedBalls == BALL_COUNT_IN_STEP * STEP_COUNT) {
				IsFinished = true;
			}
		}

		public bool IsFirstBallOfStep() {
			return CurrentBall % BALL_COUNT_IN_STEP == 1;	
		}
	}
}

