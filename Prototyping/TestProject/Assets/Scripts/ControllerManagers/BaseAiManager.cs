using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseAiManager : MonoBehaviour {

	public List<BaseAi> m_AIList;
	public int m_ActiveAI = 0;
	public bool EnemyShip = false;
	// Use this for initialization

	void Start () 
	{
		if( this.transform.root.gameObject.layer == 9)
		{
			EnemyShip = true;
		}

		if( m_AIList.Count == 0)
			m_AIList.AddRange (this.transform.root.GetComponentsInChildren<BaseAi> ());

	}

	void Update () 
	{
		if( EnemyShip)
		{
			AIManagerUpdate ();
		}

	}

	public virtual void AIManagerUpdate()
	{
			m_AIList [m_ActiveAI].ActiveAIUpdate ();
			/*for( int i = 0; i < m_AIList.Count; i++)  //took out inactive update because there wasnt anything that I could think of to do there aka wasted processing
			{
				if( i != m_ActiveAI)
					m_AIList[i].InactiveAIUpdate();
			}*/
		/*else
		{
			for( int i = 0; i < m_AIList.Count; i++)
			{
				m_AIList[i].InactiveAIUpdate();
			}
		}*/


	}
}
