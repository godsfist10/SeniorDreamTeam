using UnityEngine;
using System.Collections;

public class ElectricScript : MonoBehaviour { 


	public GameObject bulletPrefab = null;
	public GameObject bulletSpawnObject = null;
	public float bulletShootCost = 0;
	public GameObject gameObjectToTeleportTo = null;
	public bool bulletExists = false;
	public bool markerExists = false;

	//private bool buttonDown = false;

	public void Start()
	{

	}

	public void Update()
	{
		//Left Click to shoot projectile
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			if(bulletExists == false)
			{
				if(markerExists == true)
				{
					Destroy (gameObjectToTeleportTo);
					GameObject temp = GameObject.FindGameObjectWithTag("Projectile");
					if( temp != null)
					{
						Destroy(temp); 
					}
					markerExists = false;
				}
				
				gameObjectToTeleportTo = (GameObject)Instantiate(bulletPrefab, bulletSpawnObject.transform.position, bulletSpawnObject.transform.rotation);
				//buttonDown = true;
				bulletExists = true;
			}
		}


		//Right Click for teleport
		if(Input.GetKeyDown(KeyCode.Mouse1))
		{
			if(gameObjectToTeleportTo != null)
			{
				gameObject.transform.position = gameObjectToTeleportTo.transform.position;
				rigidbody.velocity = Vector3.zero;

				if(markerExists == true)
				{
					Destroy (gameObjectToTeleportTo);
					GameObject temp = GameObject.FindGameObjectWithTag("Projectile");
					if( temp != null)
					{
						Destroy(temp); 
					}
			
					markerExists = false;
				}
				else
				{
					Destroy (gameObjectToTeleportTo);
				}
				
				bulletExists = false;
			}
		}
	}
}