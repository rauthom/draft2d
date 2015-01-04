using UnityEngine;
using System.Collections;

public class GameSystem : MonoBehaviour
{
		public WizardDuel wizardDuel;

		// Use this for initialization
		void Start ()
		{
				wizardDuel.gameObject.SetActive (true);
		}
	
		// Update is called once per frame
		void Update ()
		{

		}

}
