using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendlyControllerManager : MonoBehaviour {

	public PlayerShipController m_PlayerController = null;
	public BaseAiManager m_AIManager = null;
	public bool playerControl = false;
	[SerializeField] protected GameObject m_Camera = null;
	// Use this for initialization
	void Start () 
	{
		if( m_AIManager == null)
		{
			m_AIManager = this.transform.root.GetComponentInChildren<BaseAiManager>();
			if( m_AIManager == null)
			{
				Debug.Log(this.name + " needs a ai manager script assigned");
			}
		}

		if( m_Camera == null)
		{
			m_Camera = this.transform.root.GetComponentInChildren<Camera>().gameObject;
			if( m_Camera == null)
			{
				Debug.Log(this.name + " needs a camera assigned");
			}
		}

		if( m_PlayerController == null)
		{
			m_PlayerController = this.transform.root.GetComponentInChildren<PlayerShipController>();
			if( m_PlayerController == null)
			{
				Debug.Log(this.name + " needs a Player Controller script assigned");
			}
		}
	}
	
	// Update is called once per frame
	public void Update () 
	{
		if( playerControl)
		{
			m_PlayerController.PlayerControllerUpdate();
		}
		else
		{
			m_AIManager.AIManagerUpdate();
		}
	}

	public void PlayerControl(bool val)
	{
		if(val)
		{
			playerControl = true;
			m_Camera.SetActive(true);
		}
		else
		{
			playerControl = false;
			m_Camera.SetActive(false);
		}
	}
}
