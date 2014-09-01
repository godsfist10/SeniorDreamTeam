using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]

public class BaseShip : MonoBehaviour {

	[SerializeField] private BaseHull m_Hull;
	[SerializeField] private BaseWeapon m_Weapon;
	private bool boosting = false;
	private float m_CurrentSpeed;

	void Start () 
	{
		if( m_Hull == null )
		{
			m_Hull = this.transform.root.gameObject.GetComponentInChildren<BaseHull>();
			if( m_Hull == null)
				Debug.Log ( this.name + " needs a hull script assigned");
		}
		if( m_Weapon == null)
		{
			m_Weapon = this.transform.root.gameObject.GetComponentInChildren<BaseWeapon>();
			if( m_Weapon == null)
				Debug.Log ( this.name + " needs a weapon assigned");
		}

		m_CurrentSpeed = m_Hull.m_Engine.m_MinSpeed;

	}

	void FixedUpdate()
	{
		ShipUpdate ();
	}

	public void FireWeapon()
	{
		m_Weapon.handleClick();
	}

	public void assignHull( BaseHull hullToAssign)
	{
		m_Hull = new BaseHull (hullToAssign);
	}

	public void controlSpeed( bool accelerateForward)
	{
		if( accelerateForward)
		{
			m_CurrentSpeed += m_Hull.getAcceleration() * Time.deltaTime;
			if( m_CurrentSpeed > m_Hull.m_Engine.m_MaxSpeed)
				m_CurrentSpeed -= m_Hull.getAcceleration() * Time.deltaTime * m_Hull.m_Engine.m_BoostMultiplier;
		}
		else
		{
			m_CurrentSpeed -= m_Hull.getAcceleration() * Time.deltaTime;
			if( m_CurrentSpeed < m_Hull.m_Engine.m_MinSpeed)
				m_CurrentSpeed = m_Hull.m_Engine.m_MinSpeed;
		}
	}

	public void Accelerate()
	{
		m_CurrentSpeed += m_Hull.getAcceleration() * Time.deltaTime;
		if( m_CurrentSpeed > m_Hull.m_Engine.m_MaxSpeed)
			m_CurrentSpeed -= m_Hull.getAcceleration() * Time.deltaTime * m_Hull.m_Engine.m_BoostMultiplier;
	}

	public void Deaccelerate()
	{
		m_CurrentSpeed -= m_Hull.getAcceleration() * Time.deltaTime;
		if( m_CurrentSpeed < m_Hull.m_Engine.m_MinSpeed)
			m_CurrentSpeed = m_Hull.m_Engine.m_MinSpeed;
	}

	public void startBoost ()
	{
		if( boosting == false)
		{
			boosting = true;
			m_Hull.m_Engine.m_MaxSpeed *= m_Hull.m_Engine.m_BoostMultiplier;
			m_Hull.m_Engine.m_Acceleration *= m_Hull.m_Engine.m_BoostMultiplier;
		}
	}

	public void endBoost ()
	{
		if( boosting == true)
		{
			boosting = false;
			m_Hull.m_Engine.m_MaxSpeed /= m_Hull.m_Engine.m_BoostMultiplier;
			m_Hull.m_Engine.m_Acceleration /= m_Hull.m_Engine.m_BoostMultiplier;
		}
	}

	public void controlRotation( Quaternion AddRot )
	{
		rigidbody.rotation *= AddRot;
	}

	public void controlRotation( float roll, float pitch, float yaw)
	{
		Quaternion AddRot = Quaternion.identity;
		roll *= m_Hull.getMobility ();
		pitch *= m_Hull.getMobility ();
		yaw *= m_Hull.getMobility ();
		AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
		controlRotation (AddRot);
	}

	public virtual void ShipUpdate()
	{
		if( m_CurrentSpeed > m_Hull.m_Engine.m_MaxSpeed)
		{
			m_CurrentSpeed -= m_Hull.getAcceleration() * Time.deltaTime * m_Hull.m_Engine.m_BoostMultiplier;
			Debug.Log("overMaxSpeed");
		}

		Vector3 AddPos2 = Vector3.forward;
		AddPos2 = rigidbody.rotation * AddPos2;
		rigidbody.velocity = AddPos2 * (m_CurrentSpeed);
	}

}
