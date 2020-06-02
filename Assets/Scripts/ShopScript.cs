using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{



	public Text pointsText;

	public Text damageLevel;
	public Text damageCost;

	public Text healthLevel;
	public Text healthCost;

	public Text fireRateLevel;
	public Text fireRateCost;

	public Text energyLevel;
	public Text energyCost;

	int points;

	int damage;
	int health;
	float fireRate;
	float energy;



	// Use this for initialization
	void Start ()
	{

		points = PlayerPrefs.GetInt ("points");

		pointsText.text = points.ToString ();


		damage = PlayerPrefs.GetInt ("damage");

		if (damage <= 0) {
			damage = 1;
			PlayerPrefs.SetInt ("damage", damage);
		}

		damageLevel.text = damage.ToString ();
		damageCost.text = (damage * 100).ToString ();

		health = PlayerPrefs.GetInt ("health");

		if (health <= 0) {
			health = 1;
			PlayerPrefs.SetInt ("health", health);
		}

		healthLevel.text = health.ToString ();
		healthCost.text = (health * 100).ToString ();

		fireRate = PlayerPrefs.GetFloat ("fireRate");

		if (fireRate < 1) {
			fireRate = 1;
			PlayerPrefs.SetFloat ("fireRate", fireRate);

		}

		fireRateLevel.text = fireRate.ToString ();
		fireRateCost.text = (fireRate * 100).ToString ();

		energy = PlayerPrefs.GetFloat ("energy");
		
		if (energy < 10) {
			energy = 10;			
			PlayerPrefs.SetFloat ("energy", energy);
		}

		energyLevel.text = energy.ToString ();
		energyCost.text = (energy * 10).ToString ();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void ModDamage (bool increase)
	{
		if (increase) {
			if (points >= damage * 100) {
				points -= damage * 100;
				damage ++;
			}
		} else {
			if (damage - 1 > 0) {
				damage--;
				points += damage * 100;
			}
		}
		PlayerPrefs.SetInt ("points", points);
		PlayerPrefs.SetInt ("damage", damage);

		damageLevel.text = damage.ToString ();
		damageCost.text = (damage * 100).ToString ();

		pointsText.text = points.ToString ();


	}

	public void ModHealth (bool increase)
	{
		if (increase) {
			if (points >= health * 100) {
				points -= health * 100;
				health ++;
			}
		} else {
			if (health - 1 > 0) {
				health--;
				points += health * 100;
			}
		}
		PlayerPrefs.SetInt ("points", points);
		PlayerPrefs.SetInt ("health", health);
		
		healthLevel.text = health.ToString ();
		healthCost.text = (health * 100).ToString ();

		pointsText.text = points.ToString ();
		
	}

	public void ModEnergy (bool increase)
	{
		if (increase) {
			if (points >= energy * 10) {
				points -= (int)(energy * 10);
				energy ++;
			}
		} else {
			if (energy - 10 > 0) {
				energy--;
				points += (int)energy * 10;
			}
		}
		PlayerPrefs.SetInt ("points", points);
		PlayerPrefs.SetFloat ("energy", energy);
		
		energyLevel.text = energy.ToString ();
		energyCost.text = (energy * 10).ToString ();		

		pointsText.text = points.ToString ();
	}

	public void ModFireRate (bool increase)
	{
		if (increase) {
			if (points >= fireRate * 100) {
				points -= (int)fireRate * 100;
				fireRate ++;
			}
		} else {
			if (fireRate - 1 > 0) {
				fireRate--;
				points += (int)fireRate * 100;
			}
		}
		PlayerPrefs.SetInt ("points", points);
		PlayerPrefs.SetFloat ("fireRate", fireRate);
		
		fireRateLevel.text = fireRate.ToString ();
		fireRateCost.text = (fireRate * 100).ToString ();	

		pointsText.text = points.ToString ();
		
	}



}
