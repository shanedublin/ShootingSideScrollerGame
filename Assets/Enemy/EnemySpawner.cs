using UnityEngine;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{

	public List<GameObject> units = new List<GameObject> ();


	public TextAsset[] level;

	private JSONArray levelArray;


	private ScoreBoard scoreBoard;

	// Use this for initialization
	void Start ()
	{
		int selectedLevel = PlayerPrefs.GetInt ("selectedLevel");

		scoreBoard = FindObjectOfType<ScoreBoard> ();

		//Debug.Log (level.ToString ());
		var j = JSON.Parse (level [selectedLevel].ToString ());

		levelArray = j.AsArray;



		StartCoroutine (SpawnWave ());

	}
	
	// Update is called once per frame
	void Update ()
	{
//		if (Time.time - lastEnemy1Spawn > enemy1SpawnRate) {
//			lastEnemy1Spawn = Time.time;
//			GameObject go = GameObject.Instantiate (enemy1);
//
//			float ySpawn = Random.Range (-5.5f, 5.5f);
//			go.transform.position = new Vector3 (12, ySpawn, 0);
//
//			enemy1SpawnRate *= .99f;
//			if (enemy1SpawnRate < .1f) {
//				enemy1SpawnRate = .1f;
//			}
//
//
//		}
	
	}

	IEnumerator SpawnWave ()
	{
		int totalBadGuys = 0;
		foreach (JSONNode n in levelArray.Childs) {			
			JSONArray waveUnits = n ["wave"].AsArray;
			foreach (JSONNode unit in waveUnits) {
				GameObject go = GameObject.Instantiate (units [unit ["enemy"].AsInt]);
				go.transform.position = new Vector3 (unit ["x"].AsFloat, unit ["y"].AsFloat, 0);
				totalBadGuys ++;
			}
			yield return new WaitForSeconds (n ["time"].AsFloat);
		}
		scoreBoard.enemiesInLevel = totalBadGuys;
		scoreBoard.doneSpawning = true;



	}

}
