using UnityEngine;
using UnityEngine.Sprites;
using System.Collections;
using System.Collections.Generic;

public class MousePoint : MonoBehaviour {

	public GameObject test;

	private Queue<GameObjectCTime> line = new Queue<GameObjectCTime>();

	class GameObjectCTime
	{
		public float CreationTime { get; set; }
		public GameObject GameObject { get; set; }
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// Set the point position at the mouse cursor position
		Vector3 nextPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		nextPos.z = 0.0f;
		transform.position = nextPos;

		float now = Time.time;

		GameObject pt = (GameObject) Instantiate (test, nextPos, Quaternion.identity);
		GameObjectCTime ptTime = new GameObjectCTime ();
		ptTime.CreationTime = now;
		ptTime.GameObject = pt;
			
		line.Enqueue (ptTime);
			
		while (line.Peek().CreationTime + 0.5f < now) {
			GameObjectCTime ptOut = line.Dequeue();
			Destroy(ptOut.GameObject);
		}
	
	}
}
