using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Basket : MonoBehaviour {

	void OnTriggerEnter() {
		Game.Current.BasketSuccess ();
	}
}
