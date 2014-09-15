using UnityEngine;
using System.Collections;

public class litTorchReact : MonoBehaviour {

	private Vector3 origPos = Vector3.zero;
	public Vector3 pickupReactPos;
	private Vector3 currentPos;
	private Vector3 targetPos;

	[SerializeField]
	float smoothSnapDistance = 0;
	[SerializeField]
	float moveSmooth = .25f;
 
	public void OnEnable()
	{
		PickupScript.PickupEvent += PickupReact;
		UnlitTorchTrigger.torchLitEvent += TorchLitReact;
	}
	
	public void OnDisable()
	{
		PickupScript.PickupEvent -= PickupReact;
		UnlitTorchTrigger.torchLitEvent -= TorchLitReact;
	}

	public void Start()
	{
		origPos = gameObject.transform.position;
		currentPos = origPos;
		targetPos = origPos;
	}

	public void Update()
	{
		if (gameObject.transform.position != targetPos) 
		{
			currentPos = smoothMove( currentPos, targetPos);
			gameObject.transform.position = currentPos;
		}
	}

	private void PickupReact()
	{
		targetPos = pickupReactPos;
	}

	private void TorchLitReact()
	{
		targetPos = origPos;
	}

	Vector3 smoothMove( Vector3 currentPos , Vector3 targetPos)
	{
		if(Mathf.Abs(currentPos.y - targetPos.y) <= this.smoothSnapDistance)
		{
			return targetPos;
		}
		else
		{
			Vector3 returnPos;
			
			returnPos.x = Mathf.Lerp(currentPos.x, targetPos.x, this.moveSmooth);
			returnPos.y = Mathf.Lerp(currentPos.y, targetPos.y, this.moveSmooth);
			returnPos.z = Mathf.Lerp(currentPos.z, targetPos.z, this.moveSmooth);
			
			return returnPos;
		}
	}

}
