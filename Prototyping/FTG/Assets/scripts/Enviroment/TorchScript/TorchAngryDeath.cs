using UnityEngine;
using System.Collections;

public class TorchAngryDeath : DelayedEnviromentHazard {
	
	public float minLightRange = 0;
	public float maxLightRange = 0;
	public float lightStep = 0;
	public Light lightToFlicker = null;	
	private float currentRange;
	private float targetRange = 0;
	public float deathBurstMultiplier = 1;
	// Update is called once per frame
	
	private bool finalSpark = false;
	
	void Start()
	{
		targetRange = Random.Range (minLightRange, maxLightRange);
		currentRange = lightToFlicker.range;
	}
	
	public override void Update()
	{
		if (!hazardActive) 
		{
			Flicker();
		}
		else
		{
			HazardUpdate();
		}
	}
	
	public override void HazardUpdate()
	{

		//lightStep *= 2;
		
		if( !finalSpark)
		{
			if( currentRange < targetRange)
				currentRange += lightStep;
			
			if( currentRange >= targetRange)
			{
				finalSpark = true;

				minLightRange /= 2;
				maxLightRange /= 2;
			}
			lightToFlicker.range = currentRange;
		}
		else
		{
			Flicker();
		}
		
		
	}

	public override void ActivateHazard()
	{
		targetRange *= deathBurstMultiplier;
		lightStep*=2;
		hazardActive = true;
	}
	
	void Flicker () 
	{
		if (currentRange < targetRange)
		{
			currentRange += lightStep;
			
			if( currentRange >= targetRange)
			{
				targetRange = Random.Range (minLightRange, maxLightRange);
			}
		} 
		else if (currentRange > targetRange) 
		{
			currentRange -= lightStep;
			
			if( currentRange <= targetRange)
			{
				targetRange = Random.Range (minLightRange, maxLightRange);
			}
		}
		
		if( currentRange == targetRange)
			targetRange = Random.Range (minLightRange, maxLightRange);
		
		lightToFlicker.range = currentRange;
	}
	
	
	
}
