using UnityEngine;
using System.Collections;

public class LauncherScript : MonoBehaviour {

	public GameObject projectilePrefab = null;
	public float timeBetweenShots = 5;
	public float projectileSpeed = 4;
	public ParticleSystem optionalFiringEffect = null;
	public float startDelayTime = 0;

	private bool usingParticleEffect = false;
	private float timeTillFire = 0;


	void Start () 
	{
		if( optionalFiringEffect != null)
			usingParticleEffect = true;

		timeTillFire = startDelayTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeTillFire -= Time.deltaTime;

		if( timeTillFire <= 0)
		{
			timeTillFire = timeBetweenShots;

			GameObject tempProjectile = (GameObject)Instantiate( projectilePrefab, this.transform.position, this.transform.rotation);
			tempProjectile.GetComponent<ProjectileScript>().speed = projectileSpeed;

			if( usingParticleEffect )
				optionalFiringEffect.enableEmission = true;

		}
		
	}
}
