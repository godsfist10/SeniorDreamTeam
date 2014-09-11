using UnityEngine;
using System.Collections;

public class PlayerShipController : MonoBehaviour {
	
	[SerializeField] protected BaseShip m_Ship;
	[SerializeField] protected GameObject m_TurretPrefab;

	void Start()
	{
		if( m_Ship == null)
		{
			m_Ship = this.transform.root.gameObject.GetComponentInChildren<BaseShip>();
			if( m_Ship == null)
				Debug.Log(this.name + " needs a ship script assigned");
		}

		if( this.gameObject.layer != 12)
			this.gameObject.layer = 12;
	}

	public void PlayerControllerUpdate ()
	{
		if (Input.GetKey (KeyCode.W)) 
		{
			m_Ship.Accelerate();
		}
		if( Input.GetKey(KeyCode.S))
		{
			m_Ship.Deaccelerate();
		}

		if( Input.GetKeyDown(KeyCode.LeftShift))
		{
			m_Ship.startBoost();
		}
		if( Input.GetKeyUp(KeyCode.LeftShift))
		{
			m_Ship.endBoost();
		}

		if(Input.GetMouseButton(0))
		{
			m_Ship.FireWeapon();
		}

		if(Input.GetKeyDown(KeyCode.R))
		{
			Instantiate(m_TurretPrefab, m_Ship.transform.position, Quaternion.identity);
		}

		float roll = 0;
		float pitch = 0;
		float yaw = 0;
		roll = Input.GetAxis("Roll") * (Time.fixedDeltaTime);
		pitch = Input.GetAxis("Pitch") * (Time.fixedDeltaTime);
		yaw = Input.GetAxis("Yaw") * (Time.fixedDeltaTime);
		m_Ship.controlRotation (roll, pitch, yaw);
	}
}
