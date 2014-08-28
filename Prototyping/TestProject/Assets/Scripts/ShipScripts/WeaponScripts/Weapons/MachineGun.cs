using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]

public class MachineGun : BaseWeapon {

	// Use this for initialization
	public GameObject bullet = null;
	[SerializeField] protected float m_Range;
	[SerializeField] protected float m_Damage;

	public virtual void Start () 
	{
		if( bullet == null)
		{
			Debug.Log(this.name + " needs a projectile assigned");
		}
	}
	protected override void Fire()
	{
		GameObject temp = (GameObject)Instantiate(bullet, new Vector3(rigidbody.position.x, rigidbody.position.y, rigidbody.position.z), rigidbody.rotation);
		temp.GetComponent<BaseProjectile>().init(m_Range, m_Damage);
		if( this.gameObject.layer == 8)
		{
			temp.layer = 10;
		}
		else if( this.gameObject.layer == 9)
		{
			temp.layer = 11;
		}
		else
		{
			Debug.Log(this.name + " requires friendly or enemy layer");
		}
	}
}
