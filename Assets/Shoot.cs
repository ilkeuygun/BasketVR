using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public Transform handTransform;
	public GameObject ball;

	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3 (0, -120, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			GameObject currentBall = (GameObject)Instantiate (ball, handTransform.position, Quaternion.identity);

			Vector3 direction = new Vector3 () {
				x = handTransform.forward.x,
				y = handTransform.forward.y + 0.3f,
				z = handTransform.forward.z,
			};

			currentBall.GetComponent<Rigidbody> ().AddForce (direction * 10000);
		}
	}
}
