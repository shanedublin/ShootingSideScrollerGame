using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{



	public float health;
	public float maxHealth;
	public float energy;
	public float maxEnergy;
	public float damage;
	public Vector3 mousPos;
	public float fireRate = 1;
	public float bulletSpeed = 1;
	public float lastFire ;




	public FireScript fireScript;


	public GameObject gameOverStuff;

	private ScoreBoard scoreBoard;

	// Use this for initialization
	void Start ()
	{
		
		damage = PlayerPrefs.GetInt ("damage");
		maxHealth = PlayerPrefs.GetInt ("health");
		fireRate = PlayerPrefs.GetFloat ("fireRate");
		energy = PlayerPrefs.GetFloat ("energy");

		health = maxHealth;
		energy = maxEnergy;
		scoreBoard = GameObject.FindObjectOfType<ScoreBoard> ();
		lastFire = -fireRate;
		gameOverStuff.SetActive (false);

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Application.platform == RuntimePlatform.Android) {
			checkAndroidInput ();
		} else {
			checkWindowsInput ();

		}


	}

	void checkAndroidInput ()
	{
//		foreach (Touch touch in Input.touches) {
//			if (touch.fingerId == 1) {
//				mousPos = Camera.main.ScreenToWorldPoint (touch.position);
//			}
//		}
		if (Input.GetTouch (0).phase == TouchPhase.Moved) {
			mousPos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Debug.Log (Input.GetTouch (0).position);
			fireScript.TryToFire ();
		}

	}

	void checkWindowsInput ()
	{
		if (Input.GetMouseButton (0)) {
			mousPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		}
	}


	void FixedUpdate ()
	{
		mousPos.z = 1;
		transform.position = mousPos;
	}

	public void Damage (float dmg)
	{
		//Debug.Log ("dmg:" + dmg);
		this.health -= dmg;
		if (this.health <= 0) {
			Debug.Log ("gameOver");
			Time.timeScale = 0;
			gameOverStuff.SetActive (true);
		}
		scoreBoard.UpdateUI ();
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		string otherTag = other.gameObject.tag;
		//Debug.Log (otherTag);
		if ("Enemy".Equals (otherTag)) {

			EnemyScript e = other.gameObject.GetComponent<EnemyScript> ();
			Damage (e.health);
			e.Damage (damage);

		}
		
	
	}


}
