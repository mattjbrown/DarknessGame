using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float jumpForce = 500f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		this.rigidbody2D.velocity = new Vector2(3f * Input.GetAxisRaw ("Horizontal"), this.rigidbody2D.velocity.y);

		if (Input.GetButtonDown("Jump"))
		{
			this.rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}
}
