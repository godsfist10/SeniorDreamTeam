using UnityEngine;
using System.Collections;

public class DelayedDelete : MonoBehaviour {

	public float countdownToDelete = 0;
	// Use this for initialization
	
	// Update is called once per frame
	void Update ()
	{
		countdownToDelete -= Time.deltaTime;
		if (countdownToDelete <= 0)
			Destroy (gameObject);

	}
}
