using UnityEngine;
using System.Collections;

public class WizardDuel : MonoBehaviour
{

		public Path[] attackPaths;
		private int currentAttackPath = 0;

		// Use this for initialization
		void Start ()
		{
				if (attackPaths.Length > 0) {
						for (int i = 1; i < attackPaths.Length; ++i) {
								attackPaths [i].DeactivatePath ();
						}
				}
				attackPaths [0].ActivatePath ();
		}
	
		// Update is called once per frame
		void Update ()
		{

		}

		public void PathDone (Path path)
		{
				if (attackPaths.Length == 0)
						return;

				if (!path.Equals (attackPaths [currentAttackPath])) 
						return;

				++currentAttackPath;
				if (currentAttackPath >= attackPaths.Length)
						currentAttackPath = 0;
				attackPaths [currentAttackPath].ActivatePath ();
				
		}

}
