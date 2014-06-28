using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class PlayerPhysics : MonoBehaviour {

	public LayerMask collisionMask;

	private BoxCollider myCollider;
	private Vector3 size;
	private Vector3 center;

	[HideInInspector]
	public bool grounded;

	private float skin = .005f;

	Ray ray;
	RaycastHit hit;

	void Start()
	{
		myCollider = GetComponent<BoxCollider> ();
		size = myCollider.size;
		center = myCollider.center;
	}

	public void Move(Vector2 moveAmount)
	{
		float deltaX = moveAmount.x;
		float deltaY = moveAmount.y;
		Vector2 position = transform.position;

		grounded = false;
		for (int i = 0; i < 3; i++)
		{
			float dir = Mathf.Sign (deltaY);
			float x = (position.x + center.x - size.x/2) + size.x/2 * i;
			float y = position.y + center.y + size.y/2 * dir;
		
			ray = new Ray(new Vector2(x,y), new Vector2(0, dir));
			Debug.DrawRay(ray.origin, ray.direction);

			if (Physics.Raycast (ray, out hit, Mathf.Abs(deltaY), collisionMask))
			{
				float dist = Vector3.Distance(ray.origin, hit.point);	//distance between player and ground

				if (dist > skin)
				{
					deltaY = -dist + skin;
				}
				else
				{
					deltaY = 0;
				}
				grounded = true;
				break;
			}
		}

		Vector2 finalTransform = new Vector2(deltaX, deltaY);
		transform.Translate (finalTransform);
	}
}
