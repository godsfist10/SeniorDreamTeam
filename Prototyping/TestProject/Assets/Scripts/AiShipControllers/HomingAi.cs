using UnityEngine;
using System.Collections;

public class HomingAi : BaseAi {

	public GameObject m_Target = null;


	// Use this for initialization
	public override void StartBehavior () 
	{
		this.transform.root.transform.LookAt (m_Target.transform);
	}
	
	// Update is called once per frame
	public override void ActiveAIUpdate()
	{
		this.transform.root.transform.LookAt (m_Target.transform);
		m_Ship.Accelerate();
	}
}
