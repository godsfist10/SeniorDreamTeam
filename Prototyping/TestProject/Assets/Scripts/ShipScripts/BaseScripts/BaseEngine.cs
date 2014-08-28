using UnityEngine;
using System.Collections;

public class BaseEngine : MonoBehaviour {

	public float m_Acceleration;
	public float m_MaxSpeed;
	public float m_BoostMultiplier;
	public float m_Mobility;
	public float m_Power;
	public float m_MinSpeed;

	public BaseEngine (BaseEngine otherEngine)
	{
		m_Acceleration = otherEngine.m_Acceleration;
		m_MaxSpeed = otherEngine.m_MaxSpeed;
		m_BoostMultiplier = otherEngine.m_BoostMultiplier;
		m_Mobility = otherEngine.m_Mobility;
		m_Power = otherEngine.m_Power;
		m_MinSpeed = otherEngine.m_MinSpeed;
	}

	public virtual float getAcceleration(float weight)
	{
		return m_Acceleration * (m_Power / weight);
	}

	public virtual float getMobility(float weight)
	{
		return m_Mobility * (m_Power / weight);
	}

}
