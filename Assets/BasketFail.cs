using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class BasketFail : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Game.Current.BasketFail (other.gameObject);
	}
}
