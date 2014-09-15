using UnityEngine;
using System.Collections;

public class IceShieldScript : MonoBehaviour {

	public float speedMultiplier = .25f;
	public bool iceFieldActive = false;
		
	// Update is called once per frame
	public void OnTriggerEnter(Collider collider)
	{
		if( iceFieldActive)
		{
			if( collider.tag == "Projectile")
			{
				collider.GetComponent<ProjectileScript>().dropItLikeItsHot();
			}
		}
	}

	void OnTriggerExit(Collider collider)
	{
		/*
		if( iceFieldActive)
		{
			if( collider.tag == "Projectile")
			{
				collider.GetComponent<ProjectileScript>().dropItLikeItsHot();
			}
		}
		*/
	}

	public void Activate_Deactivate()
	{
		iceFieldActive = !iceFieldActive;
	}

	public void Activate_Deactivate(bool val)
	{
		iceFieldActive = val;
	}


}
