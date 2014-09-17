using UnityEngine;
using System.Collections;

public class smoothCamera : MonoBehaviour 
{
	public float MAX_HEIGHT;
	public GameObject toFollow;
	
	public float minimum = 10.0F;
	public float maximum = 20.0F;
	
	float startY;
	float startZ;
	
	public float smoothFactor = 2;
	
	public Vector3 newPos;

	private float xBound;
	// Use this for initialization
	void Start () 
	{
		startY = transform.position.y;
		newPos.z = transform.position.z;
		xBound = Screen.width * -.5f + 2.0f; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		moveWithX ();
		moveWithY ();
		
		transform.position = Vector3.Lerp (transform.position, newPos, Time.deltaTime * smoothFactor);
	}
	
	void moveWithX()
	{
			newPos.x = toFollow.transform.position.x;
		/*if( toFollow.transform.position.x <= this.gameObject.transform.position.x - xBound)
		{
			//toFollow.transform.position.x = this.gameObject.transform.position.x - xBound;
			Debug.Log("You bee off screen");
		}*/
	}
	
	void moveWithY()
	{
		if (toFollow.transform.position.y > MAX_HEIGHT)
			newPos.y = toFollow.transform.position.y;
		else
			newPos.y = startY;
		
		//newPos.y = Vector3.Lerp(transform.position.y, toFollow.transform.position.y, Time.deltaTime * smoothFactor);
	}
}