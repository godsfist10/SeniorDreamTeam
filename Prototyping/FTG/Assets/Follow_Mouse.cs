using UnityEngine;
using System.Collections;

public class Follow_Mouse : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		Vector3 Pos;
		Pos.x = ray.origin.x;
		Pos.y = ray.origin.y;
		Pos.z = 0;
		transform.position = Pos;
	}
}
