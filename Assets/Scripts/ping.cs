using UnityEngine;
using System.Collections;

public class ping : MonoBehaviour {

	public Rigidbody2D pingPrefab;
	public Rigidbody2D tracerPrefab;
	public float speed = .5f;				// The speed the rocket will fire at.

	public float pingSpeed = 1f;
	public float tracerSpeed = 2f;

	public int numPings = 360;

	public int numTracers = 10;
	public int tracerAngleRange = 20;

	private bool pingDelay = false;
	private bool tracerDelay = false;

	private float direction = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		var horizMovement = Input.GetAxisRaw ("Horizontal");
		if (horizMovement != 0)
		{
			direction = Mathf.Sign (horizMovement);
		}

		
		if(Input.GetButtonDown("Fire1") && !pingDelay)
		{
			pingDelay = true;
			for(int i = 0; i < 360; i += 360/numPings)
			{
				Rigidbody2D bulletInstance = Instantiate(pingPrefab, transform.position, Quaternion.Euler(new Vector3(0,0,i))) as Rigidbody2D;
				bulletInstance.name = "Ping";
				bulletInstance.velocity = new Vector2(Mathf.Sin(Mathf.Deg2Rad * i), Mathf.Cos(Mathf.Deg2Rad * i)) * pingSpeed;
				//Debug.Log(bulletInstance.velocity);
			}

		}
		if (Input.GetButtonUp ("Fire1"))
		{
			pingDelay = false;
		}

		if(Input.GetButtonDown("Fire2") && !tracerDelay)
		{
			tracerDelay = true;
			for(int i = tracerAngleRange / -2; i < tracerAngleRange / 2; i += tracerAngleRange/numTracers)
			{

				Rigidbody2D bulletInstance = Instantiate(tracerPrefab, transform.position, Quaternion.Euler(new Vector3(0,0,i))) as Rigidbody2D;
				bulletInstance.name = "Tracer";
				bulletInstance.velocity = new Vector2(Mathf.Sin(Mathf.Deg2Rad * (90 + i)), Mathf.Cos(Mathf.Deg2Rad * (90 + i))) * tracerSpeed * direction;
				//Debug.Log(bulletInstance.velocity);
			}
			
		}
		if (Input.GetButtonUp ("Fire2"))
		{
			tracerDelay = false;
		}
	}
}
