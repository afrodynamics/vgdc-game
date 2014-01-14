using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float moveSpeed = 3;		// Against OOP, I know; but public variables can be modified in Unity's editor. Awesome!
	public float xMove, yMove = 0;	// These variables are changed every frame, as a result of Update()
	public Vector2 movementVector;  // Also changed as a result of Update();

	// Use this for initialization
	void Start () {

	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
	
		/*
		 * Update's a pretty awesome function. Most of your code will go here.
		 * We'll primarilly be checking for user input here (keyboard).
		 */

		// Since this is a Maze game, we can't move in diagonals. We'll want to restrict
		// to either horizontal or vertical movement.
		// In Unity, go to Edit>Project Settings>Input to see what this does

		this.xMove = Input.GetAxis("Horizontal") * this.moveSpeed;  
		this.yMove = Input.GetAxis("Vertical") * this.moveSpeed;

		if ( xMove == 0 && yMove != 0 ) {
			//yMove *= Time.deltaTime;				  // Delta-timing essentially makes sure we move at a rate constant versus time
			movementVector = new Vector2( 0, yMove ); // We only care about yMove
		}
		else if ( xMove != 0 && yMove == 0) {
			//xMove *= Time.deltaTime;				  // Delta-timing, or "frame-independent" logic is easy to implement in Unity!
			movementVector = new Vector2( xMove, 0 ); // We only care about xMove
		}
		else {
			movementVector = new Vector2( 0, 0 ); // For now, move horizontally or vertically. Otherwise, don't move.
		}

		// Now that we have the direction we'd like to move in, lets set our velocity to this vector

		rigidbody2D.AddForce( movementVector );

	}

	/**
	 * Called when we enter a collision with another GameObject that has a <Something>Collider attached to it
	 * i.e. a BoxCollider2D, or a SphereCollider, or whatever.
	 */

	void OnCollisionEnter2D( Collision2D coll ) {

		// Because a Collision2D has occurred, we've got a Collision2D event. We want to grab its GameObject
		// and then identify it so we know what behaviour we want our player to perform.
		/*
		if ( coll.gameObject.tag == "blockSprite" ) {

			// Well, we've hit a block, so we should probably go back...
			transform.Translate( -movementVector );

		}

		Debug.Log("collision enter");*/
	}
}
