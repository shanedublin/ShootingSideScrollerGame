using UnityEngine;
using System.Collections;

public class MenuNavigator : MonoBehaviour
{


	public GameObject shop;
	public GameObject main;
	public GameObject levelSelect;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void OpenShop (bool open)
	{
		Debug.Log ("open Shop:" + open);
		shop.SetActive (open);
		main.SetActive (!open);
		levelSelect.SetActive (false);
	}

	public void OpenLevelSelect (bool open)
	{
		Debug.Log ("open levelSelect:" + open);
		levelSelect.SetActive (open);
		main.SetActive (!open);
		shop.SetActive (false);
	}





}
