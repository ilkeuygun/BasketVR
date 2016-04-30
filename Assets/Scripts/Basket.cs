using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Basket : MonoBehaviour {

	public TextMesh ScoreBoard;

	void OnTriggerEnter(Collider other) {
		Game.Current.BasketSuccess (other.gameObject);
		ScoreBoard.text = Game.Current.SuccessCount + "/" + Game.Current.CountedBalls;
	}
}
