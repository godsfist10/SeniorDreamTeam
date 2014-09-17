using UnityEngine;
using System.Collections;

public class EndState : MonoBehaviour {

	public float timeToShowMessage = 3.0f;
	private bool show = false;
	public GUIText startText = null;
	public GUIText endText = null;
	public GUIText tutText = null;
	private float timeToShow;

	private Vector2 offScreenPos;

	void Start () 
	{
		//offScreenPos.x = 999;
		timeToShow = timeToShowMessage;

		if( Application.loadedLevel == 1 && PlayerPrefs.GetInt("Fire") != 1)
		{
			show = true;
			startText.enabled = true;
			endText.enabled = false;
			tutText.enabled = false;
		}
		else if (Application.loadedLevel == 1 && PlayerPrefs.GetInt("Nature") == 1) 
		{
			show = true;
			endText.enabled = true;
			startText.enabled = false;
			tutText.enabled = false;
		}
		else if(Application.loadedLevel == 1 && PlayerPrefs.GetInt("Ice") != 1)
		{
			show = true;
			startText.enabled = false;
			endText.enabled = false;
			tutText.enabled = true;
		}
		else
		{
			startText.enabled = false;
			endText.enabled = false;
			tutText.enabled = false;
		}
	}

	void Update () 
	{
		if (show) 
		{
			timeToShow -= Time.deltaTime;
			if( timeToShow <= 0)
			{
				show = false;
				startText.enabled = false;
				endText.enabled = false;
				tutText.enabled = false;
			}
		}

	}
}
