using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {

	// Player Handling
	public float gravity = 20;
	public float speed = 8;
	public float acceleration = 30;
	public float jumpHeight = 12;

	private float currentSpeed;
	private	float targetSpeed;
	private Vector2 amountToMove;

	private PlayerPhysics playerPhysics;

	void Start ()
	{
		playerPhysics = GetComponent<PlayerPhysics>();
	}
	
	void Update ()
	{
		targetSpeed = Input.GetAxisRaw ("Horizontal") * speed;
		currentSpeed = IncrementSpeed(currentSpeed, targetSpeed, acceleration);
	
		if (playerPhysics.grounded)
		{
			if (Input.GetButtonDown("Jump")) 
			{
				amountToMove.y = jumpHeight;
			}
		}
		else 
		{
			amountToMove.y -= gravity * Time.deltaTime;
		}

		amountToMove.x = currentSpeed;
		playerPhysics.Move (amountToMove * Time.deltaTime);
	}

	private float IncrementSpeed(float currentSpeed, float target, float accel)
	{
		if (currentSpeed == target)
		{
			return currentSpeed;
		} 
		else 
		{
			float dir = Mathf.Sign(target - currentSpeed);		//figure out direction
			currentSpeed += accel * Time.deltaTime * dir;
			return (dir == Mathf.Sign(target - currentSpeed)) ? currentSpeed : target; 
		}
	}
}
