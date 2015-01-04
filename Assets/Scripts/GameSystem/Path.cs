using UnityEngine;
using System.Collections;

public class Path : MonoBehaviour
{
		public WizardDuel parent;

		public CP[] CPs;
		private int currentCP = 0;

		private bool fadingOut = false;
		private float alpha = 1.0f;

		// Use this for initialization
		void Start ()
		{
				//	DeactivatePath ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (fadingOut) {
						if (alpha >= 0.0f) {
								foreach (CP cp in CPs) {
										SetAlphaCP (cp);
								}
								alpha -= Time.deltaTime;
						} else {
								fadingOut = false;
								DeactivatePath ();
								parent.PathDone (this);
						}
						
				}
		}

		private void SetAlphaCP (CP cp)
		{
				SpriteRenderer sr = cp.renderer.GetComponent<SpriteRenderer> ();
				Color c = sr.color;
				Color nextC = new Color (c.r, c.g, c.b, alpha);
				sr.color = nextC;
		}

		public void ActivatePath ()
		{
				fadingOut = false;
				currentCP = 0;
				alpha = 1.0f;

				if (CPs == null)
						return;
				if (CPs.Length == 0)
						return;

				this.gameObject.SetActive (true);

				foreach (CP cp in CPs) {
						cp.DisableCP ();
						SetAlphaCP (cp);
						cp.gameObject.SetActive (true);
				}
				CPs [0].EnableCP ();
		}

		public void DeactivatePath ()
		{
				foreach (CP cp in CPs) {
						cp.gameObject.SetActive (false);
				}
		}

		public void Contact (CP checkPoint)
		{
				if (checkPoint == null)
						return;
				if (this.currentCP >= CPs.Length)
						return;
				if (! CPs [this.currentCP].Equals (checkPoint))
						return;

				
				checkPoint.ValidateCP ();
				++currentCP;
				Debug.Log ("4");
				if (currentCP < CPs.Length) {
						CPs [currentCP].EnableCP ();
				} else {
						FadeOut ();
				}
		}
	
		public void FadeOut ()
		{
				fadingOut = true;
		}
}
