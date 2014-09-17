using UnityEngine;
using System.Collections;

public class IceDelayedMelt : IceMeltScript {

	public float countdownToMelt = 0;
	
	// Update is called once per frame
	public override void Update () 
	{
		if (countdownToMelt > 0) 
		{
			countdownToMelt -= Time.deltaTime;
			if (countdownToMelt <= 0)
					melting = true;
		}

		base.Update ();
	}
}
