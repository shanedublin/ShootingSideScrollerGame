using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{


	public float maxHealth = 1;
	public float health;
	public float damage;

	public float fireRate;
	public float bulletSpeed;
	public float lastFire ;


	public float moveSpeed;

	public Rigidbody2D body;

	private ScoreBoard scoreBoard;
	//public AudioSource audioSource;

	public BoxCollider2D boxCollider;
	public GameObject firingComponet;
	private Animator animator;
	private AudioManager audioManager;

	// Use this for initialization
	void Start ()
	{

		animator = GetComponent<Animator> ();
		lastFire = -1 / fireRate;
		health = maxHealth;
		//body = GetComponent<Rigidbody2D> ();
		body.velocity = new Vector2 (-moveSpeed, 0);
		scoreBoard = GameObject.FindObjectOfType<ScoreBoard> ();
		audioManager = GameObject.FindObjectOfType<AudioManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{


	}

	public void Damage (float dmg)
	{
		health -= dmg;
		if (health <= 0) {

			scoreBoard.ModScore ((int)maxHealth); 
			StartCoroutine (ExplodeEnemy ());
		}
	}

	IEnumerator ExplodeEnemy ()
	{
		//sr.enabled = false;

		boxCollider.enabled = false;
		if (firingComponet != null)
			firingComponet.SetActive (false);
		animator.SetBool ("dead", true);
		yield return new WaitForSeconds (.7f);
		//GameObject.DestroyObject (this.gameObject);
	}
	public void Destroy ()
	{
		GameObject.DestroyObject (this.gameObject);
	}
	public void PlayExplodeSound ()
	{
		audioManager.PlayExplodeSound ();
	}
}
