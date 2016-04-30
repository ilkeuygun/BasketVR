using UnityEngine;
using System.Collections;
using System;
using AssemblyCSharp;

public class Shoot : MonoBehaviour {

	public Transform handTransform;
	public GameObject ball;

	private OVRPlayerController player;
	private float pressTime = 0;
	private const float MIN_DURATION = 0.2f;
	private const float MAX_DURATION = 1.0f;

	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3 (0, -160, 0);

		player = GameObject.FindObjectOfType<OVRPlayerController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (!Game.Current.IsRunning)
        {
			return;
        }

		if (!Game.Current.HasMoreBalls)
        {
			return;
		}

		if (!Game.Current.IsMoving)
		{
			if (Input.GetButtonDown ("Fire1"))
			{
				pressTime = Time.time;
			}
			else if (Input.GetButtonUp ("Fire1") && pressTime != 0)
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

				Game.Current.BallThrown (currentBall);

				pressTime = 0;
			}
		}	
			
		movePlayer ();
	}

	private void movePlayer() {
		switch (Game.Current.CurrentStep)
		{
			case 1:
				moveToVector (new Vector3(-1055.5f, 65.1f, -260.3f));
				break;
			case 2:
				moveToVector (new Vector3(-847.6f, 65.1f, -195.8f));
				break;
			case 3:
				moveToVector (new Vector3(-756.8f, 65.1f, 0.2f));
				break;
			case 4:
				moveToVector (new Vector3(-847.6f, 65.1f, 196.2f));
				break;
			case 5:
				moveToVector (new Vector3(-1055.5f, 65.1f, 260.7f));
				break;
		}
	}

	private void moveToVector(Vector3 vector) {
		if (!isReallyClose(player.transform.position, vector)) {
			Game.Current.IsMoving = true;

			player.transform.position = Vector3.Lerp (
				player.transform.position,
				vector,
				Time.deltaTime
			);}
		else {
			Game.Current.IsMoving = false;
		}
	}

	private bool isReallyClose(Vector3 v1, Vector3 v2) {
		return isReallyClose (v1.x, v2.x)
		&& isReallyClose (v1.y, v2.y)
		&& isReallyClose (v1.z, v2.z);

	}

	private bool isReallyClose(float f1, float f2) {
		return Math.Abs (f1 - f2) < 15;
	}
}

