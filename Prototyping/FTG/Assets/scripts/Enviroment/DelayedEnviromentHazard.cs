using UnityEngine;
using System.Collections;

public abstract class DelayedEnviromentHazard : MonoBehaviour 
{
	protected bool hazardActive = false;

	public void OnEnable()
	{
		PickupScript.PickupEvent += ActivateHazard;
	}

	public void OnDisable()
	{
		PickupScript.PickupEvent -= ActivateHazard;
	}

	// Update is called once per frame
	public virtual void Update () 
	{
		if (hazardActive) 
		{
			HazardUpdate();
		}
	}

	public abstract void HazardUpdate ();

	public virtual void ActivateHazard()
	{
		hazardActive = true;
	}

}
