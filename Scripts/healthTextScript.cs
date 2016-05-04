using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class healthTextScript : MonoBehaviour 
{
	Text healthText;
	public int healthNumber;
	// Use this for initialization
	void Awake() 
	{
		healthText = GetComponent<Text> ();
		healthNumber = 3;
	}

	// Update is called once per frame
	void Update () 
	{
		healthText.text = "Health: " + GameManager.playerHealth;
	}
}
