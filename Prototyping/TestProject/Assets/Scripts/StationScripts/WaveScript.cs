using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveScript : MonoBehaviour {
	
	public List<BaseWaveScript> m_WavesList;
	[SerializeField] protected float m_InitialDelay = 30;

	public void Update()
	{
		if( m_InitialDelay > 0)
		{
			m_InitialDelay -= Time.deltaTime;
			if( m_InitialDelay <= 0)
			{
				if( m_WavesList.Count > 0)
				{
					m_WavesList[0].BeginWaveCountdown();
				}
			}
		}
	}

	public void WaveCompleteAlert()
	{
		m_WavesList.RemoveAt(0);
		if( m_WavesList.Count > 0)
		{
			m_WavesList[0].BeginWaveCountdown();
		}
		else
		{
			Debug.Log ("all waves complete");
		}
	}

}
