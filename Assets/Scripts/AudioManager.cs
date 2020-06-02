using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{

	public AudioClip laser1;
	public AudioSource audioSource;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void PlayExplodeSound ()
	{
		audioSource.PlayOneShot (laser1, .4f);
	}
}
