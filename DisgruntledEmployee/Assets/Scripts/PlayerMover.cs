using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

	public Rigidbody m_Rigidbody;
	public float speed = .5f;
	public float jumpHeight = 5;
	public float hitDistance = 3;
	public float pushForce = 10;
	public GameObject eyes;

	void Start () 
	{
		
	}

	void Update () 
	{
		Vector3 tempVel = Vector3.zero;

		if( Input.GetKey(KeyCode.W))
     	{
			tempVel += transform.forward * speed;
		}
		if( Input.GetKey(KeyCode.A))
		{
			tempVel -= transform.right * speed;
		}
		if( Input.GetKey(KeyCode.D))
		{
			tempVel += transform.right * speed;
		}
		if( Input.GetKey(KeyCode.S))
		{
			tempVel -= transform.forward * speed;
		}
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = new Ray(eyes.transform.position, eyes.transform.forward);
			RaycastHit hit;
			int layerMask = 1 << 8;
			if( Physics.Raycast(ray, out hit, hitDistance, layerMask))
			{
				Debug.DrawRay( eyes.transform.position, eyes.transform.forward * hitDistance, Color.white);
				hit.rigidbody.AddForceAtPosition(eyes.transform.forward * pushForce ,hit.point,ForceMode.Impulse);
				Debug.Log("hit left click");
			}
		}
		if(Input.GetMouseButtonDown(1))
		{
			Ray ray = new Ray(eyes.transform.position, eyes.transform.forward);
			RaycastHit hit;
			int layerMask = 1 << 8;
			if( Physics.Raycast(ray, out hit, hitDistance, layerMask))
			{
				hit.rigidbody.AddForceAtPosition(eyes.transform.forward * -pushForce ,hit.point,ForceMode.Impulse);
				Debug.Log("hit right click");
			}
		}

		rigidbody.velocity = tempVel * Time.deltaTime;
	}
}
