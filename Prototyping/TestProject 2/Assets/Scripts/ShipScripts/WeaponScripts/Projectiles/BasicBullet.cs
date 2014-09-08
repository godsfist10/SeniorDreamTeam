using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]

public class BasicBullet : BaseProjectile {
	
	public float m_Speed = 150;

	public virtual void Start () 
	{
		//Vector3 forwardDir = rigidbody.rotation * Vector3.forward;
		//rigidbody.velocity = forwardDir * m_Speed;
	}

	public override void init(float range, float damage, float initVelocity)
	{
		Vector3 forwardDir = rigidbody.rotation * Vector3.forward;
		rigidbody.velocity = forwardDir * (m_Speed + initVelocity);
		base.init(range, damage, initVelocity);
	}

	// Update is called once per frame
	public virtual void Update () 
	{
		m_Range -= Time.deltaTime;
		if( m_Range <= 0)
			Destroy(this.gameObject);
	}
}
