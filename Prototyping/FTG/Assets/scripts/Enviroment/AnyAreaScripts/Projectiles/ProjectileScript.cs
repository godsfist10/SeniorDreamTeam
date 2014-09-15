using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour 
{

	public float speed = 0;
	public float life = 10;
	public float speedMultiplier = 1;
	public bool itsHot = false;
	
	public virtual void Update () 
	{
		moveProjectile();
		checkDeath();
	}
	public virtual void moveProjectile()
	{
		if (!itsHot)
			transform.position += transform.forward * speed * speedMultiplier * Time.deltaTime;
		else
			transform.position += transform.up * -1.0f * speed * speedMultiplier * Time.deltaTime;
	}
	
	public virtual void checkDeath()
	{
		life -= Time.deltaTime;
		if(life <= 0)
		{
			Destroy(gameObject);
		}
	}

	public virtual void OnTriggerEnter(Collider collider)
	{

		if( collider.tag == "Player")
		{
			//Transform tempTransform = collider.GetComponent<Respawn>().respawnObject.transform;
			//collider.transform.position = tempTransform.position;
			//collider.transform.localEulerAngles = tempTransform.localEulerAngles;
			collider.rigidbody.velocity = Vector3.zero;
			collider.rigidbody.angularVelocity = Vector3.zero;
		}

	}

	public void dropItLikeItsHot()
	{
		speedMultiplier = .5f;
		itsHot = true;
	}
}
