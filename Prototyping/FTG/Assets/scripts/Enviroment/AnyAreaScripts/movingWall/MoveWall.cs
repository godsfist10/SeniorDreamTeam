using UnityEngine;
using System.Collections;

public class MoveWall : DelayedEnviromentHazard {


	public float retractedDelayTime = 0;
	public float extendedDelayTime = 0;
	public float startupOffsetTime = 0;
	public bool frozen {get; set;}
	public bool inhibitSpeed {get; set;}
	
	private float timePassed = 0;
	private bool delay = false;

	public Vector3 startPos;
	public Vector3 endPos;
	public float timeToExtend;
	private float currentTime;
	private bool extending = true;
	private float inhibitor = 1;

	private Vector3 to;
	private Vector3 from;
	// Use this for initialization
	void Start () 
	{ 
		to = endPos;
		from = startPos;
	}
	
	// Update is called once per frame
	public override void HazardUpdate () 
	{
		if (!frozen) 
		{
			if(startupDelayOver())
			{
				if( delay )
				{
					loopDelay();
				}
				else
				{
					moveWall();
				}
			}
		}
		else 
		{
			transform.Translate(0,0,0);
		}
	}

	void updateSpeed()
	{
		if( inhibitSpeed)
		{
			inhibitor = .5f;
		}
		else
		{
			inhibitor = 1;
		}
	}

	bool startupDelayOver()
	{
		if (startupOffsetTime > 0) 
		{
			startupOffsetTime -= Time.deltaTime;
			return false;
		}
		return true;
	}

	void loopDelay()
	{
		timePassed += Time.deltaTime;
		updateSpeed ();

		if (timePassed >= (extending ? retractedDelayTime : extendedDelayTime))
		{
			delay = false;
			timePassed = 0.0f;
		}
	}

	void moveWall()
	{
		currentTime += Time.deltaTime * inhibitor;

		if( currentTime >= timeToExtend)
		{
			extending = !extending;
			currentTime = 0;
			Vector3 temp = to;
			to = from;
			from = temp;
			delay = true;
		}

		float lerpAmount = currentTime / timeToExtend;

		Vector3 tempVec;
		tempVec.x = Mathf.Lerp (from.x, to.x, lerpAmount);
		tempVec.y = Mathf.Lerp (from.y, to.y, lerpAmount);
		tempVec.z = Mathf.Lerp (from.z, to.z, lerpAmount);

		transform.position = tempVec;
	}


	


}
