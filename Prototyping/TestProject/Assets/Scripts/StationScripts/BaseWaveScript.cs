using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BaseWaveScript : MonoBehaviour {
	
	public List<GameObject> m_ShipsToSpawn = new List<GameObject>();
	protected List<Object> m_WaveShips;
	[SerializeField] protected float m_SpawnDelay = 1;
	protected bool mb_CountdownStart = false;
	[SerializeField] protected float m_SpawnDistance = 1000;
	protected bool waveSpawned = false;
	// Update is called once per frame

	public void Start()
	{
		m_WaveShips = new List<Object>();
	}

	public virtual void Update () 
	{
		if( mb_CountdownStart == true && waveSpawned == false)
		{

			m_SpawnDelay -= Time.deltaTime;
			if( m_SpawnDelay <= 0)
			{

				mb_CountdownStart = false;
				waveSpawned = true;
				SpawnWave();
			}
		}

		if( waveSpawned == true)
		{
			if( m_WaveShips.Count != 0)
				cleanShipList();
			if( m_WaveShips.Count == 0)
			{
				WaveComplete();
				Destroy(this.gameObject);
			}
		}
	}



	public void BeginWaveCountdown()
	{
		mb_CountdownStart = true;
	}

	public virtual void WaveComplete()
	{
		Debug.Log ( this.name + " complete");
		this.transform.root.GetComponentInChildren<WaveScript>().WaveCompleteAlert();
	}

	protected virtual void SpawnWave()
	{
		Debug.Log ("Spawning " + this.name);
		if( m_ShipsToSpawn.Count > 0)
		{
			Vector2 pos;
			for( int i = 0; i < m_ShipsToSpawn.Count; i++)
			{
				pos = Random.insideUnitCircle.normalized * m_SpawnDistance;
				m_WaveShips.Add( Instantiate(m_ShipsToSpawn[i], new Vector3(pos.x, 0, pos.y), Quaternion.identity));
			}
		}
	}

	protected void cleanShipList()
	{
		for( int i = 0; i < m_WaveShips.Count; i++)
		{
			if( m_WaveShips[i] == null)
			{
				m_WaveShips.RemoveAt(i);
			}
		}
	}

}
