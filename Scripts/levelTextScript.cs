using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelTextScript : MonoBehaviour 
{
	Text levelText;

	// Use this for initialization
	void Awake () 
	{
		levelText = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () 
	{
		levelText.text = SceneManager.GetActiveScene ().name;
	}
}
