using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

	public Rigidbody m_Rigidbody;
	public float speed = .5f;
	public float hitDistance = 3;
	public float pushForce = 10;
	public float whipForce = 10;
	public float maxWhipForce = 40;
	public GameObject eyes;
	protected GameObject m_holdingObject = null;
	[SerializeField] protected bool velocityThrow = false;
	void Start () 
	{
		
	}

	void Update () 
	{
		Vector3 tempVel = Vector3.zero;

		if( Input.GetKey(KeyCode.W))
     	{
			tempVel += transform.forward;
		}
		if( Input.GetKey(KeyCode.A))
		{
			tempVel -= transform.right;
		}
		if( Input.GetKey(KeyCode.D))
		{
			tempVel += transform.right;
		}
		if( Input.GetKey(KeyCode.S))
		{
			tempVel -= transform.forward;
		}
		if(Input.GetMouseButtonDown(0))
		{
			if( m_holdingObject != null)
			{
				preThrowDrop();
				throwForward();
			}
			else
			{
				Ray ray = new Ray(eyes.transform.position, eyes.transform.forward);
				RaycastHit hit;
				int layerMask = 1 << 8;
				if( Physics.Raycast(ray, out hit, hitDistance, layerMask))
				{
					Debug.DrawRay( eyes.transform.position, eyes.transform.forward * hitDistance, Color.white);
					hit.rigidbody.AddForceAtPosition(eyes.transform.forward * pushForce ,hit.point,ForceMode.Impulse);
				}
			}
		}
		if(Input.GetMouseButtonDown(1))
		{
			Ray ray = new Ray(eyes.transform.position, eyes.transform.forward);
			RaycastHit hit;
			int layerMask = 1 << 8;
			if( Physics.Raycast(ray, out hit, hitDistance, layerMask))
			{
				if( hit.transform.tag == "Throwable")
				{
					m_holdingObject = hit.transform.gameObject;
					m_holdingObject.rigidbody.isKinematic = true;
					m_holdingObject.rigidbody.detectCollisions = false;
					m_holdingObject.transform.parent = eyes.transform;
					//Debug.Log("grabbed");
				}
			}
		}
		else if( Input.GetMouseButtonUp(1))
		{
			if( m_holdingObject != null)
			{
				preThrowDrop();
				if(velocityThrow)
					whipObject();
				else
					lightlyDrop();

			}
		}

		rigidbody.velocity = tempVel.normalized * speed * Time.deltaTime; 
	}

	void preThrowDrop()
	{
		m_holdingObject.transform.parent = null;
		m_holdingObject.rigidbody.isKinematic = false;
		m_holdingObject.rigidbody.detectCollisions = true;
		
	}

	void throwForward()
	{
		m_holdingObject.rigidbody.AddForce(eyes.transform.forward * pushForce * 100);
		//Debug.Log("throw forward");
		m_holdingObject = null;
	}

	void lightlyDrop()
			{
		//Debug.Log("lightly dropped it");
		m_holdingObject = null;
	}

	void whipObject()
	{
		Vector3 tempVel = Vector3.zero;
		tempVel += eyes.transform.right * Input.GetAxis("Mouse X") * whipForce;
		tempVel += eyes.transform.up * Input.GetAxis("Mouse Y") * whipForce;
		Debug.Log(tempVel);
		if( tempVel.magnitude > maxWhipForce)
			tempVel = tempVel.normalized * maxWhipForce;
		m_holdingObject.rigidbody.AddForce (tempVel, ForceMode.VelocityChange);
		//Debug.Log("throw with camera");
		m_holdingObject = null;
	}


}
