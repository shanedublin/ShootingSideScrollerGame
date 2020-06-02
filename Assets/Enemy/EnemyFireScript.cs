using UnityEngine;
using System.Collections;

public class EnemyFireScript : MonoBehaviour
{

	public GameObject bullet;
	private EnemyScript e;
	
	
	// Use this for initialization
	void Start ()
	{
		e = GetComponentInParent<EnemyScript> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		

		if (Time.time - e.lastFire > 1 / e.fireRate) {
			e.lastFire = Time.time;

			GameObject b = GameObject.Instantiate (bullet);

			Bullet bulletScript = b.GetComponent<Bullet> ();
			bulletScript.damage = e.damage;

			b.transform.position = transform.position;
			Rigidbody2D body = b.GetComponent<Rigidbody2D> ();
			body.velocity = new Vector2 (e.bulletSpeed, 0);

		}

	}
}
