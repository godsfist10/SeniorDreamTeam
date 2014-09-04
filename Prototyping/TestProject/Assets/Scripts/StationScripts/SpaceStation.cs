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

	public void Update()
	{
		/*counter++;

		if( counter > 20)
		{
			CleanFriendlyShipList();
			counter = 0;
		}*/

		swapShipUpdate();
	}

	protected void CleanFriendlyShipList()
	{
		for( int i = 0; i < m_FriendlyShipList.Count; i++)
		{
			if( m_FriendlyShipList[i] == null)
			{
				Debug.Log("cleared index " + i); 
				m_FriendlyShipList.RemoveAt(i);
			}
		}
	}

	public void IDed(GameObject soonToBeDead)
	{
		int tempIndex = 0;
		if( soonToBeDead.GetComponentInChildren<FriendlyControllerManager>().playerControl)
		{
			swapForwardNextShip();
		}
		for( int i = 0; i < m_FriendlyShipList.Count; i++)
		{
			if( soonToBeDead == m_FriendlyShipList[i])
				tempIndex = i;
		}

		m_FriendlyShipList.Remove(soonToBeDead);

		if( m_CurrentShipIndex > tempIndex)  //if an object is removed that has an index lower than current index then the current needs to be offset
			m_CurrentShipIndex--;
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
			Debug.Log ( m_FriendlyShipList[i].name);
		}
	}

	public void addFriendlyShip(GameObject friendly)
	{
		m_FriendlyShipList.Add (friendly);
	}

	public void swapShipUpdate()
	{
		if( m_FriendlyShipList.Count > 1)
		{
			if( Input.GetKeyDown(KeyCode.E))
			{
				swapForwardNextShip();
			}
			else if( Input.GetKeyDown(KeyCode.Q))
			{
				swapBackwardNextShip();
			}
		}
	}

	protected void swapForwardNextShip()
	{
		int tempCurrentShip = m_CurrentShipIndex + 1;
		if( tempCurrentShip >= m_FriendlyShipList.Count)
		{
			tempCurrentShip = 0;
		}
		if( m_FriendlyShipList[tempCurrentShip].gameObject != null)
			swapShipControls( tempCurrentShip);
		else
			Debug.Log ("trying to swap forward to null index of " + tempCurrentShip);
	}

	protected void swapBackwardNextShip()
	{
		int tempCurrentShip = m_CurrentShipIndex - 1;
		if( tempCurrentShip < 0)
		{
			tempCurrentShip = m_FriendlyShipList.Count - 1;
		}
		if( m_FriendlyShipList[tempCurrentShip].gameObject != null)
			swapShipControls( tempCurrentShip);
		else
			Debug.Log ("trying to swap backward to null index of " + tempCurrentShip);
	}

	public void shipPlayerControl(int index)
	{
		if( m_FriendlyShipList[index] != null)
		{
			m_FriendlyShipList [index].GetComponentInChildren<FriendlyControllerManager> ().PlayerControl (true);
		}
		else
		{
			Debug.Log("cant swap to that its null");
		}
	}

	public void swapShipControls(int swapTo)
	{
		if( m_FriendlyShipList [swapTo] != null)
		m_FriendlyShipList [swapTo].GetComponentInChildren<FriendlyControllerManager> ().PlayerControl (true);

		if( m_FriendlyShipList [m_CurrentShipIndex] != null)
		m_FriendlyShipList [m_CurrentShipIndex].GetComponentInChildren<FriendlyControllerManager> ().PlayerControl (false);

		m_CurrentShipIndex = swapTo;

	}
}
