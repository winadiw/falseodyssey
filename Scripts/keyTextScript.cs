using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class keyTextScript : MonoBehaviour 
{
	Text keyText;
	public int keyNumber;
	// Use this for initialization
	void Awake () 
	{
		keyText = GetComponent<Text> ();
		keyNumber = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		keyNumber = GameManager.countKeyFound ();
		keyText.text = "Key Found: " + keyNumber;
	}
}
