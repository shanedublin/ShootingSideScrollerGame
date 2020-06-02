using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour
{


	public GameObject bullet;
	private Player p;
	public AudioSource source;
	public AudioClip bulletSound;
	// Use this for initialization
	void Start ()
	{
		p = GetComponentInParent<Player> ();
	}

	public void TryToFire ()
	{
		if (Time.time - p.lastFire > 1 / p.fireRate) {
			p.lastFire = Time.time;
			
			GameObject b = GameObject.Instantiate (bullet);
			
			Bullet bulletScript = b.GetComponent<Bullet> ();
			bulletScript.damage = p.damage;
			
			b.transform.position = transform.position;
			Rigidbody2D body = b.GetComponent<Rigidbody2D> ();
			body.velocity = new Vector2 (p.bulletSpeed, 0);
			//				bulletSound.Play ();
			
			source.PlayOneShot (bulletSound);
			
		}
	}

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
		if (Input.GetTouch (0).phase == TouchPhase.Moved) {
			TryToFire ();
		}
	}
	
	void checkWindowsInput ()
	{
		if (Input.GetMouseButton (1)) {
			TryToFire ();
		}
	}
}
