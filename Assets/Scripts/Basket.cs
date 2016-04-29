using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Basket : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Game.Current.BasketSuccess (other.gameObject);
	}
}
