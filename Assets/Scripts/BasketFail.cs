using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class BasketFail : MonoBehaviour {

	public TextMesh ScoreBoard;

	void OnTriggerEnter(Collider other) {
		Game.Current.BasketFail (other.gameObject);
		ScoreBoard.text = Game.Current.SuccessCount + "/" + Game.Current.CountedBalls;
	}
}
