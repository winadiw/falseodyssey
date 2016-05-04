using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour 
{
	public GameObject[] fires;
	// Use this for initialization
	void Start () 
	{
		fires = GameObject.FindGameObjectsWithTag ("FireTrap");
		foreach (GameObject fire in fires) 
		{
			//if (fire.activeInHierarchy) fire.SetActive (false);
			StartCoroutine (Redisable (fire));
			StartCoroutine (Reenable (fire));
		}
	}
	void Update ()
	{
		
	}

	IEnumerator Reenable(GameObject fire)
	{
		yield return new WaitForSeconds (2);
		fire.SetActive (true);
	}

	IEnumerator Redisable(GameObject fire)
	{
		yield return new WaitForSeconds (2);
		fire.SetActive (false);
	}
}
