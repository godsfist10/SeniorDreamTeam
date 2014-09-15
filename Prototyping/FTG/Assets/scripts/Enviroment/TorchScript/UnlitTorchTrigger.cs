using UnityEngine;
using System.Collections;

public class UnlitTorchTrigger : MonoBehaviour {

	public float minLightRange = 0;
	public float maxLightRange = 0;
	public float lightStep = 0;
	public Light lightToFlicker = null;	
	private float currentRange;
	private float targetRange = 0;
	private bool lit = false;
	public ParticleSystem fire = null;

	public delegate void TorchDelegate();
	public static event TorchDelegate torchLitEvent;

	// Update is called once per frame
	
	
	void Start()
	{
		targetRange = Random.Range (minLightRange, maxLightRange);
		currentRange = lightToFlicker.range;
		fire.enableEmission = false;
	}

	public void Update()
	{
		if( lit)
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

	public void lightTorch()
	{
		lit = true;
		fire.enableEmission = true;

		if (torchLitEvent != null)
			torchLitEvent ();
	}


}
