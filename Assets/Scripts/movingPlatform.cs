using UnityEngine;
using System.Collections;

public class movingPlatform : MonoBehaviour {

	public Vector3 range = new Vector3(2f, 0f, 0f);
	public float speed = 0.3f;
	
	private Vector3 startPosition;
	private Vector3 endPosition;

	// Use this for initialization
	void Start ()
	{
		startPosition = transform.position;
		endPosition = transform.position + range;
	}
	
	// Update is called once per frame
	void Update ()
	{
		var direction = (endPosition - startPosition).normalized;
		transform.position = transform.position + (direction * speed);

		if (speed > 0f && (transform.position.x >= endPosition.x && transform.position.y >= endPosition.y))
		{
			speed = -speed;
		}

		if (speed < 0f && (transform.position.x <= startPosition.x && transform.position.y <= startPosition.y))
		{
			speed = -speed;
		}
	}

	void OnCollisionEnter2d(Collision2D col)
	{
		Debug.Log ("Hit!");
		col.collider.transform.parent = transform;
	}
}
