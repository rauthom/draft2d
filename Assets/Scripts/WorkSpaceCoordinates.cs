using UnityEngine;
using System.Collections;
using System;

public class WorkSpaceCoordinates : MonoBehaviour {

	public static float OffsetX { get; set; }
	public static float OffsetY { get; set; }
	public static float OffsetZ { get; set; }

	// Use this for initialization
	void Start () {
		OffsetX = transform.position.x;
		OffsetY = transform.position.y;
		OffsetZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
