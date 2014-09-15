using UnityEngine;
using System.Collections;

public class EmeraldTorch : MonoBehaviour {
	
	public float minLightRange = 0;
	public float maxLightRange = 0;
	public float lightStep = 0;
	public Light lightToFlicker = null;	
	private float currentRange;
	private float targetRange = 0;
	// Update is called once per frame
	public float danceAmount = .02f;
	public float danceSmooth = .2f;
	public float smoothSnapDistance = .001f;
	private Vector3 middlePos;
	private Vector3 targetPos;
	private Vector3 targetDance;

	
	void Start()
	{
		targetRange = Random.Range (minLightRange, maxLightRange);
		currentRange = lightToFlicker.range;
		middlePos = lightToFlicker.transform.position;
		targetDance = middlePos;
	}
	
	public void Update()
	{
		Flicker();
		Dance();
	}

	void Dance()
	{
		if( lightToFlicker.transform.position == targetDance)
		{
			targetDance.x = Random.Range (middlePos.x - danceAmount, middlePos.x + danceAmount);
			targetDance.y = Random.Range (middlePos.y - danceAmount, middlePos.y + danceAmount);
			targetDance.z = Random.Range (middlePos.z - danceAmount, middlePos.z + danceAmount);
		}

		lightToFlicker.transform.position = smoothDance( lightToFlicker.transform.position, targetDance);
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
	
	protected Vector3 smoothDance(Vector3 currentPos, Vector3 targetPos)
	{
		Vector3 returnPos;

		if( Mathf.Abs ((currentPos.x- targetPos.x)) <= smoothSnapDistance)
			returnPos.x = targetPos.x;
		else
			returnPos.x = Mathf.Lerp(currentPos.x, targetPos.x, this.danceSmooth);

		if( Mathf.Abs (( currentPos.y- targetPos.y)) <= smoothSnapDistance)
			returnPos.y = targetPos.y;
		else
			returnPos.y = Mathf.Lerp(currentPos.y, targetPos.y, this.danceSmooth);

		if( Mathf.Abs (( currentPos.z- targetPos.z)) <= smoothSnapDistance)
			returnPos.z = targetPos.z;
		else
			returnPos.z = Mathf.Lerp(currentPos.z, targetPos.z, this.danceSmooth);
			
		return returnPos;
	}
	
}
