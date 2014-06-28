using UnityEngine;
using System.Collections;

public class ping : MonoBehaviour {

	public Rigidbody2D rocket;				// Prefab of the rocket.
	public float speed = .5f;				// The speed the rocket will fire at.

	public int numParticles = 180;


	private bool delay = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown("Fire1") && !delay)
		{
			delay = true;
			for(int i = 0; i < 360; i += 360/numParticles)
			{
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,i))) as Rigidbody2D;
				bulletInstance.name = "Ping";
				bulletInstance.velocity = new Vector2(Mathf.Sin(Mathf.Deg2Rad * i), Mathf.Cos(Mathf.Deg2Rad * i));
				//Debug.Log(bulletInstance.velocity);
			}

		}
		if (Input.GetButtonUp ("Fire1"))
		{
			delay = false;
		}
	
	}
}
