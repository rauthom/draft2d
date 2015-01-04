using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tip : MonoBehaviour
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
				Vector3 pos = new Vector3 ();
				pos.x = (Input.mousePosition.x - 800) / 1000 * 10 + WorkSpaceCoordinates.OffsetX;
				pos.y = (Input.mousePosition.y - 200) / 900 * 10 + WorkSpaceCoordinates.OffsetY;
				pos.z = WorkSpaceCoordinates.OffsetZ;
				transform.position = pos;
		}

		void OnCollisionEnter (Collision collision)
		{
				if (collision != null && collision.contacts != null && collision.contacts.Length > 0)
						impactTxt.text = "Impact at: " + collision.contacts [0].point.ToString ();
				collision.collider.gameObject.renderer.material.color = Color.yellow;
				contact = true;
		}

		void OnCollisionExit (Collision collision)
		{
				collision.collider.gameObject.renderer.material.color = Color.red;
				contact = false;
		}

}
