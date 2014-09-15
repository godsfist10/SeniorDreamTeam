using UnityEngine;
using System.Collections;

public class BeginGame : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{	
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.SetInt ("Fire", 0);
		PlayerPrefs.SetInt ("Ice", 0);
		PlayerPrefs.SetInt ("Nature", 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			PlayerPrefs.SetInt ("Fire", 0);
			PlayerPrefs.SetInt ("Ice", 0);
			PlayerPrefs.SetInt ("Nature", 0);

			Application.LoadLevel(1);
		}
	}
}
