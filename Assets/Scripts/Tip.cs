using UnityEngine;
using System.Collections;

public class Tip : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, Input.mousePosition.y / 900 * 5, transform.position.z);
	}

	void OnCollisionEnter(Collision collision) {
		collision.collider.gameObject.renderer.material.color = Color.yellow;
	}

	void OnCollisionExit(Collision collision) {
		collision.collider.gameObject.renderer.material.color = new Color (0.20f, 0.50f, 0.80f);
	}
}
