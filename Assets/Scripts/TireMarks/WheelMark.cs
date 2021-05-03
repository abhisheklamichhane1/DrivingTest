using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMark : MonoBehaviour
{



	public GameObject skidCaller;
	public float startSlipValue = 0.4f;
	private TireMarks skidmarks = null;
	private int lastSkidmark = -1;
	private WheelCollider wheel_col;


	void Start()
	{
		skidCaller = transform.root.gameObject;
		wheel_col = GetComponent<WheelCollider>();
		if (FindObjectOfType(typeof(TireMarks)))
		{
			skidmarks = FindObjectOfType(typeof(TireMarks)) as TireMarks;
		}
		else
			Debug.Log("No skidmarks object found. Skidmarks will not be drawn");
	}

	void FixedUpdate()
	{
		WheelHit GroundHit; 
		wheel_col.GetGroundHit(out GroundHit);
		var wheelSlipAmount = Mathf.Abs(GroundHit.sidewaysSlip);

		if (wheelSlipAmount > startSlipValue)
		{

			Vector3 skidPoint = GroundHit.point + 2 * (skidCaller.GetComponent<Rigidbody>().velocity) * Time.deltaTime;
			lastSkidmark = skidmarks.AddSkidMark(skidPoint, GroundHit.normal, wheelSlipAmount / 2.0f, lastSkidmark);
		}
		else
		{
			lastSkidmark = -1;
		}

	}


}
