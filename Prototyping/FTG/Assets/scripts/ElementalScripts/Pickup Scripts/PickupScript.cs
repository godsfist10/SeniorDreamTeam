using UnityEngine;
using System.Collections;

public abstract class PickupScript : MonoBehaviour {

	protected int ElementNumber = 0;
	protected string ElementString = "";
	
	public delegate void PickupDelegate();
	public static event PickupDelegate PickupEvent;


	public virtual void OnTriggerEnter(Collider collision) 
	{
		if(collision.gameObject.tag == "Player")
		{
			collidedWithPlayer();
			Destroy(this.gameObject);
		}
	}

	public virtual void collidedWithPlayer()
	{
		if (PickupEvent != null)
			PickupEvent ();

		PlayerPrefs.SetInt (ElementString, 1);
	}
}
