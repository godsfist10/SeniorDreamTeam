using UnityEngine;
using System.Collections;

public class ElectricMarkerTeleportation : MonoBehaviour {

	public GameObject player = null;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Fire1(bool pressed)
	{
		if (pressed)
		{
			player.transform.position = gameObject.transform.position;
			Destroy (transform.parent.gameObject);
		}
	}
}
