using UnityEngine;
using System.Collections;

public class pingParticle : MonoBehaviour {

	public int pingDuration = 5;

	private float startTime;
	bool hasStopped = false;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (Time.time);

		if (Time.time >= startTime + pingDuration)
		{
			//Debug.Log("die!");
			Destroy (gameObject);
		}

		var lifePercent = (Time.time) - startTime / pingDuration;
		var color = this.renderer.material.color;
		color.a = lifePercent * 255;
		this.renderer.material.color = color;
	}

	void OnCollisionEnter2D(Collision2D other)
	{

		if (!other.collider.name.Equals("Player"))
		{
			//Debug.Log ("Collide!");
			this.rigidbody2D.velocity = Vector2.zero;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log ("Trigger!  " + other.name);
		if (!other.name.Equals("Player") && !other.name.Equals("Ping") && !other.name.Equals("Tracer") && !hasStopped)
		{
			//Debug.Log ("not player!");
			this.rigidbody2D.velocity = Vector2.zero;
			hasStopped = true;
		}
	}
}
