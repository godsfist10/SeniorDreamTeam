using UnityEngine;
using System.Collections;

public class FallingWall : DelayedEnviromentHazard {

	public Vector3 positionToFallTo = Vector3.zero;


	public override void HazardUpdate ()
	{

	}

	public override void ActivateHazard()
	{
		transform.position = positionToFallTo;

	}

}
