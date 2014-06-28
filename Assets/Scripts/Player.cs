using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float jumpForce = 500f;
	public float speed = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		var horizMovement = Input.GetAxisRaw ("Horizontal");

		this.rigidbody2D.velocity = new Vector2(speed * horizMovement, this.rigidbody2D.velocity.y);


		if (horizMovement != 0)
		{
			GetComponent<Animator>().SetBool("isMoving", true);
		}
		else
		{
			GetComponent<Animator>().SetBool("isMoving", false);
		}


		if (Input.GetButtonDown("Jump"))
		{
			this.rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}
}
