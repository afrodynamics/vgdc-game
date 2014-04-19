using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float moveSpeed = 4;		// Against OOP, I know; but public variables can be modified in Unity's editor. Awesome!
	public float maxMoveSpeed = 1; // Make sure we can't swim too fast!
	public float xMove, yMove = 0;	// These variables are changed every frame, as a result of Update()
	public Vector2 movementVector;  // Also changed as a result of Update();
	public GUIText text;

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

		if ( xMove != 0 && yMove == 0) {
			movementVector = new Vector2( xMove, 0 ); // We only care about xMove
		}

		if ( Input.GetButtonDown( "Jump" )) {
			rigidbody2D.AddForce( new Vector2( 0, 500 ) );
		}

		rigidbody2D.AddForce( movementVector );

		// Clamp velocity

		float xDir, yDir;
		xDir = rigidbody2D.velocity.x / rigidbody2D.velocity.magnitude;
		yDir = rigidbody2D.velocity.y / rigidbody2D.velocity.magnitude;
		rigidbody2D.velocity.Set( xDir * maxMoveSpeed, yDir * maxMoveSpeed );

		if ( text ) {
			text.text = "Velocity = " + rigidbody2D.velocity;
		}

	}

	void OnGUI()
	{
		GUILayout.TextArea("Velocity = " + rigidbody2D.velocity);
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
