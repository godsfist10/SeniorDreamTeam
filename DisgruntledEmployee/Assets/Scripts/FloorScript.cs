using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloorScript : MonoBehaviour {

	public List<GuardMover> guardList;

	public void OnTriggerEnter(Collider collider)
	{
		if( collider.tag == "Throwable")
		{
			for( int i = 0; i < guardList.Count; i++)
			{
				guardList[i].Disturbance( collider.transform.position);
			}
		}
	}
}
