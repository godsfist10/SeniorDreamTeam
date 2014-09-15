using UnityEngine;
using System.Collections;

public class GuardMover : MonoBehaviour {

	[SerializeField] protected NavMeshAgent m_NavAgent = null;
	public GameObject m_Player;
	public bool m_GrumpyGuard = false;
	public bool m_REALLYGRUMPYGUARD = false;
	// Use this for initialization
	void Start () 
	{
		if( m_NavAgent == null)
		{
			m_NavAgent = this.gameObject.GetComponent<NavMeshAgent>();
		}
		if( m_Player == null)
		{
			Debug.Log("assign player to " + this.name);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( m_NavAgent.pathStatus == NavMeshPathStatus.PathComplete )
		{
			if( m_GrumpyGuard )
			{
				NavMeshHit hit;
				if (!m_NavAgent.Raycast( m_Player.transform.position, out hit))
				{
					Debug.Log ("guard saw you");
					m_REALLYGRUMPYGUARD = true;
					m_GrumpyGuard = false;
					m_NavAgent.SetDestination(m_Player.transform.position);
				}
				else
				{
					m_GrumpyGuard = false;
				}
			}
			if( m_REALLYGRUMPYGUARD)
			{
				m_NavAgent.SetDestination(m_Player.transform.position);
			}
		}

	}

	public void Disturbance(Vector3 pos)
	{
		Debug.Log("grumpy");
		if( !m_GrumpyGuard && !m_REALLYGRUMPYGUARD)
		{
			m_GrumpyGuard = true;
			m_NavAgent.SetDestination(pos);
		}
	}





}
