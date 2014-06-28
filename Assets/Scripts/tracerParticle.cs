using UnityEngine;
using System.Collections;

public class tracerParticle : MonoBehaviour {

	public int pingDuration = 5;

	private float startTime;
	private float endTime;
	private bool hasStopped = false;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		endTime = Time.time + pingDuration;
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (Time.time);

		if (Time.time >= endTime)
		{
			//Debug.Log("die!");
			Destroy (gameObject);
		}
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{

		if (!other.collider.name.Equals("Player"))
		{
			//Debug.Log ("Collide!");
			this.rigidbody2D.velocity = Vector2.zero;
		}

		var lifePercent = (Time.time) - startTime / pingDuration;
		var color = this.renderer.material.color;
		color.a = lifePercent * 255;
		this.renderer.material.color = color;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log ("Trigger!  " + other.name);
		if (!other.name.Equals("Player") && !other.name.Equals("Ping") && !other.name.Equals("Tracer") && !hasStopped)
		{
			//Debug.Log ("not player!");
			this.rigidbody2D.velocity = Vector2.zero;

			// Refresh duration of ping on collision, but diminish returns
			//pingDuration /= 2;
			endTime += pingDuration;

			if (other.transform.parent != null && other.transform.parent.GetComponent("platformMover") != null)
			{

				this.transform.parent = other.transform.parent;
				//this.transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));
				//this.transform.localScale = new Vector3(this.transform.localScale.x / other.transform.localScale.x, this.transform.localScale.y / other.transform.localScale.y, 0.1f);
			}
			else
			{
				this.transform.parent = null;
			}

			//hasStopped = true;
		}
	}
}
