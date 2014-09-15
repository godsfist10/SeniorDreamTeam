using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

	public float movementSpeed = 0.0f;
	public float jumpSpeed = 0.0f;

	private float distanceToGround;

	//public Camera MainCamera;

	// Use this for initialization
	void Start () 
	{
		distanceToGround = collider.bounds.extents.y;
		//MainCamera.gameObject.tag = "MainCamera";
	}
	
	// Update is called once per frame
	void Update () 
	{
		Movement();

		if (IsGrounded()) 
		{	
			Jump();
		}
	}

	void Movement()
	{
		float sideMovement = Input.GetAxis("Horizontal") * movementSpeed;
		sideMovement *= Time.deltaTime;
		transform.Translate(sideMovement, 0, 0);
		//MainCamera.transform.Translate(sideMovement, 0, 0);

	}

	void Jump()
	{
		if(Input.GetButtonDown("Jump"))
		{
			gameObject.rigidbody.AddForce(Vector3.up * jumpSpeed);
		}
	}

	bool IsGrounded()
	{
		return Physics.Raycast(transform.position, - Vector3.up, distanceToGround + 0.1f);
	}
}
