using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

	public bool enemy;

	public float damage;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine (destroyMe ());
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	IEnumerator destroyMe ()
	{
		yield return new WaitForSeconds (10f);
		GameObject.Destroy (this.gameObject);
	}
	     
	void OnTriggerEnter2D (Collider2D other)
	{
		string otherTag = other.tag;
		//Debug.Log (otherTag);
		if ("Player".Equals (otherTag)) {
			if (enemy) {
				Player p = other.GetComponent<Player> ();
				p.Damage (damage);
				GameObject.Destroy (this.gameObject);
			}
		}

		if ("Enemy".Equals (otherTag)) {
			if (!enemy) {
				EnemyScript e = other.GetComponent<EnemyScript> ();
				e.Damage (damage);
				GameObject.Destroy (this.gameObject);
			}
		}

		if (enemy) {

		}
	}

}
