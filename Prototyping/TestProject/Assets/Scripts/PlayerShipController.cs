using UnityEngine;
using System.Collections;

public class PlayerShipController : MonoBehaviour {
	
	[SerializeField] private BaseShip m_Ship;

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

	void Update ()
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

		float roll = 0;
		float pitch = 0;
		float yaw = 0;
		roll = Input.GetAxis("Roll") * (Time.fixedDeltaTime);
		pitch = Input.GetAxis("Pitch") * (Time.fixedDeltaTime);
		yaw = Input.GetAxis("Yaw") * (Time.fixedDeltaTime);
		m_Ship.controlRotation (roll, pitch, yaw);

	}
}
