using UnityEngine;
using System.Collections;

public class TorchFlickerScript : MonoBehaviour {

	public float minLightRange = 0;
	public float maxLightRange = 0;
	public float lightStep = 0;
	public Light lightToFlicker = null;	
	private float currentRange;
	private float targetRange = 0;
	// Update is called once per frame
	

	void Start()
	{
		targetRange = Random.Range (minLightRange, maxLightRange);
		currentRange = lightToFlicker.range;
	}

	public void Update()
	{
			Flicker();
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
