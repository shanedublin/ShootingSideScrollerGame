using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{


	public float maxRotateSpeed = 90;
	public float rotationSpeed;
	private Rigidbody2D body;

	// Use this for initialization
	void Start ()
	{
		body = GetComponent<Rigidbody2D> ();
		rotationSpeed = Random.Range (-maxRotateSpeed, rotationSpeed);
	}
	
	// Update is called once per frame
	void Update ()
	{

		body.MoveRotation (body.rotation + Time.deltaTime * rotationSpeed);
	}
}
