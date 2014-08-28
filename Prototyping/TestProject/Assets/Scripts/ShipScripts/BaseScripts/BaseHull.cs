using UnityEngine;
using System.Collections;

public class BaseHull : MonoBehaviour {

	public BaseEngine m_Engine;
	private float m_Health;
	public float m_MaxHealth;
	private float m_Shields;
	public float m_MaxShields;
	public float m_Weight;
	public float m_ArmorFactor = 1;  // above 1 increases defence and below 1 reduces it 
	private float m_armorDamageMultiplier;

	public virtual void Start()
	{
		if( m_Engine == null)
		{   
			m_Engine = this.transform.root.gameObject.GetComponentInChildren<BaseEngine>();
			if( m_Engine == null)
				Debug.Log( this.name + " needs an engine script assigned");
		}
		m_Health = m_MaxHealth;
		m_Shields = m_MaxShields;
		m_armorDamageMultiplier = 1.0f / m_ArmorFactor;
	}

	public BaseHull( BaseHull otherBaseHull)
	{
		m_MaxHealth = otherBaseHull.m_MaxHealth;
		m_MaxShields = otherBaseHull.m_MaxShields;
		m_Weight = otherBaseHull.m_Weight;
		m_ArmorFactor = otherBaseHull.m_ArmorFactor;
		assignEngine (otherBaseHull.m_Engine);
	}

	public void OnTriggerEnter( Collider collider)
	{
		if( collider.tag == "Projectile")
		{
			takeDamage( collider.GetComponent<BaseProjectile>().m_Damage);
			Destroy(collider.gameObject);
		}
	}

	public virtual void assignEngine( BaseEngine engine)
	{
		m_Engine = new BaseEngine(engine);
	}

	public virtual void takeDamage( float incomingDamage )
	{
		float damage = incomingDamage;
		if( m_Shields > 0)
		{
			if( m_Shields >= damage)
			{
				m_Shields -= damage;
				damage = 0;
			}
			else
			{
				damage -= m_Shields;
				m_Shields = 0;
			}
		}

		if( damage > 0)
		{
			damage *= m_armorDamageMultiplier;
			m_Health -= damage;
		}

		if (m_Health <= 0)
		{
			destroyed();
		}
	}

	public virtual void destroyed()
	{
		if( this.gameObject.transform.root != null)
			Destroy(this.gameObject.transform.root.gameObject);
		else
			Destroy(this.gameObject);
	}

	public virtual float getAcceleration()
	{
		return m_Engine.getAcceleration (m_Weight);
	}

	public virtual float getMobility()
	{
		return m_Engine.getMobility (m_Weight);
	}

}
