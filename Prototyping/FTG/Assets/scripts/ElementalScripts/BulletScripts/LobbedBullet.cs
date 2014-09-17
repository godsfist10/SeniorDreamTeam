using UnityEngine;
using System.Collections;

public class LobbedBullet : BulletMoveScript {

	public float upwardForceOfLob = 0;

	public virtual void Start () 
	{
		rigidbody.AddForce (0, upwardForceOfLob, 0);
	}

}
