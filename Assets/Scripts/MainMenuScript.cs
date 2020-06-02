using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void RestartGame (int blah)
	{
		Time.timeScale = 1;
		Application.LoadLevel (Application.loadedLevel);
	}

	public void ChangeScene (int scene)
	{
		Time.timeScale = 1;
		Application.LoadLevel (scene);
	}
	public void Play (int level)
	{
		Time.timeScale = 1;
		PlayerPrefs.SetInt ("selecetedLevel", level);
		Application.LoadLevel (1);
	}

	public void OpenShop ()
	{

	}

	public void Exit ()
	{
		Application.Quit ();
	}


}
