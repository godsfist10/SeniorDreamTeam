using UnityEngine;
using System.Collections;

public class ElectricBullet : BulletMoveScript {

	public GameObject player = null;
	public GameObject electricMarker = null;




	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter(Collider collider)
	{
		ElectricScript targetScript = player.GetComponent<ElectricScript> ();
		Debug.Log ("projectile hit");
		//if (collider.tag != "Player") 
		//{
			GameObject tempMarker = (GameObject)Instantiate(electricMarker, gameObject.transform.position, gameObject.transform.rotation);
			targetScript.gameObjectToTeleportTo = tempMarker;
			targetScript.bulletExists = false;
			targetScript.markerExists = true;

			Destroy (gameObject);
		//}
	}
}
