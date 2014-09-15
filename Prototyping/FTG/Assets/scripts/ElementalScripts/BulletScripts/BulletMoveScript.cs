using UnityEngine;
using System.Collections;

public class BulletMoveScript : MonoBehaviour {
	
	public float bulletSpeed = 0;
	public float bulletLife = 0;
	
	public virtual void Update () 
	{
		moveBullet();
		checkDeath();
	}
	public virtual void moveBullet()
	{
		transform.position += transform.forward*bulletSpeed*Time.deltaTime;
	}

	public virtual void checkDeath()
	{
		bulletLife -= Time.deltaTime;
		if(bulletLife <= 0)
		{
			Destroy(gameObject);
		}
	}

}
