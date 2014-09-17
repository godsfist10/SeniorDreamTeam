using UnityEngine;
using System.Collections;

public class LavaPlumeScript : DelayedEnviromentHazard {

	public ParticleSystem lavaPlumeParticleSystem = null;
	public float minLavaPlumeSpeed = 4;
	public float maxLavaPlumeSpeed = 14;
	public float minPlumeTime = 2;
	public float maxPlumeTime = 6;
	public float minRestTime = 1;
	public float maxRestTime = 10;
	
	private bool pluming = false;
	private float timeRemaining = 0;

	public void Start()
	{
		lavaPlumeParticleSystem.startSpeed = Random.Range (minLavaPlumeSpeed, maxLavaPlumeSpeed);
		timeRemaining = Random.Range (minRestTime, maxRestTime);
	}

	public override void HazardUpdate()
	{
		timeRemaining -= Time.deltaTime;

		if( timeRemaining <= 0)
		{
			if( pluming)
			{
				lavaPlumeParticleSystem.enableEmission = false;
				timeRemaining = Random.Range (minRestTime, maxRestTime);
				pluming = false;
			}
			else
			{
				lavaPlumeParticleSystem.startSpeed = Random.Range (minLavaPlumeSpeed, maxLavaPlumeSpeed);
				lavaPlumeParticleSystem.enableEmission = true;
				timeRemaining = Random.Range (minPlumeTime, maxPlumeTime);
				pluming = true;
			}
		}
	}

	public void OnTriggerEnter(Collider collider)
	{
		if( collider.tag == "Player")
		{
			if( pluming)
			{
				Application.LoadLevel( Application.loadedLevel);
			}
		}
	}
}
