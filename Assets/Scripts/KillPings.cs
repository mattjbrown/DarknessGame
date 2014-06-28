using UnityEngine;
using System.Collections;

public class KillPings : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name.Equals("Ping") || other.name.Equals("Tracer"))
		{
			Destroy(other.gameObject);
		
		}
	}
}
