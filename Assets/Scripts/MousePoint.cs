using UnityEngine;
using System.Collections;

public class MousePoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 nextPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		nextPos.z = 0.0f;
		transform.position = nextPos;
	}
}
