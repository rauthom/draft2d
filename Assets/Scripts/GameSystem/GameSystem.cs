using UnityEngine;
using System.Collections;

public class GameSystem : MonoBehaviour
{
		public Path path1;

		private bool btnDown = false;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetMouseButtonDown (0)) {
						if (btnDown == false) {
								btnDown = true;
								path1.ActivatePath ();
						}
				} else if (Input.GetMouseButtonUp (0)) {
						btnDown = false;
				}
		}

}
