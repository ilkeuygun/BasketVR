using System;
using UnityEngine;

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
		public bool IsFinished { get; private set; }
		public GameDifficulty Difficulty { get; set; }


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
			IsFinished = false;
		}

		public void BallThrown() {
			CurrentBall++;

			CurrentStep = CurrentBall / 3 + 1;

			if (CurrentBall > BALL_COUNT_IN_STEP * STEP_COUNT) {
				HasMoreBalls = false;
			}
		}

		public void BasketFail() {
			CountedBalls++;

			checkFinished ();
		}

		public void BasketSuccess() {
			SuccessCount++;
			CountedBalls++;

			checkFinished ();

			Debug.Log (SuccessCount + " " + CountedBalls);
		}

		private void checkFinished() {
			if (CountedBalls == BALL_COUNT_IN_STEP * STEP_COUNT) {
				IsFinished = true;
			}
		}
	}
}

