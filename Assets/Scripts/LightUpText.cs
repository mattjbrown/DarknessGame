using UnityEngine;
using System.Collections;

public class LightUpText : MonoBehaviour {

	public float litTime = 10f; 

	private float hitTime;
	private TextMesh textMesh;

	// Use this for initialization
	void Start () {
		textMesh = this.GetComponent<TextMesh> ();
		hitTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		var color = textMesh.color;
		//Debug.Log (Time.deltaTime);
		if (color.a > 0)
		{
			color.a = 1 - ((Time.time - hitTime) / litTime);
			//Debug.Log (color.a);
			textMesh.color = color;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log ("Hit!");
		//Debug.Log ("Trigger!  " + other.name);
		if (other.name.Equals("Ping") || other.name.Equals("Tracer"))
		{
			Destroy(other.gameObject);
		
			hitTime = Time.time;
			var color = textMesh.color;
			color.a = 1;
			textMesh.color = color;
		}


	}
}
