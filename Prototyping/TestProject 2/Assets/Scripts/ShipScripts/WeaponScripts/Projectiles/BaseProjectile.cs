using UnityEngine;
using System.Collections;

public abstract class BaseProjectile : MonoBehaviour {

	// Use this for initialization
	public float m_Range = 0;
	public float m_Damage = 0;

	public virtual void init( float range, float damage, float initVelocity)
	{
		m_Range = range;
		m_Damage = damage;
	}
	
}
