using UnityEngine;
using System.Collections;

public class ShatterScript : MonoBehaviour {

	public GameObject shatteredPlatformPrefab = null;
	public string tagToShatter = null;

	void OnTriggerEnter(Collider collider)
	{
		if( collider.tag == tagToShatter)
		{
			if(!transform.parent.GetComponent<IcePlatformScript>().melting)
			{
				Vector3 parentPos = transform.parent.transform.position;
				Destroy(transform.parent.gameObject);
				Instantiate( shatteredPlatformPrefab, parentPos, Quaternion.identity);
			}

		}
	}
}
