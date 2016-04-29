using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public Transform handTransform;
	public GameObject ball;

	private float pressTime;

	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3 (0, -160, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Fire1"))
		{
			pressTime = Time.time;
		}
		else if (Input.GetButtonUp ("Fire1"))
		{

			float force = (Time.time - pressTime) * 22000;
			Debug.Log ("force: " + force);


			GameObject currentBall = (GameObject)Instantiate (ball, handTransform.position, Quaternion.identity);

			Vector3 direction = new Vector3 () {
				x = handTransform.forward.x,
				y = handTransform.forward.y + 0.4f,
				z = handTransform.forward.z,
			};

			currentBall.GetComponent<Rigidbody> ().AddForce (direction * force);
		}
	}
}
