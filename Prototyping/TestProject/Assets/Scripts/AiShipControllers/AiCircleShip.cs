using UnityEngine;
using System.Collections;

public class AiCircleShip : BaseAi {
	
	[SerializeField] private float roll = 0.0f;
	[SerializeField] private float pitch = 0.0f;
	[SerializeField] private float yaw = 0.0f;
	
	// Update is called once per frame
	public override void AIUpdate()
	{
		m_Ship.Accelerate();
		m_Ship.controlRotation (roll, pitch, yaw);
	}
}
