using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]

public class BasicBullet : BaseProjectile {
	
	public float m_Speed = 150;

	public virtual void Start () 
	{
		Vector3 forwardDir = rigidbody.rotation * Vector3.forward;
		rigidbody.velocity = forwardDir * m_Speed;
	}

	// Update is called once per frame
	public virtual void Update () 
	{
		m_Range -= Time.deltaTime;
		if( m_Range <= 0)
			Destroy(this.gameObject);
	}
}
