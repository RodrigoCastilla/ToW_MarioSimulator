using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour {
	public MarioSoundFX soundEffects;
	private float velocityOnX, jumpVelocity, movementOnX, actualPosition;
	private Animator movementAnimator;

	// Use this for initialization
	void Start () {
		movementAnimator = GetComponent<Animator> ();
		velocityOnX = 0.1f; 
		jumpVelocity = 500f;
		movementOnX = actualPosition = 0; 
	}
		
	private void MoveMario(float horizontalMovement){
		movementAnimator.SetBool ("movementOnX", true);
		movementOnX = transform.position.x + (horizontalMovement * velocityOnX);
		transform.position = new Vector3 (movementOnX, transform.position.y, 2);
		if (horizontalMovement > 0) {
			transform.localScale = new Vector3 (4,4,3);
		} else if (horizontalMovement < 0){
			transform.localScale = new Vector3 (-4,4,3);
		}
		movementOnX = actualPosition;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			soundEffects.PlayMarioJumpFX ();
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpVelocity));
		} 
		float inputX = Input.GetAxis ("Horizontal");
		if (inputX != 0)
			MoveMario (inputX);
		else 
			movementAnimator.SetBool ("movementOnX", false);


	}
}
