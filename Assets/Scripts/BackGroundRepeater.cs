using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BackGroundRepeater : MonoBehaviour
{

	public GameObject backGround;
	private List<GameObject> backgroundTiles = new List<GameObject> ();
	private float moveSpeed = 2;

	// Use this for initialization
	void Start ()
	{
	
		for (int x = -4; x < 7; x++) {
			for (int y= -2; y < 3; y++) {
				GameObject go = GameObject.Instantiate (backGround);
				go.transform.parent = transform.parent;
				go.transform.position = new Vector3 (x * 2.5f, y * 2.5f, 0);
				backgroundTiles.Add (go);
			}
		}


	}
	
	// Update is called once per frame
	void Update ()
	{
		foreach (GameObject bt in backgroundTiles) {
			Vector3 tempTransform = bt.transform.position;
			tempTransform.x -= Time.deltaTime * moveSpeed;
			if (tempTransform.x < -13) {
				tempTransform.x = 13;
			}
			bt.transform.position = tempTransform;

		}
	
	}
}
