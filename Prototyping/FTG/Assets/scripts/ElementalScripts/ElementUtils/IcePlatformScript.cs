using UnityEngine;
using System.Collections;

public class IcePlatformScript : IceDelayedMelt {
	
	//because reasons thats why

	public override void fireTouch()
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
