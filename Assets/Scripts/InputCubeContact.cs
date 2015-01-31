using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputCubeContact : MonoBehaviour
{
		public static bool contact = false;
		public Text impactTxt;
	
		// Use this for initialization
		void Start ()
		{
		
		}
	
		// Update is called once per frame
		void Update ()
		{
				rigidbody.inertiaTensor = Vector3.zero;
				rigidbody.angularVelocity = Vector3.zero;
				rigidbody.velocity = Vector3.zero;
		}
	
		void OnCollisionEnter (Collision collision)
		{
				impactTxt.text = "Okay";
				if (collision != null && collision.contacts != null && collision.contacts.Length > 0) {
						Vector3 contactPoint = collision.contacts [0].point;
						impactTxt.text = "Last impact at: (" + contactPoint.x.ToString () + "," + contactPoint.z.ToString () + ")";
						collision.collider.gameObject.renderer.material.color = Color.yellow;
						contact = true;
				}
				
		}
	
		void OnCollisionExit (Collision collision)
		{
				collision.collider.gameObject.renderer.material.color = Color.red;
				contact = false;
		}
}
