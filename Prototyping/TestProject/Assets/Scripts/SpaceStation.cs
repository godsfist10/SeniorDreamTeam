using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceStation : MonoBehaviour {

	public List<GameObject> m_FriendlyShipList; 
	public int m_CurrentShipIndex;

	void Start () 
	{
		m_FriendlyShipList.AddRange( GameObject.FindGameObjectsWithTag("FriendlyShip"));

		for( int i = 0; i < m_FriendlyShipList.Count; i++)
		{
			if( m_FriendlyShipList[i].GetComponentInChildren<FriendlyControllerManager>().playerControl)
			{
				SetCurrentPlayerShip(i);
			}
		}
		//listShips ();
	}

	public void SetCurrentPlayerShip(GameObject currentShip)
	{
		int tempCurrent = -1;
		for( int i = 0; i < m_FriendlyShipList.Count; i++)
		{
			if( currentShip == m_FriendlyShipList[i])
			{
				m_CurrentShipIndex = i;
				tempCurrent = 1;
			}
		}

		if (tempCurrent == -1) 
		{
			Debug.Log (currentShip.name + " is not within the space stations list of friendly ships");
		}
	}

	public void SetCurrentPlayerShip(int currentShipIndex)
	{
	    if( currentShipIndex < m_FriendlyShipList.Count && currentShipIndex >= 0)
		{
			m_CurrentShipIndex = currentShipIndex;
		}
	}

	void listShips()
	{
		for( int i = 0; i < m_FriendlyShipList.Count; i++)
		{
			Debug.Log( m_FriendlyShipList[i].name);
		}
	}

	public void addFriendlyShip(GameObject friendly)
	{
		m_FriendlyShipList.Add (friendly);
	}

	// Update is called once per frame
	void Update () 
	{
		swapShipFunction ();
	}

	public void swapShipFunction()
	{
		if( Input.GetKeyDown(KeyCode.E))
		{
			int tempCurrentShip = m_CurrentShipIndex + 1;
			if( tempCurrentShip >= m_FriendlyShipList.Count)
			{
				tempCurrentShip = 0;
			}
			swapShipControls( tempCurrentShip);
		}
		else if( Input.GetKeyDown(KeyCode.Q))
		{
			int tempCurrentShip = m_CurrentShipIndex - 1;
			if( tempCurrentShip < 0)
			{
				tempCurrentShip = m_FriendlyShipList.Count - 1;
			}
			swapShipControls( tempCurrentShip);
		}
	}

	public void swapShipControls(int swapTo)
	{

		m_FriendlyShipList [swapTo].GetComponentInChildren<FriendlyControllerManager> ().PlayerControl (true);
		m_FriendlyShipList [m_CurrentShipIndex].GetComponentInChildren<FriendlyControllerManager> ().PlayerControl (false);

		m_CurrentShipIndex = swapTo;

	}
}
