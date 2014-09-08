using UnityEngine;
using System.Collections;

public class FlightTest2 : MonoBehaviour {

	public float AmbientSpeed = 100.0f;
	
	public float m_RotationSpeed = 100.0f;
	public float m_Acceleration = 50.0f;
	public float m_MaxSpeed = 100.0f;
	public float m_ConstSpeed = 5000.0f;
	public float m_MinSpeed = 10.0f;
	public bool m_ConstSpeedNODrift = false;
	public float m_BoostMultiplier = 1.5f;
	private bool boosting = false;

	private float m_CurrentSpeed;
	// Use this for initialization
	void Start () 
	{
		m_CurrentSpeed = m_MinSpeed;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.W)) 
		{
			//rigidbody.AddRelativeForce(0, 0, m_Acceleration * Time.deltaTime, ForceMode.Acceleration);
			m_CurrentSpeed += m_Acceleration * Time.deltaTime;
			if( m_CurrentSpeed > m_MaxSpeed)
				m_CurrentSpeed = m_MaxSpeed;
		}
		if(Input.GetKey (KeyCode.S))
		{
			//rigidbody.AddRelativeForce(0, 0, -m_Acceleration * Time.deltaTime, ForceMode.Acceleration);
			//rigidbody.velocity = rigidbody.velocity.normalized * ( rigidbody.velocity.magnitude * m_brakeMultiplier);
			m_CurrentSpeed -= m_Acceleration * Time.deltaTime;
			if( m_CurrentSpeed < m_MinSpeed)
				m_CurrentSpeed = m_MinSpeed;
		}
	
		if( Input.GetButtonDown("Boost"))
		{
			if( boosting == false)
			{
				boosting = true;
				m_MaxSpeed *= m_BoostMultiplier;
				m_Acceleration *= m_BoostMultiplier;
			}
		}
		if( Input.GetButtonUp("Boost"))
		{
			if( boosting == true)
			{
				boosting = false;
				m_MaxSpeed /= m_BoostMultiplier;
				m_Acceleration /= m_BoostMultiplier;
			}
		}

	}
	
	void FixedUpdate()
	{
		UpdateFunction();
	}
	
	void UpdateFunction()
	{
		Quaternion AddRot = Quaternion.identity;
		float roll = 0;
		float pitch = 0;
		float yaw = 0;
		roll = Input.GetAxis("Roll") * (Time.fixedDeltaTime * m_RotationSpeed);
		pitch = Input.GetAxis("Pitch") * (Time.fixedDeltaTime * m_RotationSpeed);
		yaw = Input.GetAxis("Yaw") * (Time.fixedDeltaTime * m_RotationSpeed);
		AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
		rigidbody.rotation *= AddRot;

		Vector3 AddPos2 = Vector3.forward;
		AddPos2 = rigidbody.rotation * AddPos2;
		rigidbody.velocity = AddPos2 * (m_CurrentSpeed);

		//Debug.Log (m_CurrentSpeed);

		if( m_ConstSpeedNODrift)
		{
			Vector3 AddPos = Vector3.forward;
			AddPos = rigidbody.rotation * AddPos;
			rigidbody.velocity = AddPos * (Time.fixedDeltaTime * m_ConstSpeed);
		}

		/*if (rigidbody.velocity.magnitude.CompareTo (m_MaxSpeed) > 0) 
		{
			rigidbody.velocity = rigidbody.velocity.normalized * m_MaxSpeed;
		}
		if( rigidbody.velocity.magnitude < m_MinSpeed)
		{


		}*/
	}
}
