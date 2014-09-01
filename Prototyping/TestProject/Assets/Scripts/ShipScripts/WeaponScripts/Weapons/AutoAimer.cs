using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AutoAimer : MonoBehaviour 
{
	public List<GameObject> m_WeaponsToAim = null;
	public GameObject m_CurrentTarget = null;

	void Start()
	{
		BaseAimableWeapon[] aimableWeapons = this.gameObject.transform.root.gameObject.GetComponentsInChildren<BaseAimableWeapon>();
		foreach( BaseAimableWeapon weapon in aimableWeapons)
		{
			m_WeaponsToAim.Add(weapon.gameObject);
		}
	}

	public void setTarget(GameObject target)
	{
		m_CurrentTarget = target;
	}

	public virtual void Update()
	{
		if( m_CurrentTarget != null)
		{
			if( m_WeaponsToAim.Count > 0)
			{
				RotateWeapons();
				FireGuns();
			}
		}
		else
			UnrotateWeapons();
	}

	protected void RotateWeapons()
	{
		//Transform parentTransform = this.transform.root.transform; //this must be on child of parent
		Vector3 LookAtVec = new Vector3(m_CurrentTarget.transform.position.x, m_CurrentTarget.transform.position.y, m_CurrentTarget.transform.position.z);
		for( int i = 0; i < m_WeaponsToAim.Count; i++)
		{
			m_WeaponsToAim[i].transform.LookAt( LookAtVec);
		}
	}

	protected void UnrotateWeapons()
	{
		for( int i = 0; i < m_WeaponsToAim.Count; i++)
		{
			m_WeaponsToAim[i].transform.rotation = this.gameObject.transform.rotation;
		}
	}

	protected void FireGuns()
	{
		for( int i = 0; i < m_WeaponsToAim.Count; i++)
		{
			m_WeaponsToAim[i].GetComponent<BaseAimableWeapon>().handleClick();
		}
	}

	public virtual void OnTriggerEnter(Collider collider)
	{
		if( this.transform.root.gameObject.layer == 8)
		{
			if( collider.gameObject.layer == 9)
			{
				if( m_CurrentTarget == null)
				{
					m_CurrentTarget = collider.gameObject;
				}
			}
		}
		else if( this.transform.root.gameObject.layer == 9)
		{
			if( collider.gameObject.layer == 8)
			{
				if( m_CurrentTarget == null)
				{
					m_CurrentTarget = collider.gameObject;
				}
			}
		}
	}

	public virtual void OnTriggerExit(Collider collider)
	{
		if( collider.gameObject == m_CurrentTarget)
			m_CurrentTarget = null;
	}

}
