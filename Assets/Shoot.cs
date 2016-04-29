using UnityEngine;
using System.Collections;
using System;

public class Shoot : MonoBehaviour {

	public Transform handTransform;
	public GameObject ball;

	private float pressTime;
	private const float MIN_DURATION = 0.2f;
	private const float MAX_DURATION = 1.0f;

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

			for (int i = 10; i < 11; i++) {
				Debug.Log("#### " + i + " ####");
				for(int j=0; j < 20; j++) {
					Debug.Log(1+j*0.1 + " log " + i + "= " + Math.Log (1+j*0.1, i));
				}
			} 
		}
		else if (Input.GetButtonUp ("Fire1"))
		{
			float duration = Time.time - pressTime;
			duration = Math.Min (duration, MAX_DURATION);
			duration = Math.Max (duration, MIN_DURATION);

			float force = (float)Math.Log10(1.5 + duration) * 30000;

			Debug.Log ("force: " + force);

			GameObject currentBall = (GameObject)Instantiate (ball, handTransform.position, Quaternion.identity);

			Vector3 direction = new Vector3 () {
				x = handTransform.forward.x,
				y = 0.8f,
				z = handTransform.forward.z,
			};

			currentBall.GetComponent<Rigidbody> ().AddForce (direction * force);
		}
	}
}
