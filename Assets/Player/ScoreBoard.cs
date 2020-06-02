using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

	public Text scoreText;
	public Text highScoreText;

	public Text energyText;
	public Text healthText;

	private int score = 0;
	private int highScore;

	private Player p;

	public bool doneSpawning;

	public Text enemyCountText;
	public Text pointsText;

	public int enemiesInLevel;
	public int enemiesKilled;
	public int points;
	public int totalPoints;

	public GameObject victoryObject;

	// Use this for initialization
	void Start ()
	{

		p = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		highScore = PlayerPrefs.GetInt ("highScore");

		highScoreText.text = highScore.ToString ();
		energyText.text = PlayerPrefs.GetFloat ("energy").ToString ();
		healthText.text = p.health.ToString ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (doneSpawning) {
			if (GameObject.FindGameObjectsWithTag ("Enemy").Length <= 0) {
				ShowVictory ();
				doneSpawning = false;
			}
		}
	}

	public void UpdateUI ()
	{
		energyText.text = p.energy.ToString ();
		healthText.text = p.health.ToString ();
	}

	public void ModScore (int s)
	{
		this.score += s;
		this.enemiesKilled ++;

		//Debug.Log (score);
		scoreText.text = score.ToString ();

		if (score > highScore) {
			highScore = score;
			highScoreText.text = scoreText.text;
			PlayerPrefs.SetInt ("highScore", highScore);
		}
	}

	public void ShowVictory ()
	{
		points = score * 2;
		if (enemiesKilled >= enemiesInLevel) {
			points = (int)(points * 1.2f);
		}

		enemyCountText.text = enemiesKilled + "/" + enemiesInLevel;
		pointsText.text = "$" + points;
		///Debug.Log ("Points This Round: " + points);
		int currentPoints = PlayerPrefs.GetInt ("points");
		//Debug.Log ("CurrentPoints::" + currentPoints);
		PlayerPrefs.SetInt ("points", currentPoints + points); 
		victoryObject.SetActive (true);
		Time.timeScale = 0;
	}


}
