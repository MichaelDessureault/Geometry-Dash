using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public Transform startingPoint;

	[SerializeField]
	private float xVelocity = 5.0f;

	[SerializeField]
	private float yVelocity = 0.0f;

	[SerializeField]
	private float gravity = 0.5f;

	private float y = 0.0f;
	private float jumpPower = 8.0f;

	private bool grounded = false;
	private float platformHeight;

	// Use this for initialization
	void Start () {
		y = startingPoint.position.y;
		yVelocity = jumpPower;
	}

	void OnCollisionEnter2D(Collision2D other){
	//	if(other.GetType() == typeof(Collider2D)){
		grounded = true;
		platformHeight = other.transform.position.y;
	//	}
		//if (other.GetType (typeof(Hazard))) {
			//TODO: Death
		//}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Jump ();
		}

		if (yVelocity != 0.0f) {
			y = y - (yVelocity * Time.deltaTime);
			yVelocity = yVelocity + (gravity * Time.deltaTime);
		}

		if(grounded){
			y = platformHeight / 2;
			yVelocity = 0.0f;
		}

		//xVelocity += 0.05f;
		this.transform.position = new Vector2(xVelocity, y);
	}

	public void Jump (){
		if (grounded) {
			grounded = false;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), 
				ForceMode2D.Impulse);
		}
	}
}
