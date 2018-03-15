using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	[SerializeField]
	private float speed = 0.005f;

	[SerializeField]
	private float jumpPower = 8.0f;

	private float x = 0.0f;
	private bool grounded = true;


	// Use this for initialization
	void Start () {
	}

	void OnCollisionEnter2D(Collision2D other){
	//	if(other.GetType() == typeof(Collider2D)){
	//	}
		grounded = true;
		//if (other.GetType (typeof(Hazard))) {
			//TODO: Death
		//}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Jump ();
		}

		transform.Translate (x + speed, 0, 0);
	}

	public void Jump (){
		if (grounded) {
			grounded = false;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpPower), 
				ForceMode2D.Impulse);
		}
	}
}
