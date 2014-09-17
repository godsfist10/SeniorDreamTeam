using UnityEngine;
using System.Collections;

public class IceMeltScript : MonoBehaviour {

	public float meltSpeed = 0;
	public Vector3 meltDirection = Vector3.zero;
	public bool melting = false;
	
	// Update is called once per frame
	public virtual void Update () 
	{
		if (melting)
		{
			transform.localScale -=  (meltDirection * meltSpeed);
			if( transform.localScale.x <= 0 || transform.localScale.y <= 0 || transform.localScale.z <= 0)
				Destroy(this.gameObject);
		}
	}

	public virtual void fireTouch()
	{
		if (!melting) 
		{
			melting = true;
		}
		else 
		{
			meltSpeed *= 2;
		}
	}
}
