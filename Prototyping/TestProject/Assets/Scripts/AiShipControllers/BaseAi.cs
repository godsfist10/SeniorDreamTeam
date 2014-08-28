using UnityEngine;
using System.Collections;

public abstract class BaseAi : MonoBehaviour {

	// Use this for initialization
	[SerializeField] protected float visionDist = 0;

	[SerializeField] protected BaseShip m_Ship;
	[SerializeField] protected SphereCollider visionCollider = null;
	public virtual void Start () 
	{
		if( m_Ship == null)
		{
			m_Ship = this.transform.root.gameObject.GetComponentInChildren<BaseShip>();
			if( m_Ship == null)
				Debug.Log(this.name + " needs a ship script assigned");
		}

		if( visionCollider != null)
			visionCollider.radius = visionDist;
		else
			Debug.Log("Ship " + this.name + " needs a vision sphere assigned");

		if( this.gameObject.layer != 12)
		{
			this.gameObject.layer = 12;
		}
	}

	public virtual void AIUpdate()
	{

	}

	public virtual void EnteredVisionSphere(Collider collider)
	{

	}

	public virtual void OnTriggerEnter(Collider collider)
	{
		EnteredVisionSphere(collider);
	}

	public void Update () 
	{
		AIUpdate();
	}

}
