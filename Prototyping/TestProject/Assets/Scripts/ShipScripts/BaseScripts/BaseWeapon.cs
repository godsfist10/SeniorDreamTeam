using UnityEngine;
using System.Collections;

public abstract class BaseWeapon : MonoBehaviour {

	// Use this for initialization
	public float m_FiringDelay;
	protected float m_DelayTimer = 0;

	protected abstract void Fire();

	public virtual void Update()
	{
		if( m_DelayTimer > 0)
			m_DelayTimer -= Time.deltaTime;
	}

	public virtual void handleClick()
	{
		if( m_DelayTimer <= 0)
		{
			Fire();
			m_DelayTimer = m_FiringDelay;
		}
	}
}
