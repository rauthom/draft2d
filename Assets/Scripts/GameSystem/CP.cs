using UnityEngine;
using System.Collections;

public class CP : MonoBehaviour
{
		public string trajectory;

		public Path path;

		public Sprite Enabled;
		public Sprite Disabled;
		public Sprite Done;

		// Use this for initialization
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.gameObject.tag == "TrajectoryLeft") {
						path.Contact (this);
				}
		}

		void OnTriggerExit2D (Collider2D other)
		{
				//	if (other.gameObject.tag == "TrajectoryLeft") {
				//		SpriteRenderer sr = gameObject.renderer.GetComponent<SpriteRenderer> ();
				//		sr.sprite = Enabled;
				//	}
		}

		public void EnableCP ()
		{
				renderer.GetComponent<SpriteRenderer> ().sprite = Enabled;
		}

		public void DisableCP ()
		{
				renderer.GetComponent<SpriteRenderer> ().sprite = Disabled;
		}

		public void ValidateCP ()
		{
				renderer.GetComponent<SpriteRenderer> ().sprite = Done;
		}
}
