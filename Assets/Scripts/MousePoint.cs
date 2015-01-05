using UnityEngine;
using UnityEngine.Sprites;
using System.Collections;
using System.Collections.Generic;


public class MousePoint : MonoBehaviour
{

		public GameObject test;

		private Queue<GameObjectCTime> line = new Queue<GameObjectCTime> ();

		private Vector3 lastPos;
		private Vector3 lastPosMid;

		class GameObjectCTime
		{
				public float CreationTime { get; set; }
				public GameObject GameObject { get; set; }
		}

		// Use this for initialization
		void Start ()
		{
//		Application.LoadLevelAdditive ("SecondaryScene");
		}
	
		// Update is called once per frame
		void Update ()
		{

				// Set the point position at the mouse cursor position
				Vector3 nextPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				nextPos.z = 0.0f;

				float now = Time.time;

				while (line.Count > 0 && line.Peek().CreationTime + 0.5f < now) {
						GameObjectCTime ptOut = line.Dequeue ();
						Destroy (ptOut.GameObject);
				}

				if (transform.position.x == nextPos.x && transform.position.y == nextPos.y)
						return;

				transform.position = nextPos;

				GameObject pt = (GameObject)Instantiate (test, nextPos, Quaternion.identity);
				GameObjectCTime ptTime = new GameObjectCTime ();
				ptTime.CreationTime = now;
				ptTime.GameObject = pt;
			
				line.Enqueue (ptTime);

				while (line.Peek().CreationTime + 0.5f < now) {
						GameObjectCTime ptOut = line.Dequeue ();
						Destroy (ptOut.GameObject);
				}



				/*
		if (lastPos == null) {
						lastPos = nextPos;
		} else if (lastPosMid == null) {
						lastPosMid = nextPos;
		} else {
			Vector3 startTangent = new Vector3();
			startTangent.x = lastPosMid.x - ((nextPos.x - lastPos.x) / 3);
			startTangent.y = lastPosMid.y - ((nextPos.y - lastPos.y) / 3);
			startTangent.z = lastPosMid.z;

			Vector3 endTangent = new Vector3();
			endTangent.x = lastPosMid.x + ((nextPos.x - lastPos.x) / 3);
			endTangent.y = lastPosMid.y + ((nextPos.y - lastPos.y) / 3);
			endTangent.z = lastPosMid.z;


			Handles.DrawBezier(lastPos, nextPos, startTangent, endTangent, Color.white, Texture2D.whiteTexture, 1.0f);

			lastPos = lastPosMid;
			lastPosMid = nextPos;
		}
		*/

				/*
		if (Tip.contact) {
			this.renderer.material.color = Color.red;
		} else {
			this.renderer.material.color = Color.white;
		}
		*/

		}

		void OnCollisionEnter2D (Collision2D collision)
		{
				this.renderer.material.color = Color.red;
		}

		void OnCollisionExit2D (Collision2D collision)
		{
				this.renderer.material.color = Color.white;
		}
}
